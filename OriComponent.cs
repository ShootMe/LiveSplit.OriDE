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
		private int state = 0;
		private bool hasLog = false;
		private int lastLogCheck = 0;
		internal static string[] keys = { "CurrentSplit", "State" };
		private Dictionary<string, string> currentValues = new Dictionary<string, string>();
		private OriSettings settings;

		public OriComponent() {
			try {
				textInfo = new InfoTextComponent("0%", "Swamp 0.00%");
				textInfo.LongestString = "Valley Of The Wind - 100.00%";
				mem = new OriMemory();
				settings = new OriSettings(this);
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

			if (Model != null && currentSplit < settings.Splits.Count) {
				bool shouldSplit = false;

				OriSplit split = settings.Splits[currentSplit];
				switch (split.Field) {
					case "In Game": shouldSplit = isInGame; break;
					case "In Menu": shouldSplit = !isInGame; break;
					case "Map %":
						decimal map = mem.GetTotalMapCompletion();
						decimal splitMap;
						if (decimal.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMap)) {
							shouldSplit = map >= splitMap;
						}
						break;
					case "End of Forlorn Escape":
					case "End of Horu Escape":
					case "Hitbox":
						HitBox ori = new HitBox(mem.GetCameraTargetPosition(), 0.68f, 1.15f, true);
						HitBox hitBox = new HitBox(split.Value);
						shouldSplit = hitBox.Intersects(ori);
						break;
					case "Start Game":
						shouldSplit = state == 0 && isStartingGame;
						if (isStartingGame) { state = 1; }
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
						Dictionary<string, bool> abilities = mem.GetAbilities();
						shouldSplit = abilities[split.Field]; break;
					case "Mist Lifted":
					case "Clean Water":
					case "Wind Restored":
					case "Gumo Free":
					case "Spirit Tree Reached":
					case "Warmth Returned":
					case "Darkness Lifted":
						Dictionary<string, bool> events = mem.GetEvents();
						shouldSplit = events[split.Field]; break;
					case "Gumon Seal":
					case "Sunstone":
					case "Water Vein":
						Dictionary<string, bool> keys = mem.GetKeys();
						shouldSplit = keys[split.Field]; break;
					case "Ginso Tree Entered":
					case "Forlorn Ruins Entered":
					case "Mount Horu Entered":
					case "End Game":
						Scene[] scenes = mem.GetScenes();
						for (int i = 0; i < scenes.Length; i++) {
							Scene scene = scenes[i];
							if (scene.state == SceneState.Loaded) {
								switch (scene.name) {
									case "ginsoEntranceIntro": shouldSplit = split.Field == "Ginso Tree Entered"; break;
									case "forlornRuinsGetNightberry": shouldSplit = split.Field == "Forlorn Ruins Entered"; break;
									case "mountHoruHubMid": shouldSplit = split.Field == "Mount Horu Entered"; break;
								}
							} else if (scene.state == SceneState.Loading) {
								switch (scene.name) {
									case "creditsScreen": shouldSplit = split.Field == "End Game"; break;
								}
							}
						}
						break;
					case "Health Cells":
						int maxHP = mem.GetCurrentHPMax() / 4;
						int splitMaxHP;
						if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMaxHP)) {
							shouldSplit = maxHP >= splitMaxHP;
						}
						break;
					case "Energy Cells":
						float maxEN = mem.GetCurrentENMax();
						int splitMaxEN;
						if (int.TryParse(split.Value, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out splitMaxEN)) {
							shouldSplit = maxEN >= splitMaxEN;
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

				HandleSplit(shouldSplit);
			}

			LogValues();
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
		private void HandleSplit(bool shouldSplit, bool shouldReset = false) {
			if (currentSplit > 0 && shouldReset) {
				Model.Reset();
			} else if (shouldSplit) {
				if (currentSplit == 0) {
					Model.Start();
				} else {
					Model.Split();
				}
			}
		}
		private void LogValues() {
			if (lastLogCheck == 0) {
				hasLog = File.Exists(oriLogPath);
				lastLogCheck = 300;
			}
			lastLogCheck--;

			if (hasLog) {
				string prev = "", curr = "";
				foreach (string key in keys) {
					prev = currentValues[key];

					switch (key) {
						case "CurrentSplit": curr = currentSplit.ToString(); break;
						case "State": curr = state.ToString(); break;
						default: curr = ""; break;
					}

					if (!prev.Equals(curr)) {
						WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + (Model != null ? " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) : "") + ": " + key + ": ".PadRight(16 - key.Length, ' ') + prev.PadLeft(25, ' ') + " -> " + curr);

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
				textInfo.InformationName = "Total Map: " + 0.ToString("0.00") + "%";
				textInfo.InformationValue = "Valley".ToString();
				textInfo.LongestString = "Valley Of The Wind - 100.00%";
				textInfo.Update(invalidator, lvstate, width, height, mode);
				if (invalidator != null) {
					invalidator.Invalidate(0, 0, width, height);
				}
			}
		}

		public void OnReset(object sender, TimerPhase e) {
			currentSplit = 0;
			state = 0;
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
			state = 0;
			Model.CurrentState.IsGameTimePaused = true;
			WriteLog("---------New Game-------------------------------");
		}
		public void OnUndoSplit(object sender, EventArgs e) {
			currentSplit--;
			state = 0;
			WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) + ": CurrentSplit: " + currentSplit.ToString().PadLeft(24, ' '));
		}
		public void OnSkipSplit(object sender, EventArgs e) {
			currentSplit++;
			state = 0;
			WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) + ": CurrentSplit: " + currentSplit.ToString().PadLeft(24, ' '));
		}
		public void OnSplit(object sender, EventArgs e) {
			currentSplit++;
			state = 0;
			Model.CurrentState.IsGameTimePaused = true;
			WriteLog(DateTime.Now.ToString(@"HH\:mm\:ss.fff") + " | " + Model.CurrentState.CurrentTime.RealTime.Value.ToString("G").Substring(3, 11) + ": CurrentSplit: " + currentSplit.ToString().PadLeft(24, ' '));
		}
		private void WriteLog(string data) {
			if (hasLog) {
				Console.WriteLine(data);
				using (StreamWriter wr = new StreamWriter(oriLogPath, true)) {
					wr.WriteLine(data);
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