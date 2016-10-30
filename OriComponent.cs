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
		private InfoTextComponent textInfo;
		public IDictionary<string, Action> ContextMenuControls { get { return null; } }
		private OriMemory mem;
		private int currentSplit = 0;
		private bool hasLog = false;
		private int lastLogCheck = 0;
		private DateTime notInGame = DateTime.MinValue;
		internal static List<string> keys = new List<string>() { "Pos", "CurrentSplit", "SplitName", "StartingGame", "IsInGameWorld", "GameState", "CurrentArea", "AbilityCells", "EnergyCells", "CurrentEnergy", "HealthCells", "CurrentHealth", "XPLevel", "GameWorld", "GameplayCamera", "SeinCharacter", "ScenesManager", "GameStateMachine", "WorldEvents", "RainbowDash" };
		private Dictionary<string, string> currentValues = new Dictionary<string, string>();
		private OriSettings settings;

		public OriComponent() {
			try {
				textInfo = new InfoTextComponent("0%", "Swamp 0.00%");
				textInfo.LongestString = "Valley Of The Wind - 100.00%";
				mem = new OriMemory();
				settings = new OriSettings(this);
				mem.AddLogItems(keys);
				foreach (string key in keys) {
					currentValues[key] = "";
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

			if(!isInGameWorld) {
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
				} else if (split.Field == "Hitbox" || split.Field == "End of Forlorn Escape" || split.Field == "End of Horu Escape") {
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
						case "Spirit Tree Reached":
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
			if (Model == null) {
				Model = new TimerModel() { CurrentState = lvstate };
				lvstate.OnReset += OnReset;
				lvstate.OnPause += OnPause;
				lvstate.OnResume += OnResume;
				lvstate.OnStart += OnStart;
				lvstate.OnSplit += OnSplit;
				lvstate.OnUndoSplit += OnUndoSplit;
				lvstate.OnSkipSplit += OnSkipSplit;
			}

			GetValues();

			if (settings.ShowMapDisplay) {
				List<Area> areas = mem.GetMapCompletion();
				decimal total = 0;
				Area currentArea = default(Area);
				for (int i = 0; i < areas.Count; i++) {
					Area area = areas[i];
					total += area.Progress;
					if (area.Current) {
						currentArea = area;
					}
				}
				if (areas.Count > 0) {
					total /= areas.Count;
				}
				textInfo.InformationName = "Total Map: " + total.ToString("0.00") + "%";
				textInfo.InformationValue = currentArea.Name + " - " + currentArea.Progress.ToString("0.00") + "%";
				textInfo.LongestString = "Valley Of The Wind - 100.00%";
				textInfo.Update(invalidator, lvstate, width, height, mode);
				if (invalidator != null) {
					invalidator.Invalidate(0, 0, width, height);
				}
			}
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
			if (settings.ShowMapDisplay) {
				if (state.LayoutSettings.BackgroundColor.ToArgb() != Color.Transparent.ToArgb()) {
					g.FillRectangle(new SolidBrush(state.LayoutSettings.BackgroundColor), 0, 0, width, VerticalHeight);
				}
				PrepareDraw(state, LayoutMode.Vertical);
				textInfo.DrawVertical(g, state, width, clipRegion);
			}
		}
		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
			if (settings.ShowMapDisplay) {
				if (state.LayoutSettings.BackgroundColor.ToArgb() != Color.Transparent.ToArgb()) {
					g.FillRectangle(new SolidBrush(state.LayoutSettings.BackgroundColor), 0, 0, HorizontalWidth, height);
				}
				PrepareDraw(state, LayoutMode.Horizontal);
				textInfo.DrawHorizontal(g, state, height, clipRegion);
			}
		}
		private void PrepareDraw(LiveSplitState state, LayoutMode mode) {
			textInfo.DisplayTwoRows = true;
			textInfo.NameLabel.HasShadow = textInfo.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;
			textInfo.NameLabel.HorizontalAlignment = StringAlignment.Far;
			textInfo.ValueLabel.HorizontalAlignment = StringAlignment.Far;
			textInfo.NameLabel.VerticalAlignment = StringAlignment.Near;
			textInfo.ValueLabel.VerticalAlignment = StringAlignment.Near;
			textInfo.NameLabel.ForeColor = state.LayoutSettings.TextColor;
			textInfo.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
		}
		public float HorizontalWidth {
			get { return settings.ShowMapDisplay ? textInfo.HorizontalWidth : 0; }
		}
		public float VerticalHeight {
			get { return settings.ShowMapDisplay ? textInfo.VerticalHeight : 0; }
		}
		public float MinimumHeight {
			get { return settings.ShowMapDisplay ? textInfo.MinimumHeight : 0; }
		}
		public float MinimumWidth {
			get { return settings.ShowMapDisplay ? textInfo.MinimumWidth : 0; }
		}
		public float PaddingTop { get { return settings.ShowMapDisplay ? textInfo.PaddingTop : 0; } }
		public float PaddingLeft { get { return settings.ShowMapDisplay ? textInfo.PaddingLeft : 0; } }
		public float PaddingBottom { get { return settings.ShowMapDisplay ? textInfo.PaddingBottom : 0; } }
		public float PaddingRight { get { return settings.ShowMapDisplay ? textInfo.PaddingRight : 0; } }
		public void Dispose() { }
	}
}