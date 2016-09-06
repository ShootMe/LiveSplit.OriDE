﻿using LiveSplit.OriDE.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class OriManager : Form {
		public OriMemory Memory { get; set; }
		private bool useLivesplitColors = true, extraFast = false, goingFast = false;
		private KeyboardHook kbHook;
		public OriManager() {
			kbHook = new KeyboardHook(KeyboardHook.Parameters.PassAllKeysToNextApp);
			kbHook.KeyIntercepted += KeyhookPress;
			InitializeComponent();
			Memory = new OriMemory();
			Thread t = new Thread(UpdateLoop);
			t.IsBackground = true;
			t.Start();
		}
		~OriManager() {
			kbHook.Dispose();
		}

		private void KeyhookPress(KeyboardHook.KeyboardHookEventArgs e) {
			if (Memory != null && Memory.Program != null) {
				int state = Memory.GetTASState();
				if ((state & 1) != 0) {
					Memory.SetTASCharacter((byte)((byte)e.KeyCode & 127));
				}
			}
		}

		private void OriManager_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.L) {
				useLivesplitColors = !useLivesplitColors;
				if (useLivesplitColors) {
					this.BackColor = Color.White;
					this.ForeColor = Color.Black;
				} else {
					this.BackColor = Color.Black;
					this.ForeColor = Color.White;
				}
			} else if (e.Control && e.KeyCode == Keys.F) {
				extraFast = !extraFast;
			} else if(e.Control && e.KeyCode == Keys.T) {
				if(this.Width == 600) {
					this.Width = 380;
					this.Height = 175;
					lblCurrentInput.Visible = false;
					lblNextInput.Visible = false;
					lblTASStates.Visible = false;
				} else {
					this.Width = 600;
					this.Height = 235;
					lblCurrentInput.Visible = true;
					lblNextInput.Visible = true;
					lblTASStates.Visible = true;
				}
			}
		}

		private void UpdateLoop() {
			bool lastHooked = false;
			while (true) {
				try {
					bool hooked = Memory.HookProcess();
					if (hooked) {
						UpdateValues();
					}
					if (lastHooked != hooked) {
						lastHooked = hooked;
						this.Invoke((Action)delegate () { lblNote.Visible = !hooked; });
					}
					Thread.Sleep(12);
				} catch { }
			}
		}
		public void UpdateValues() {
			if (this.InvokeRequired) {
				this.Invoke((Action)UpdateValues);
			} else {
				bool tasEnabled = this.Width == 600 || (Memory.GetTASState() & 1) != 0;
				if (this.Width < 600 && tasEnabled) {
					this.Width = 600;
					this.Height = 235;
					lblCurrentInput.Visible = true;
					lblNextInput.Visible = true;
					lblTASStates.Visible = true;
				} else if(tasEnabled) {
					lblCurrentInput.Text = Memory.GetTASCurrentInput();
					lblNextInput.Text = Memory.GetTASNextInput();
					lblTASStates.Text = Memory.GetTASExtraInfo();
				}
				GameState gameState = Memory.GetGameState();
				bool isInGameWorld = CheckInGameWorld(gameState);
				bool isStartingGame = CheckStartingNewGame(gameState);
				PointF currentSpeed = Memory.CurrentSpeed();
				PointF pos = Memory.GetCameraTargetPosition();
				HitBox ori = new HitBox(pos, 0.68f, 1.15f, true);
				HitBox hitBox = new HitBox("145,580,20,40");
				HitBox hitBox2 = new HitBox("170,580,130,140");
				bool inFinal = hitBox.Intersects(ori) || hitBox2.Intersects(ori);

				if (extraFast && Math.Abs(Memory.WaterSpeed() - 9f) > 0.1f && !inFinal) {
					goingFast = true;
					Memory.SetSpeed(24f, 85f, 39f, 12f, 70f, 70f, 9f, 60f, 200f, 5f, 16f, 90f, 180f);
				} else if ((!extraFast || inFinal) && goingFast) {
					goingFast = false;
					Memory.SetSpeed(11.6667f, 60f, 26f, 6f, 56.568f, 40f, 6f, 38f, 100f, 3f, 8f, 50f, 100f);
				}

				List<Area> areas = Memory.GetMapCompletion();
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

				lblArea.Text = "Area: " + (string.IsNullOrEmpty(currentArea.Name) ? "N/A" : currentArea.Name + " - " + currentArea.Progress.ToString("0.00") + "%");
				lblMap.Text = "Total: " + total.ToString("0.00") + "%";
				lblPos.Text = "Pos: " + pos.X.ToString("0.00") + ", " + pos.Y.ToString("0.00");
				lblSpeed.Text = (extraFast ? "Insane Speed: " : "Speed: ") + currentSpeed.X.ToString("0.00") + ", " + currentSpeed.Y.ToString("0.00") + " (" + Math.Sqrt(currentSpeed.X * currentSpeed.X + currentSpeed.Y * currentSpeed.Y).ToString("0.00") + ")";
				PointF cursor = Memory.GetCursorPosition();
				lblCursorPosition.Text = "Cursor: " + cursor.X.ToString("0.000") + ", " + cursor.Y.ToString("0.000");

				if (isInGameWorld) {
					int level = Memory.GetCurrentLevel();
					int xp = Memory.GetExperience();
					lblLevel.Text = "Level: " + level.ToString();
					lblHP.Text = "HP: " + ((double)Memory.GetCurrentHP() / 4).ToString("0.##") + " / " + Memory.GetCurrentHPMax().ToString();
					lblEN.Text = "EN: " + Memory.GetCurrentEN().ToString("0.##") + " / " + ((int)Memory.GetCurrentENMax()).ToString();
					lblAbility.Text = "Ability: " + Memory.GetAbilityCells().ToString() + " / 33";
					lblXP.Text = "XP: " + xp.ToString() + " / " + GetXP(level);
					lblKeys.Text = "Keys: " + Memory.GetKeyStones();
				} else {
					lblLevel.Text = "Level: N/A";
					lblHP.Text = "HP: N/A";
					lblEN.Text = "EN: N/A";
					lblAbility.Text = "Ability: N/A";
					lblXP.Text = "XP: N/A";
					lblKeys.Text = "Keys: N/A";
				}
			}
		}
		public bool CheckInGame(GameState state) {
			return state != GameState.Logos && state != GameState.StartScreen && state != GameState.TitleScreen;
		}
		public bool CheckInGameWorld(GameState state) {
			return CheckInGame(state) && state != GameState.Prologue && !Memory.IsEnteringGame();
		}
		public bool CheckStartingNewGame(GameState state) {
			return state == GameState.Prologue;
		}
		public int GetXP(int level) {
			switch (level) {
				case 0: return 25;
				case 1: return 50;
				case 2: return 100;
				case 3: return 175;
				case 4: return 275;
			}
			if (level < 20) {
				return (level - 1) * 100;
			} else if (level < 23) {
				return (level - 18) * 1000;
			} else if (level < 51) {
				return (int)(4000 + Math.Round(((double)(level - 22) * 1500) / 7, 0, MidpointRounding.AwayFromZero));
			}
			return 10000;
		}
	}
}