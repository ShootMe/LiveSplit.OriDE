using System;
using System.IO;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class SaveEditor : Form {
		public SaveGameData Save { get; set; }

		public static SceneID SeinInventory = new SceneID("444B746E7F7A0AE0CC208C40DE7CD9B1");
		public static SceneID PlatformMovement = new SceneID("4AA674A355CA54E9321AEAB78E4E5599");
		public static SceneID SeinLevel = new SceneID("44D72845AB790E021CC526C2EEAC82A5");
		public static SceneID PlayerAbilities = new SceneID("4B417974465D2E6BE06A6D8DBD0F0BB3");
		public static SceneID SeinSoulFlame = new SceneID("4548C1A49142B7E7C26404C530CF0CAC");
		public static SceneID SeinDeathCounter = new SceneID("48B63153499A49ACEFDD874FE2C88CBC");
		public static SceneID GameTimer = new SceneID("454EE3A50EB0CBE41EEF281B35EB93A9");

		public SaveEditor() {
			InitializeComponent();
		}

		public void UpdateInfo() {
			if (Save == null) { return; }

			try {
				SceneData data = Save.Master[SeinLevel];
				txtAP.Text = data.GetInt((int)LevelInfo.AbilityPoints).ToString();
				txtXP.Text = data.GetInt((int)LevelInfo.Experience).ToString();
				txtLvl.Text = data.GetInt((int)LevelInfo.CurrentLevel).ToString();

				txtEN.Text = Save.Energy.ToString();
				txtENMax.Text = Save.MaxEnergy.ToString();

				txtHP.Text = Save.Health.ToString();
				txtHPMax.Text = Save.MaxHealth.ToString();

				data = Save.Master[PlatformMovement];
				txtPosX.Text = data.GetFloat((int)SaveInfo.PosX).ToString("0.0000");
				txtPosY.Text = data.GetFloat((int)SaveInfo.PosY).ToString("0.0000");

				txtVelocityX.Text = data.GetFloat((int)SaveInfo.SpeedX).ToString("0.0000");
				txtVelocityY.Text = data.GetFloat((int)SaveInfo.SpeedY).ToString("0.0000");

				data = Save.Master[PlayerAbilities];
				chkAbilityMarkers.Checked = data[(int)Abilities.AbilityMarkers] == 1;
				chkAirDash.Checked = data[(int)Abilities.AirDash] == 1;
				chkBash.Checked = data[(int)Abilities.Bash] == 1;
				//chkBashBuff.Checked = data[(int)Abilities.BashBuff] == 1;
				chkChargeDash.Checked = data[(int)Abilities.ChargeDash] == 1;
				chkChargeFlame.Checked = data[(int)Abilities.ChargeFlame] == 1;
				chkChargeFlameBlast.Checked = data[(int)Abilities.ChargeFlameBlast] == 1;
				chkChargeFlameBurn.Checked = data[(int)Abilities.ChargeFlameBurn] == 1;
				chkChargeFlameEfficiency.Checked = data[(int)Abilities.ChargeFlameEfficiency] == 1;
				chkChargeJump.Checked = data[(int)Abilities.ChargeJump] == 1;
				chkCinderFlame.Checked = data[(int)Abilities.CinderFlame] == 1;
				chkClimb.Checked = data[(int)Abilities.Climb] == 1;
				chkDash.Checked = data[(int)Abilities.Dash] == 1;
				chkDoubleJump.Checked = data[(int)Abilities.DoubleJump] == 1;
				chkEnergyEfficiency.Checked = data[(int)Abilities.EnergyEfficiency] == 1;
				chkEnergyMarkers.Checked = data[(int)Abilities.EnergyMarkers] == 1;
				chkGlide.Checked = data[(int)Abilities.Glide] == 1;
				chkGrenade.Checked = data[(int)Abilities.Grenade] == 1;
				//chkGrenadeEfficiency.Checked = data[(int)Abilities.GrenadeEfficiency] == 1;
				chkLifeEfficiency.Checked = data[(int)Abilities.HealthEfficiency] == 1;
				chkLifeMarkers.Checked = data[(int)Abilities.HealthMarkers] == 1;
				chkMagnet.Checked = data[(int)Abilities.Magnet] == 1;
				chkMapMarkers.Checked = data[(int)Abilities.MapMarkers] == 1;
				chkQuickFlame.Checked = data[(int)Abilities.QuickFlame] == 1;
				chkRapidFlame.Checked = data[(int)Abilities.RapidFire] == 1;
				chkRegroup.Checked = data[(int)Abilities.Regroup] == 1;
				chkRekindle.Checked = data[(int)Abilities.Rekindle] == 1;
				chkSense.Checked = data[(int)Abilities.Sense] == 1;
				chkSoulLinkEfficiency.Checked = data[(int)Abilities.SoulEfficiency] == 1;
				chkSparkFlame.Checked = data[(int)Abilities.SparkFlame] == 1;
				chkSpiritEfficiency.Checked = data[(int)Abilities.SoulFlameEfficiency] == 1;
				chkSpiritFlame.Checked = data[(int)Abilities.SpiritFlame] == 1;
				chkSplitFlame.Checked = data[(int)Abilities.SplitFlameUpgrade] == 1;
				chkStomp.Checked = data[(int)Abilities.Stomp] == 1;
				chkTripleJump.Checked = data[(int)Abilities.DoubleJumpUpgrade] == 1;
				chkUltraDefense.Checked = data[(int)Abilities.UltraDefense] == 1;
				chkUltraLightBurst.Checked = data[(int)Abilities.GrenadeUpgrade] == 1;
				chkUltraMagnet.Checked = data[(int)Abilities.UltraMagnet] == 1;
				chkUltraSoulLink.Checked = data[(int)Abilities.UltraSoulFlame] == 1;
				chkUltraSplitFlame.Checked = data[(int)Abilities.UltraSplitFlame] == 1;
				chkUltraStomp.Checked = data[(int)Abilities.StompUpgrade] == 1;
				chkWallJump.Checked = data[(int)Abilities.WallJump] == 1;
				chkWaterBreath.Checked = data[(int)Abilities.WaterBreath] == 1;

				data = Save.Master[SeinInventory];
				txtKeystones.Text = data.GetInt((int)InventoryInfo.Keystones).ToString();
				txtMapstones.Text = data.GetInt((int)InventoryInfo.Mapstones).ToString();

				data = Save.Master[SeinSoulFlame];
				bool hasSoulFlame = data[(int)SoulFlameInfo.HasSoulFlame] == 1;
				if (hasSoulFlame) {
					txtSoulX.Text = data.GetFloat((int)SoulFlameInfo.SoulX).ToString("0.0000");
					txtSoulY.Text = data.GetFloat((int)SoulFlameInfo.SoulY).ToString("0.0000");
				} else {
					txtSoulX.Text = string.Empty;
					txtSoulY.Text = string.Empty;
				}

				data = Save.Master[SeinDeathCounter];
				txtDeaths.Text = data.GetInt(0).ToString();

				string currentArea = string.Empty;
				switch (Save.AreaName) {
					case "ginsoTree": currentArea = "Ginso"; break;
					case "sunkenGlades": currentArea = "Glades"; break;
					case "hollowGrove": currentArea = "Grove"; break;
					case "moonGrotto": currentArea = "Grotto"; break;
					case "thornfeltSwamp": currentArea = "Swamp"; break;
					case "mangrove": currentArea = "Blackroot"; break;
					case "mistyWoods": currentArea = "Misty"; break;
					case "sorrowPass": currentArea = "Sorrow"; break;
					case "forlornRuins": currentArea = "Forlorn"; break;
					case "mountHoru": currentArea = "Horu"; break;
					case "valleyOfTheWind": currentArea = "Valley"; break;
				}
				cboArea.Text = currentArea;

				data = Save.Master[GameTimer];
				txtTime.Text = data.GetFloat(0).ToString("0.000");

				this.Text = "Save Editor - " + Path.GetFileNameWithoutExtension(Save.FilePath);
			} catch (Exception ex) {
				MessageBox.Show("Failed to load save: " + ex.ToString());
			}
		}

		private void SaveEditor_Shown(object sender, EventArgs e) {
			UpdateInfo();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			try {
				SceneData data = Save.Master[SeinLevel];
				data.WriteInt((int)LevelInfo.CurrentLevel, int.Parse(txtLvl.Text));
				data.WriteInt((int)LevelInfo.Experience, int.Parse(txtXP.Text));
				data.WriteInt((int)LevelInfo.AbilityPoints, int.Parse(txtAP.Text));

				Save.Energy = int.Parse(txtEN.Text);
				Save.MaxEnergy = int.Parse(txtENMax.Text);
				Save.Health = int.Parse(txtHP.Text);
				Save.MaxHealth = int.Parse(txtHPMax.Text);

				data = Save.Master[PlatformMovement];
				data.WriteFloat((int)SaveInfo.PosX, float.Parse(txtPosX.Text));
				data.WriteFloat((int)SaveInfo.PosY, float.Parse(txtPosY.Text));
				data.WriteFloat((int)SaveInfo.SpeedX, float.Parse(txtVelocityX.Text));
				data.WriteFloat((int)SaveInfo.SpeedY, float.Parse(txtVelocityY.Text));

				data = Save.Master[PlayerAbilities];
				data[(int)Abilities.AbilityMarkers] = (byte)(chkAbilityMarkers.Checked ? 1 : 0);
				data[(int)Abilities.AirDash] = (byte)(chkAirDash.Checked ? 1 : 0);
				data[(int)Abilities.Bash] = (byte)(chkBash.Checked ? 1 : 0);
				//data[(int)Abilities.BashBuff] = (byte)(chkBashBuff.Checked ? 1 : 0);
				data[(int)Abilities.ChargeDash] = (byte)(chkChargeDash.Checked ? 1 : 0);
				data[(int)Abilities.ChargeFlame] = (byte)(chkChargeFlame.Checked ? 1 : 0);
				data[(int)Abilities.ChargeFlameBlast] = (byte)(chkChargeFlameBlast.Checked ? 1 : 0);
				data[(int)Abilities.ChargeFlameBurn] = (byte)(chkChargeFlameBurn.Checked ? 1 : 0);
				data[(int)Abilities.ChargeFlameEfficiency] = (byte)(chkChargeFlameEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.ChargeJump] = (byte)(chkChargeJump.Checked ? 1 : 0);
				data[(int)Abilities.CinderFlame] = (byte)(chkCinderFlame.Checked ? 1 : 0);
				data[(int)Abilities.Climb] = (byte)(chkClimb.Checked ? 1 : 0);
				data[(int)Abilities.Dash] = (byte)(chkDash.Checked ? 1 : 0);
				data[(int)Abilities.DoubleJump] = (byte)(chkDoubleJump.Checked ? 1 : 0);
				data[(int)Abilities.EnergyEfficiency] = (byte)(chkEnergyEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.EnergyMarkers] = (byte)(chkEnergyMarkers.Checked ? 1 : 0);
				data[(int)Abilities.Glide] = (byte)(chkGlide.Checked ? 1 : 0);
				data[(int)Abilities.Grenade] = (byte)(chkGrenade.Checked ? 1 : 0);
				//data[(int)Abilities.GrenadeEfficency] = (byte)(chkGrenadeEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.HealthEfficiency] = (byte)(chkLifeEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.HealthMarkers] = (byte)(chkLifeMarkers.Checked ? 1 : 0);
				data[(int)Abilities.Magnet] = (byte)(chkMagnet.Checked ? 1 : 0);
				data[(int)Abilities.MapMarkers] = (byte)(chkMapMarkers.Checked ? 1 : 0);
				data[(int)Abilities.QuickFlame] = (byte)(chkQuickFlame.Checked ? 1 : 0);
				data[(int)Abilities.RapidFire] = (byte)(chkRapidFlame.Checked ? 1 : 0);
				data[(int)Abilities.Regroup] = (byte)(chkRegroup.Checked ? 1 : 0);
				data[(int)Abilities.Rekindle] = (byte)(chkRekindle.Checked ? 1 : 0);
				data[(int)Abilities.Sense] = (byte)(chkSense.Checked ? 1 : 0);
				data[(int)Abilities.SoulEfficiency] = (byte)(chkSoulLinkEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.SparkFlame] = (byte)(chkSparkFlame.Checked ? 1 : 0);
				data[(int)Abilities.SoulFlameEfficiency] = (byte)(chkSpiritEfficiency.Checked ? 1 : 0);
				data[(int)Abilities.SpiritFlame] = (byte)(chkSpiritFlame.Checked ? 1 : 0);
				data[(int)Abilities.SplitFlameUpgrade] = (byte)(chkSplitFlame.Checked ? 1 : 0);
				data[(int)Abilities.Stomp] = (byte)(chkStomp.Checked ? 1 : 0);
				data[(int)Abilities.DoubleJumpUpgrade] = (byte)(chkTripleJump.Checked ? 1 : 0);
				data[(int)Abilities.UltraDefense] = (byte)(chkUltraDefense.Checked ? 1 : 0);
				data[(int)Abilities.GrenadeUpgrade] = (byte)(chkUltraLightBurst.Checked ? 1 : 0);
				data[(int)Abilities.UltraMagnet] = (byte)(chkUltraMagnet.Checked ? 1 : 0);
				data[(int)Abilities.UltraSoulFlame] = (byte)(chkUltraSoulLink.Checked ? 1 : 0);
				data[(int)Abilities.UltraSplitFlame] = (byte)(chkUltraSplitFlame.Checked ? 1 : 0);
				data[(int)Abilities.StompUpgrade] = (byte)(chkUltraStomp.Checked ? 1 : 0);
				data[(int)Abilities.WallJump] = (byte)(chkWallJump.Checked ? 1 : 0);
				data[(int)Abilities.WaterBreath] = (byte)(chkWaterBreath.Checked ? 1 : 0);

				data = Save.Master[SeinInventory];
				data.WriteInt((int)InventoryInfo.Keystones, int.Parse(txtKeystones.Text));
				data.WriteInt((int)InventoryInfo.Mapstones, int.Parse(txtMapstones.Text));

				data = Save.Master[SeinSoulFlame];
				bool hasSoulFlame = !string.IsNullOrEmpty(txtSoulX.Text);
				if (hasSoulFlame) {
					if (data.Data.Length <= 31) {
						byte[] newData = new byte[43];
						Array.Copy(data.Data, newData, 31);
						data.Data = newData;
					}
					data[(int)SoulFlameInfo.HasSoulFlame] = 1;
					data.WriteFloat((int)SoulFlameInfo.SoulX, float.Parse(txtSoulX.Text));
					data.WriteFloat((int)SoulFlameInfo.SoulY, float.Parse(txtSoulY.Text));
				} else {
					if (data.Data.Length > 31) {
						byte[] newData = new byte[31];
						Array.Copy(data.Data, newData, 31);
						data.Data = newData;
					}
					data[(int)SoulFlameInfo.HasSoulFlame] = 0;
				}

				data = Save.Master[SeinDeathCounter];
				int deaths = int.Parse(txtDeaths.Text);
				data.WriteInt(0, deaths);
				if (Save.Difficulty == DifficultyMode.OneLife) {
					Save.WasKilled = deaths > 0;
				}

				string currentArea = string.Empty;
				switch (cboArea.Text) {
					case "Ginso": currentArea = "ginsoTree"; break;
					case "Glades": currentArea = "sunkenGlades"; break;
					case "Grove": currentArea = "hollowGrove"; break;
					case "Grotto": currentArea = "moonGrotto"; break;
					case "Swamp": currentArea = "thornfeltSwamp"; break;
					case "Blackroot": currentArea = "mangrove"; break;
					case "Misty": currentArea = "mistyWoods"; break;
					case "Sorrow": currentArea = "sorrowPass"; break;
					case "Forlorn": currentArea = "forlornRuins"; break;
					case "Horu": currentArea = "mountHoru"; break;
					case "Valley": currentArea = "valleyOfTheWind"; break;
				}
				if (!string.IsNullOrEmpty(currentArea)) {
					Save.AreaName = currentArea;
				}

				float totalSeconds = float.Parse(txtTime.Text);
				int totalSecs = (int)totalSeconds;
				Save.Hours = totalSecs / 3600;
				Save.Minutes = (totalSecs - Save.Hours * 3600) / 60;
				Save.Seconds = (totalSecs - Save.Hours * 3600 - Save.Minutes * 60);

				data = Save.Master[GameTimer];
				data.WriteFloat(0, totalSeconds);

				Save.Save(Save.FilePath);
				this.Close();
			} catch (Exception ex) {
				MessageBox.Show("Failed to save file: " + ex.ToString());
			}
		}
		private void btnDelete_Click(object sender, EventArgs e) {
			try {
				if (File.Exists(Save.FilePath)) {
					File.Delete(Save.FilePath);
				}
				this.Close();
			} catch (Exception ex) {
				MessageBox.Show("Failed to delete save: " + ex.ToString());
			}
		}
		private void btnAll_Click(object sender, EventArgs e) {
			foreach (Control c in this.Controls) {
				CheckBox chk = c as CheckBox;
				if (chk != null) {
					chk.Checked = true;
				}
			}
		}
		private void btnNone_Click(object sender, EventArgs e) {
			foreach (Control c in this.Controls) {
				CheckBox chk = c as CheckBox;
				if (chk != null) {
					chk.Checked = false;
				}
			}
		}
	}
}