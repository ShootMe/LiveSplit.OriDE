﻿using LiveSplit.OriDE.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class OriManager : Form {
		public OriMemory Memory { get; set; }
		public OriComponent Component { get; set; }
		private bool useLivesplitColors = true;
		public OriManager() {
			InitializeComponent();
			Visible = false;
			Thread t = new Thread(UpdateLoop);
			t.IsBackground = true;
			t.Start();
		}

		private void OriManager_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = Memory != null;
		}
		private void OriManager_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.L) {
				useLivesplitColors = !useLivesplitColors;
			}
		}

		private void UpdateLoop() {
			while (true) {
				try {
					UpdateValues();
					Thread.Sleep(33);
				} catch { }
			}
		}
		public Color ToRGB(Color c) {
			return Color.FromArgb((255 << 24) | (c.R << 16) | (c.G << 8) | c.B);
		}
		public void UpdateValues() {
			if (this.InvokeRequired) {
				this.Invoke((Action)UpdateValues);
			} else if (this.Visible && Memory != null && Memory.IsHooked) {
				if (useLivesplitColors && Component != null && Component.Model != null) {
					if (ToRGB(Component.Model.CurrentState.LayoutSettings.BackgroundColor) != this.BackColor) {
						this.BackColor = ToRGB(Component.Model.CurrentState.LayoutSettings.BackgroundColor);
					}
					if (ToRGB(Component.Model.CurrentState.LayoutSettings.TextColor) != this.ForeColor) {
						this.ForeColor = ToRGB(Component.Model.CurrentState.LayoutSettings.TextColor);
					}
				} else if (this.BackColor != Color.White) {
					this.BackColor = Color.White;
					this.ForeColor = Color.Black;
				}
				GameState gameState = Memory.GetGameState();
				bool isInGameWorld = Component.CheckInGameWorld(gameState);
				bool isStartingGame = Component.CheckStartingNewGame(gameState);

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

				PointF pos = Memory.GetCameraTargetPosition();

				lblArea.Text = "Area: " + (string.IsNullOrEmpty(currentArea.Name) ? "N/A" : currentArea.Name + " - " + currentArea.Progress.ToString("0.00") + "%");
				lblMap.Text = "Total: " + total.ToString("0.00") + "%";
				lblPos.Text = "Pos: " + pos.X.ToString("0.00") + ", " + pos.Y.ToString("0.00");

				if (isInGameWorld) {
					int level = Memory.GetCurrentLevel();
					int xp = Memory.GetExperience();
					lblLevel.Text = "Level: " + level.ToString();
					lblHP.Text = "HP: " + ((double)Memory.GetCurrentHP() / 4).ToString("0.##") + " / " + Memory.GetCurrentHPMax().ToString();
					lblEN.Text = "EN: " + Memory.GetCurrentEN().ToString("0.##") + " / " + ((int)Memory.GetCurrentENMax()).ToString();
					lblAbility.Text = "Ability: " + Memory.GetAbilityCells().ToString() + " / 33";
					lblXP.Text = "XP: " + xp.ToString() + " / " + GetXP(level);
				} else {
					lblLevel.Text = "Level: N/A";
					lblHP.Text = "HP: N/A";
					lblEN.Text = "EN: N/A";
					lblAbility.Text = "Ability: N/A";
					lblXP.Text = "XP: N/A";
				}
			} else if (Memory == null && this.Visible) {
				this.Hide();
			}
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