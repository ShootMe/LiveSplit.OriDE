using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.OriDE.Memory;
using LiveSplit.OriDE.Settings;
namespace LiveSplit.OriDE {
	public class OriComponent : IComponent {
		public string ComponentName { get { return "Ori DE Autosplitter"; } }
		public TimerModel Model { get; set; }
		private string oriLogPath = "_OriDE.log";
		public IDictionary<string, Action> ContextMenuControls { get { return null; } }
		private OriMemory mem;
		private int currentSplit = 0;
		private bool hasLog = false;
		private int lastLogCheck = 0;
		private DateTime notInGame = DateTime.MinValue;
		internal static List<string> keys = new List<string>() { "Pos", "CurrentSplit", "SplitName", "StartingGame", "IsInGameWorld", "GameState", "CurrentArea", "AbilityCells", "EnergyCells", "CurrentEnergy", "HealthCells", "CurrentHealth", "XPLevel", "GameWorld", "GameplayCamera", "SeinCharacter", "ScenesManager", "GameStateMachine", "WorldEvents", "RainbowDash" };
		private Dictionary<string, string> currentValues = new Dictionary<string, string>();
		private OriSettings settings;
		private LayoutComponent mapDisplay = null;

		public OriComponent(LiveSplitState state) {
			try {
				mem = new OriMemory();
				settings = new OriSettings(this);
				mem.AddLogItems(keys);
				mapDisplay = new LayoutComponent("LiveSplit.OriDE.dll", new OriMapDisplayComponent(mem));
				foreach (string key in keys) {
					currentValues[key] = "";
				}

				if (state != null) {
					Model = new TimerModel() { CurrentState = state };
					state.OnReset += OnReset;
					state.OnPause += OnPause;
					state.OnResume += OnResume;
					state.OnStart += OnStart;
					state.OnSplit += OnSplit;
					state.OnUndoSplit += OnUndoSplit;
					state.OnSkipSplit += OnSkipSplit;
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}

		public void GetValues() {
			if (!mem.HookProcess()) { return; }

			GameState gameState = mem.GetGameState();
			bool isInGame = CheckInGame(gameState);
			bool isInGameWorld = CheckInGameWorld(gameState);
			bool isStartingGame = CheckStartingNewGame(gameState);

			if (!isInGameWorld) {
				notInGame = DateTime.Now;
			}

			LogValues();

			if (settings.RainbowDash && isInGameWorld) {
				mem.ActivateRainbowDash();
			}

			if (Model != null && currentSplit < settings.Splits.Count) {
				bool shouldSplit = false;

				OriSplit split = settings.Splits[currentSplit];
				if (split.Field == "Start Game") {
					shouldSplit = isStartingGame;
				} else if (split.Field == "In Game") {
					shouldSplit = isInGame && notInGame.AddSeconds(1) > DateTime.Now;
				} else if (split.Field == "In Menu") {
					shouldSplit = !isInGame;
				} else if (split.Field == "Hitbox" || split.Field == "End of Forlorn Escape" || split.Field == "End of Horu Escape" || split.Field == "Spirit Tree Reached") {
					HitBox ori = new HitBox(mem.GetCameraTargetPosition(), 0.68f, 1.15f, true);
					HitBox hitBox = new HitBox(split.Value);
					shouldSplit = hitBox.Intersects(ori);
				} else if (isInGameWorld && DateTime.Now.AddSeconds(-1) > notInGame) {
					switch (split.Field) {
						case "Map %":
							decimal map = mem.GetTotalMapCompletion();
							decimal splitMap;
							if (decimal.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMap)) {
								shouldSplit = map >= splitMap;
							}
							break;
						case "Valley 100%":
						case "Grotto 100%":
						case "Swamp 100%":
						case "Ginso 100%":
						case "Forlorn 100%":
						case "Horu 100%":
						case "Glades 100%":
						case "Sorrow 100%":
						case "Black Root 100%":
							string areaName = split.Field.Substring(0, split.Field.Length - 5);
							List<Area> areas = mem.GetMapCompletion();
							for (int i = 0; i < areas.Count; i++) {
								Area area = areas[i];
								if (area.Name.IndexOf(areaName, StringComparison.OrdinalIgnoreCase) >= 0) {
									shouldSplit = area.Progress > (decimal)99.99;
									break;
								}
							}
							break;
						case "Soul Flame":
						case "Spirit Flame":
						case "Wall Jump":
						case "Charge Flame":
						case "Dash":
						case "Double Jump":
						case "Bash":
						case "Stomp":
						case "Light Grenade":
						case "Glide":
						case "Climb":
						case "Charge Jump":
							shouldSplit = mem.GetAbility(split.Field); break;
						case "Ability":
							shouldSplit = mem.GetAbility(split.Value); break;
						case "Mist Lifted":
						case "Clean Water":
						case "Wind Restored":
						case "Gumo Free":
						case "Warmth Returned":
						case "Darkness Lifted":
							shouldSplit = mem.GetEvent(split.Field); break;
						case "Gumon Seal":
						case "Sunstone":
						case "Water Vein":
							shouldSplit = mem.GetKey(split.Field); break;
						case "Ginso Tree Entered":
						case "Forlorn Ruins Entered":
						case "Mount Horu Entered":
						case "End Game":
							List<Scene> scenes = mem.GetScenes();
							for (int i = 0; i < scenes.Count; i++) {
								Scene scene = scenes[i];
								if (scene.State == SceneState.Loaded) {
									switch (scene.Name) {
										case "ginsoEntranceIntro": shouldSplit = split.Field == "Ginso Tree Entered"; break;
										case "forlornRuinsGetNightberry": shouldSplit = split.Field == "Forlorn Ruins Entered"; break;
										case "mountHoruHubMid": shouldSplit = split.Field == "Mount Horu Entered"; break;
									}
								} else if (scene.State == SceneState.Loading) {
									switch (scene.Name) {
										case "creditsScreen": shouldSplit = split.Field == "End Game"; break;
									}
								}
							}
							break;
						case "Health Cells":
							int maxHP = mem.GetCurrentHPMax();
							int splitMaxHP;
							if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMaxHP)) {
								shouldSplit = maxHP >= splitMaxHP;
							}
							break;
						case "Current Health":
							int curHP = mem.GetCurrentHP();
							float splitCurHP;
							if (float.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitCurHP)) {
								shouldSplit = curHP == (int)(splitCurHP * 4);
							}
							break;
						case "Energy Cells":
							float maxEN = mem.GetCurrentENMax();
							int splitMaxEN;
							if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMaxEN)) {
								shouldSplit = maxEN >= splitMaxEN;
							}
							break;
						case "Current Energy":
							float curEN = mem.GetCurrentEN();
							float splitCurEN;
							if (float.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitCurEN)) {
								shouldSplit = Math.Abs(curEN - splitCurEN) < 0.1f;
							}
							break;
						case "Ability Cells":
							int cells = mem.GetAbilityCells();
							int splitCells;
							if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitCells)) {
								shouldSplit = cells >= splitCells;
							}
							break;
						case "Level":
							int lvl = mem.GetCurrentLevel();
							int splitLvl;
							if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitLvl)) {
								shouldSplit = lvl >= splitLvl;
							}
							break;
						case "Key Stones":
							int keystones = mem.GetKeyStones();
							int splitKeys;
							if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitKeys)) {
								shouldSplit = keystones == splitKeys;
							}
							break;
					}
				}
				HandleSplit(shouldSplit, split);
			}
		}
		public bool CheckInGame(GameState state) {
			return state != GameState.Logos && state != GameState.StartScreen && state != GameState.TitleScreen;
		}
		public bool CheckInGameWorld(GameState state) {
			return CheckInGame(state) && state != GameState.Prologue && !mem.IsEnteringGame();
		}
		public bool CheckStartingNewGame(GameState state) {
			return state == GameState.Prologue;
		}
		private void HandleSplit(bool shouldSplit, OriSplit split, bool shouldReset = false) {
			if (currentSplit > 0 && shouldReset) {
				Model.Reset();
			} else if (shouldSplit) {
				if (split.ShouldSplit) {
					if (Model.CurrentState.CurrentPhase == TimerPhase.NotRunning) {
						Model.Start();
					} else {
						Model.Split();
					}
				} else {
					currentSplit++;
				}
			}
		}
		private void LogValues() {
			if (lastLogCheck == 0) {
				hasLog = File.Exists(oriLogPath);
				lastLogCheck = 300;
			}
			lastLogCheck--;

			if (hasLog || !Console.IsOutputRedirected) {
				string prev = "", curr = "";

				GameState gameState = mem.GetGameState();
				bool isInGameWorld = CheckInGameWorld(gameState);
				bool isStartingGame = CheckStartingNewGame(gameState);

				foreach (string key in keys) {
					prev = currentValues[key];

					switch (key) {
						case "StartingGame": curr = isStartingGame.ToString(); break;
						case "IsInGameWorld": curr = isInGameWorld.ToString(); break;
						case "CurrentSplit": curr = currentSplit.ToString(); break;
						case "SplitName": curr = currentSplit < settings.Splits.Count ? settings.Splits[currentSplit].Field + " - " + settings.Splits[currentSplit].Value : ""; break;
						case "GameState": curr = mem.GetGameState().ToString(); break;
						case "GameWorld":
						case "GameplayCamera":
						case "WorldEvents":
						case "SeinCharacter":
						case "ScenesManager":
						case "RainbowDash":
						case "GameStateMachine": curr = mem.GetPointer(key); break;
						default:
							if (isInGameWorld) {
								switch (key) {
									case "AbilityCells": curr = mem.GetAbilityCells().ToString(); break;
									case "EnergyCells": curr = ((int)mem.GetCurrentENMax()).ToString(); break;
									case "CurrentEnergy": curr = mem.GetCurrentEN().ToString("0.00"); break;
									case "HealthCells": curr = mem.GetCurrentHPMax().ToString(); break;
									case "CurrentHealth": curr = mem.GetCurrentHP().ToString(); break;
									case "XPLevel": curr = mem.GetCurrentLevel().ToString(); break;
									case "CurrentArea": curr = mem.GetCurrentArea().Name; break;
									default:
										if (OriMemory.abilities.ContainsKey(key)) {
											curr = mem.GetAbility(key).ToString();
										} else if (OriMemory.events.ContainsKey(key)) {
											curr = mem.GetEvent(key).ToString();
										} else if (OriMemory.keys.ContainsKey(key)) {
											curr = mem.GetKey(key).ToString();
										} else {
											curr = "";
										}
										break;
								}
							} else {
								curr = prev;
							}
							break;
					}
					if (curr == null) { curr = string.Empty; }
					if (!prev.Equals(curr)) {
						WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + (Model != null ? " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) : "") + ": " + key + ": ".PadRight(30 - key.Length < 0 ? 0 : 30 - key.Length, ' ') + (prev.Length > 25 ? prev : prev.PadLeft(25, ' ')) + " -> " + curr);

						currentValues[key] = curr;
					}
				}
			}
		}

		public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) {
			IList<ILayoutComponent> components = lvstate.Layout.LayoutComponents;
			bool hasMapDisplay = false;
			for (int i = components.Count - 1; i >= 0; i--) {
				ILayoutComponent component = components[i];
				if (component.Component is OriMapDisplayComponent) {
					if (!settings.ShowMapDisplay || hasMapDisplay) {
						components.Remove(component);
					}
					hasMapDisplay = true;
				} else if (component.Component is OriComponent && invalidator == null && width == 0 && height == 0) {
					components.Remove(component);

					if (!hasMapDisplay && settings.ShowMapDisplay) {
						components.Insert(i, mapDisplay);
						hasMapDisplay = true;
					}
				}
			}

			if (settings.ShowMapDisplay && !hasMapDisplay) {
				components.Add(mapDisplay);
			}

			GetValues();
		}

		public void OnReset(object sender, TimerPhase e) {
			currentSplit = 0;
			WriteLog("---------Reset----------------------------------");
		}
		public void OnResume(object sender, EventArgs e) {
			WriteLog("---------Resumed--------------------------------");
		}
		public void OnPause(object sender, EventArgs e) {
			WriteLog("---------Paused---------------------------------");
		}
		public void OnStart(object sender, EventArgs e) {
			currentSplit++;
			Model.CurrentState.IsGameTimePaused = true;
			WriteLog("---------New Game-------------------------------");
		}
		public void OnUndoSplit(object sender, EventArgs e) {
			while (currentSplit > 0 && !settings.Splits[--currentSplit].ShouldSplit) { }
			while (currentSplit > 0 && !settings.Splits[currentSplit - 1].ShouldSplit) {
				currentSplit--;
			}
			WriteLog("---------Undo Split-----------------------------");
		}
		public void OnSkipSplit(object sender, EventArgs e) {
			while (currentSplit < settings.Splits.Count && !settings.Splits[currentSplit].ShouldSplit) {
				currentSplit++;
			}
			currentSplit++;
			WriteLog("---------Skip Split-----------------------------");
		}
		public void OnSplit(object sender, EventArgs e) {
			currentSplit++;
			Model.CurrentState.IsGameTimePaused = true;
			WriteLog("---------Split----------------------------------");
		}
		private void WriteLog(string data) {
			if (hasLog || !Console.IsOutputRedirected) {
				if (Console.IsOutputRedirected) {
					using (StreamWriter wr = new StreamWriter(oriLogPath, true)) {
						wr.WriteLine(data);
					}
				} else {
					Console.WriteLine(data);
				}
			}
		}

		public Control GetSettingsControl(LayoutMode mode) { return settings; }
		public void SetSettings(XmlNode doc) {
			settings.SetSettings(doc);
		}
		public XmlNode GetSettings(XmlDocument document) { return settings.UpdateSettings(document); }
		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {
		}
		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
		}
		public float HorizontalWidth => 0;
		public float VerticalHeight => 0;
		public float MinimumHeight => 0;
		public float MinimumWidth => 0;
		public float PaddingTop => 0;
		public float PaddingLeft => 0;
		public float PaddingBottom => 0;
		public float PaddingRight => 0;
		public void Dispose() { }
	}
}