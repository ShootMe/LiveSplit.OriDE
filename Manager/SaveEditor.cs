using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class SaveEditor : Form {
		public SaveGameData Save { get; set; }

		public SaveEditor() {
			InitializeComponent();

			Assembly asm = Assembly.GetExecutingAssembly();
			Stream file = asm.GetManifestResourceStream("LiveSplit.OriDE.Images.kuroBG.png");
			if (file != null) {
				this.BackgroundImage = Image.FromStream(file);
			}
		}

		public void UpdateInfo() {
			if (Save == null) { return; }

			try {
				SceneData data = Save.Master[MasterAssets.SeinLevel];
				txtAP.Text = data?.GetInt((int)LevelInfo.AbilityPoints).ToString();
				txtXP.Text = data?.GetInt((int)LevelInfo.Experience).ToString();
				txtLvl.Text = data?.GetInt((int)LevelInfo.CurrentLevel).ToString();

				data = Save.Master[MasterAssets.SeinEnergyInfo];
				txtEN.Text = data?.GetFloat((int)SeinEnergy.Current).ToString("0.##");
				txtENMax.Text = data?.GetFloat((int)SeinEnergy.Max).ToString("0.##");

				data = Save.Master[MasterAssets.SeinHealthInfo];
				txtHP.Text = ((data?.GetFloat((int)SeinHealthController.Amount)).GetValueOrDefault(0) / 4f).ToString("0.##");
				txtHPMax.Text = ((data?.GetInt((int)SeinHealthController.MaxHealth)).GetValueOrDefault(0) / 4).ToString();

				data = Save.Master[MasterAssets.PlatformMovement];
				txtPosX.Text = data?.GetFloat((int)SaveInfo.PosX).ToString();
				txtPosY.Text = data?.GetFloat((int)SaveInfo.PosY).ToString();

				txtVelocityX.Text = data?.GetFloat((int)SaveInfo.SpeedX).ToString();
				txtVelocityY.Text = data?.GetFloat((int)SaveInfo.SpeedY).ToString();

				data = Save.Master[MasterAssets.PlayerAbilities];
				if (data != null) {
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
				}

				data = Save.Master[MasterAssets.SeinInventory];
				txtKeystones.Text = data?.GetInt((int)InventoryInfo.Keystones).ToString();
				txtMapstones.Text = data?.GetInt((int)InventoryInfo.Mapstones).ToString();

				data = Save.Master[MasterAssets.SeinSoulFlame];
				bool hasSoulFlame = data != null && data[(int)SoulFlameInfo.HasSoulFlame] == 1;
				if (hasSoulFlame) {
					txtSoulX.Text = data.GetFloat((int)SoulFlameInfo.SoulX).ToString();
					txtSoulY.Text = data.GetFloat((int)SoulFlameInfo.SoulY).ToString();
				} else {
					txtSoulX.Text = string.Empty;
					txtSoulY.Text = string.Empty;
				}

				data = Save.Master[MasterAssets.SeinDeathCounter];
				txtDeaths.Text = data?.GetInt(0).ToString();

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

				data = Save.Master[MasterAssets.GameTimer];
				txtTime.Text = data?.GetFloat(0).ToString("0.000");

				data = Save.Master[MasterAssets.SavePedestals];
				chkBlackRoot.Checked = data[(int)Pedestals.BlackRoot] == 1;
				chkForlornRuins.Checked = data[(int)Pedestals.Forlorn] == 1;
				chkGinso.Checked = data[(int)Pedestals.GinsoTree] == 1;
				chkGrotto.Checked = data[(int)Pedestals.Grotto] == 1;
				chkHollowGrove.Checked = data[(int)Pedestals.HollowGrove] == 1;
				chkHoruFields.Checked = data[(int)Pedestals.HoruFields] == 1;
				chkLostGrove.Checked = data[(int)Pedestals.LostGrove] == 1;
				chkMountHoru.Checked = data[(int)Pedestals.MountHoru] == 1;
				chkSorrowPass.Checked = data[(int)Pedestals.SorrowPass] == 1;
				chkSunkenGlades.Checked = data[(int)Pedestals.SunkenGlades] == 1;
				chkSwamp.Checked = data[(int)Pedestals.Swamp] == 1;
				chkValleyOfTheWind.Checked = data[(int)Pedestals.Valley] == 1;

				data = Save.Master[MasterAssets.WorldEvents];
				chkCleanWater.Checked = data[(int)WorldEvents.CleanWater] == 1;
				chkDarknessLifted.Checked = data[(int)WorldEvents.DarknessLifted] == 1;
				chkForlornKey.Checked = data[(int)WorldEvents.ForlornRuinsKey] == 1;
				chkGinsoEntered.Checked = data[(int)WorldEvents.GinsoTreeEntered] == 1;
				chkGinsoKey.Checked = data[(int)WorldEvents.GinsoTreeKey] == 1;
				chkGravityActivated.Checked = data[(int)WorldEvents.GravityActivated] == 1;
				chkGumoFree.Checked = data[(int)WorldEvents.GumoFree] == 1;
				chkMistLifted.Checked = data[(int)WorldEvents.MistLifted] == 1;
				chkHoruKey.Checked = data[(int)WorldEvents.MountHoruKey] == 1;
				chkSpiritTree.Checked = data[(int)WorldEvents.SpiritTreeReached] == 1;
				chkWarmth.Checked = data[(int)WorldEvents.WarmthReturned] == 1;
				chkWindRestored.Checked = data[(int)WorldEvents.WindRestored] == 1;

				treeObjects.SuspendLayout();
				Type[] types = typeof(SceneID).Assembly.GetTypes();
				for (int i = 0; i < types.Length; i++) {
					Type asmType = types[i];
					if (asmType != typeof(SceneID) && asmType != typeof(MasterAssets) && typeof(SceneID).IsAssignableFrom(asmType)) {
						TreeNode parentNode = treeObjects.Nodes.Add(asmType.Name);

						FieldInfo[] fields = asmType.GetFields(BindingFlags.Static | BindingFlags.Public);
						for (int j = 0; j < fields.Length; j++) {
							string fieldName = fields[j].Name;
							TreeNode childNode = new TreeNode(fieldName);
							SceneID sceneValue = (SceneID)fields[j].GetValue(null);
							childNode.Tag = sceneValue;

							data = Save.Find(sceneValue);
							if (data != null) {
								if (fieldName.IndexOf("Animator") >= 0) {
									if (data.GetFloat(0) == 0) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("Creep") >= 0 || fieldName.IndexOf("Wall") >= 0 || fieldName.IndexOf("Stompable") >= 0 || fieldName.IndexOf("Bulb") >= 0 ||
									  fieldName.IndexOf("Bombable") >= 0 || fieldName.IndexOf("Breakable") >= 0 || fieldName.IndexOf("PetrifiedPlant") >= 0) {
									if (data.GetFloat((int)EntityDamage.Health) > 0) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("Keystone") >= 0 || fieldName.IndexOf("Mapstone") >= 0 || fieldName.IndexOf("Pickup") >= 0) {
									if (data[(int)Pickup.Collected] == 0) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("AbilityCell") >= 0 || fieldName.IndexOf("HealthCell") >= 0 || fieldName.IndexOf("EnergyCell") >= 0 || fieldName.IndexOf("ExpOrb") >= 0) {
									if (data[(int)Collectible.Collected] == 0) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("DoorWith") >= 0 || fieldName.IndexOf("EnergyDoor") >= 0) {
									if (data.GetInt((int)Door.CurrentState) != 2) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("Trigger") >= 0 || fieldName.IndexOf("Restrict") >= 0) {
									if (data[0] == 1) {
										childNode.Checked = true;
									}
								} else if (fieldName.IndexOf("Torch") >= 0) {
									if (data[0] == 0) {
										childNode.Checked = true;
									}
								}
							} else {
								childNode.Checked = true;
							}
							parentNode.Nodes.Add(childNode);
						}
					}
				}
				treeObjects.ExpandAll();
				treeObjects.ResumeLayout(true);
				treeObjects.SelectedNode = treeObjects.Nodes[0];

				this.Text = "Save Editor - " + Path.GetFileNameWithoutExtension(Save.FilePath);
			} catch (Exception ex) {
				MessageBox.Show(this, "Failed to load save: " + ex.ToString());
			}
		}

		private void SaveEditor_Shown(object sender, EventArgs e) {
			SuspendUpdate.Suspend(this);
			UpdateInfo();
			SuspendUpdate.Resume(this);
		}

		private void btnSave_Click(object sender, EventArgs e) {
			try {
				SceneData data = Save.Master[MasterAssets.SeinLevel];
				data.WriteInt((int)LevelInfo.CurrentLevel, int.Parse(txtLvl.Text));
				data.WriteInt((int)LevelInfo.Experience, int.Parse(txtXP.Text));
				data.WriteInt((int)LevelInfo.AbilityPoints, int.Parse(txtAP.Text));

				data = Save.Master[MasterAssets.SeinEnergyInfo];
				data.WriteFloat((int)SeinEnergy.Current, float.Parse(txtEN.Text));
				data.WriteFloat((int)SeinEnergy.Max, int.Parse(txtENMax.Text));
				Save.Energy = (int)float.Parse(txtEN.Text);
				Save.MaxEnergy = int.Parse(txtENMax.Text);

				data = Save.Master[MasterAssets.SeinHealthInfo];
				data.WriteFloat((int)SeinHealthController.Amount, float.Parse(txtHP.Text) * 4f);
				data.WriteInt((int)SeinHealthController.MaxHealth, int.Parse(txtHPMax.Text) * 4);
				Save.Health = (int)float.Parse(txtHP.Text);
				Save.MaxHealth = int.Parse(txtHPMax.Text);

				data = Save.Master[MasterAssets.PlatformMovement];
				data.WriteFloat((int)SaveInfo.PosX, float.Parse(txtPosX.Text));
				data.WriteFloat((int)SaveInfo.PosY, float.Parse(txtPosY.Text));
				data.WriteFloat((int)SaveInfo.SpeedX, float.Parse(txtVelocityX.Text));
				data.WriteFloat((int)SaveInfo.SpeedY, float.Parse(txtVelocityY.Text));

				data = Save.Master[MasterAssets.PlayerAbilities];
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

				int pointsUsed = (chkQuickFlame.Checked ? 1 : 0) + (chkSparkFlame.Checked ? 1 : 0) + (chkChargeFlameBurn.Checked ? 1 : 0) + (chkSplitFlame.Checked ? 1 : 0) +
					(chkUltraLightBurst.Checked ? 2 : 0) + (chkCinderFlame.Checked ? 2 : 0) + (chkUltraStomp.Checked ? 2 : 0) + (chkRapidFlame.Checked ? 2 : 0) +
					(chkChargeFlameBlast.Checked ? 3 : 0) + (chkUltraSplitFlame.Checked ? 3 : 0) + (chkMagnet.Checked ? 1 : 0) + (chkMapMarkers.Checked ? 1 : 0) +
					(chkLifeEfficiency.Checked ? 1 : 0) + (chkUltraMagnet.Checked ? 1 : 0) + (chkEnergyEfficiency.Checked ? 2 : 0) + (chkAbilityMarkers.Checked ? 2 : 0) +
					(chkSpiritEfficiency.Checked ? 2 : 0) + (chkLifeMarkers.Checked ? 2 : 0) + (chkEnergyMarkers.Checked ? 2 : 0) + (chkSense.Checked ? 3 : 0) +
					(chkRekindle.Checked ? 1 : 0) + (chkRegroup.Checked ? 1 : 0) + (chkChargeFlameEfficiency.Checked ? 1 : 0) + (chkAirDash.Checked ? 2 : 0) +
					(chkUltraSoulLink.Checked ? 2 : 0) + (chkChargeDash.Checked ? 2 : 0) + (chkWaterBreath.Checked ? 2 : 0) + (chkSoulLinkEfficiency.Checked ? 2 : 0) +
					(chkTripleJump.Checked ? 3 : 0) + (chkUltraDefense.Checked ? 3 : 0);
				data = Save.Master[MasterAssets.SeinInventory];
				data.WriteInt((int)InventoryInfo.Keystones, int.Parse(txtKeystones.Text));
				data.WriteInt((int)InventoryInfo.Mapstones, int.Parse(txtMapstones.Text));
				data.WriteInt((int)InventoryInfo.SkillpointsPickedUp, pointsUsed - int.Parse(txtLvl.Text) + int.Parse(txtAP.Text));

				data = Save.Master[MasterAssets.SeinSoulFlame];
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

				data = Save.Master[MasterAssets.SeinDeathCounter];
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

				data = Save.Master[MasterAssets.GameTimer];
				data.WriteFloat(0, totalSeconds);

				Save.DebugOn = true;

				data = Save.Master[MasterAssets.SavePedestals];
				data[(int)Pedestals.BlackRoot] = (byte)(chkBlackRoot.Checked ? 1 : 0);
				data[(int)Pedestals.Forlorn] = (byte)(chkForlornRuins.Checked ? 1 : 0);
				data[(int)Pedestals.GinsoTree] = (byte)(chkGinso.Checked ? 1 : 0);
				data[(int)Pedestals.Grotto] = (byte)(chkGrotto.Checked ? 1 : 0);
				data[(int)Pedestals.HollowGrove] = (byte)(chkHollowGrove.Checked ? 1 : 0);
				data[(int)Pedestals.HoruFields] = (byte)(chkHoruFields.Checked ? 1 : 0);
				data[(int)Pedestals.LostGrove] = (byte)(chkLostGrove.Checked ? 1 : 0);
				data[(int)Pedestals.MountHoru] = (byte)(chkMountHoru.Checked ? 1 : 0);
				data[(int)Pedestals.SorrowPass] = (byte)(chkSorrowPass.Checked ? 1 : 0);
				data[(int)Pedestals.SunkenGlades] = (byte)(chkSunkenGlades.Checked ? 1 : 0);
				data[(int)Pedestals.Swamp] = (byte)(chkSwamp.Checked ? 1 : 0);
				data[(int)Pedestals.Valley] = (byte)(chkValleyOfTheWind.Checked ? 1 : 0);

				data = Save.Master[MasterAssets.WorldEvents];
				data[(int)WorldEvents.CleanWater] = (byte)(chkCleanWater.Checked ? 1 : 0);
				data[(int)WorldEvents.DarknessLifted] = (byte)(chkDarknessLifted.Checked ? 1 : 0);
				data[(int)WorldEvents.ForlornRuinsKey] = (byte)(chkForlornKey.Checked ? 1 : 0);
				data[(int)WorldEvents.GinsoTreeEntered] = (byte)(chkGinsoEntered.Checked ? 1 : 0);
				data[(int)WorldEvents.GinsoTreeKey] = (byte)(chkGinsoKey.Checked ? 1 : 0);
				data[(int)WorldEvents.GravityActivated] = (byte)(chkGravityActivated.Checked ? 1 : 0);
				data[(int)WorldEvents.GumoFree] = (byte)(chkGumoFree.Checked ? 1 : 0);
				data[(int)WorldEvents.MistLifted] = (byte)(chkMistLifted.Checked ? 1 : 0);
				data[(int)WorldEvents.MountHoruKey] = (byte)(chkHoruKey.Checked ? 1 : 0);
				data[(int)WorldEvents.SpiritTreeReached] = (byte)(chkSpiritTree.Checked ? 1 : 0);
				data[(int)WorldEvents.WarmthReturned] = (byte)(chkWarmth.Checked ? 1 : 0);
				data[(int)WorldEvents.WindRestored] = (byte)(chkWindRestored.Checked ? 1 : 0);

				for (int i = 0; i < treeObjects.Nodes.Count; i++) {
					TreeNode node = treeObjects.Nodes[i];

					for (int j = 0; j < node.Nodes.Count; j++) {
						TreeNode child = node.Nodes[j];
						SceneID sceneValue = (SceneID)child.Tag;
						string fieldName = child.Text;

						data = Save.Find(sceneValue);

						if (data != null) {
							if (fieldName.IndexOf("Animator") >= 0) {
								data.WriteFloat(0, child.Checked ? 0 : 100f);
							} else if (fieldName.IndexOf("Creep") >= 0 || fieldName.IndexOf("Wall") >= 0 || fieldName.IndexOf("Stompable") >= 0 || fieldName.IndexOf("Bulb") >= 0 ||
									fieldName.IndexOf("Bombable") >= 0 || fieldName.IndexOf("Breakable") >= 0 || fieldName.IndexOf("PetrifiedPlant") >= 0) {
								float currentHP = data.GetFloat((int)EntityDamage.Health);
								data.WriteFloat((int)EntityDamage.Health, child.Checked ? (currentHP > 0 ? currentHP : data.GetFloat((int)EntityDamage.MaxHealth)) : -1f);

								if (sceneValue.Children != null) {
									foreach (SceneID extra in sceneValue.Children) {
										SetChildScene(sceneValue.Parent, extra, child.Checked);
									}
								}
							} else if (fieldName.IndexOf("Keystone") >= 0 || fieldName.IndexOf("Mapstone") >= 0 || fieldName.IndexOf("Pickup") >= 0) {
								data[(int)Pickup.Collected] = (byte)(child.Checked ? 0 : 1);
							} else if (fieldName.IndexOf("AbilityCell") >= 0 || fieldName.IndexOf("HealthCell") >= 0 || fieldName.IndexOf("EnergyCell") >= 0 || fieldName.IndexOf("ExpOrb") >= 0) {
								data[(int)Collectible.Collected] = (byte)(child.Checked ? 0 : 1);
							} else if (fieldName.IndexOf("DoorWith") >= 0 || fieldName.IndexOf("EnergyDoor") >= 0) {
								int currentState = data.GetInt((int)Door.CurrentState);
								data.WriteInt((int)Door.CurrentState, child.Checked ? 0 : (currentState == 0 ? 2 : currentState));
								if (child.Checked) {
									data.WriteInt((int)Door.SlotsPending, 0);
									data.WriteInt((int)Door.SlotsFilled, 0);
									data.WriteInt((int)Door.AmountOfItemsUsed, 0);
								}
							} else if (fieldName.IndexOf("Trigger") >= 0 || fieldName.IndexOf("Restrict") >= 0) {
								data[0] = (byte)(child.Checked ? 1 : 0);
							} else if (fieldName.IndexOf("Torch") >= 0) {
								data[0] = (byte)(child.Checked ? 0 : 1);

								if (sceneValue.Children != null) {
									foreach (SceneID extra in sceneValue.Children) {
										SetChildScene(sceneValue.Parent, extra, !child.Checked);
									}
								}
							}
						} else if (!child.Checked) {
							SceneCollection collection = Save.Insert(sceneValue.Parent);
							data = collection.Add(sceneValue);

							if (fieldName.IndexOf("Animator") >= 0) {
								data.Data = new byte[6];
								data.WriteFloat(0, 100f);
							} else if (fieldName.IndexOf("Creep") >= 0 || fieldName.IndexOf("Wall") >= 0 || fieldName.IndexOf("Stompable") >= 0 || fieldName.IndexOf("Bulb") >= 0 ||
										fieldName.IndexOf("Bombable") >= 0 || fieldName.IndexOf("Breakable") >= 0 || fieldName.IndexOf("PetrifiedPlant") >= 0) {
								data.Data = new byte[8];

								if (fieldName.IndexOf("PetrifiedPlant") >= 0) {
									data.WriteFloat((int)EntityDamage.Health, -1);
									data.WriteFloat((int)EntityDamage.MaxHealth, 5);
								} else if (fieldName.IndexOf("Stompable") >= 0 || fieldName.IndexOf("Bombable") >= 0 || fieldName.IndexOf("Breakable") >= 0 || fieldName.IndexOf("Wall") >= 0) {
									data.WriteFloat((int)EntityDamage.Health, -5);
									data.WriteFloat((int)EntityDamage.MaxHealth, 10);
								} else if (fieldName.IndexOf("Creep") >= 0 || fieldName.IndexOf("Bulb") >= 0) {
									data.WriteFloat((int)EntityDamage.Health, -1);
									data.WriteFloat((int)EntityDamage.MaxHealth, 4);
								}

								if (sceneValue.Children != null) {
									foreach (SceneID extra in sceneValue.Children) {
										SetChildScene(sceneValue.Parent, extra, child.Checked);
									}
								}
							} else if (fieldName.IndexOf("Keystone") >= 0 || fieldName.IndexOf("Mapstone") >= 0 || fieldName.IndexOf("Pickup") >= 0) {
								data.Data = new byte[5];
								data[(int)Pickup.Collected] = 1;
							} else if (fieldName.IndexOf("AbilityCell") >= 0 || fieldName.IndexOf("HealthCell") >= 0 || fieldName.IndexOf("EnergyCell") >= 0 || fieldName.IndexOf("ExpOrb") >= 0) {
								data.Data = new byte[1];
								data[(int)Collectible.Collected] = 1;
							} else if (fieldName.IndexOf("DoorWith") >= 0 || fieldName.IndexOf("EnergyDoor") >= 0) {
								data.Data = new byte[16];
								data.WriteInt((int)Door.CurrentState, 2);
								data.WriteInt((int)Door.AmountOfItemsUsed, fieldName.IndexOf("Two") >= 0 ? 2 : 4);
							} else if (fieldName.IndexOf("Trigger") >= 0 || fieldName.IndexOf("Restrict") >= 0) {
								data.Data = new byte[1];
								data[0] = 0;
							} else if (fieldName.IndexOf("Torch") >= 0) {
								data.Data = new byte[1];
								data[0] = 1;

								if (sceneValue.Children != null) {
									foreach (SceneID extra in sceneValue.Children) {
										SetChildScene(sceneValue.Parent, extra, !child.Checked);
									}
								}
							}
						}
					}
				}
				Save.Save(Save.FilePath);
				this.Close();
			} catch (Exception ex) {
				MessageBox.Show(this, "Failed to save file: " + ex.ToString());
			}
		}
		public void SetChildScene(SceneID parent, SceneID id, bool enabled) {
			SceneData data = Save.Find(id);
			if (data != null) {
				if (string.IsNullOrEmpty(id.Name)) {
					data.WriteFloat(0, enabled ? 100f : 0f);
				} else if (id.Name.IndexOf("Activator") >= 0) {
					data[0] = (byte)(enabled ? 1 : 0);
				} else if (id.Name.IndexOf("Deactivate") >= 0) {
					data[0] = (byte)(enabled ? 0 : 1);
				} else if (id.Name.IndexOf("Animator") >= 0) {
					data.WriteFloat(1, enabled ? 100f : 0f);
				}
			} else if (!enabled) {
				SceneCollection collection = Save.Insert(parent);
				data = collection.Add(id);

				if (string.IsNullOrEmpty(id.Name)) {
					data.Data = new byte[6];
				} else if (id.Name.IndexOf("Activator") >= 0) {
					data.Data = new byte[1];
				} else if (id.Name.IndexOf("Deactivate") >= 0) {
					data.Data = new byte[1];
					data[0] = 1;
				} else if (id.Name.IndexOf("Animator") >= 0) {
					data.Data = new byte[5];
				}
			}
		}
		private void btnDelete_Click(object sender, EventArgs e) {
			try {
				if (File.Exists(Save.FilePath)) {
					File.Delete(Save.FilePath);
				}
				this.Close();
			} catch (Exception ex) {
				MessageBox.Show(this, "Failed to delete save: " + ex.ToString());
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
		private void btnObjectText_Click(object sender, EventArgs e) {
			try {
				string saveFile = Path.GetFileNameWithoutExtension(Save.FilePath);
				if (File.Exists(saveFile + "-Objects1.txt")) {
					File.Delete(saveFile + "-Objects2.txt");
					File.Move(saveFile + "-Objects1.txt", saveFile + "-Objects2.txt");
				}

				Save.WriteObjectsAsText(saveFile + "-Objects1.txt");
				string fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), saveFile + "-Objects1.txt");
				MessageBox.Show(this, "Wrote object data to " + fullPath);
			} catch (Exception ex) {
				MessageBox.Show(this, "Failed to write file: " + ex.ToString());
			}
		}
		private void btnCopy_Click(object sender, EventArgs e) {
			btnCopy.Visible = false;
			txtCopy.Text = null;
			txtCopy.Visible = true;
			AcceptButton = null;
			txtCopy.Focus();
		}
		private void txtCopy_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				btnSave.Focus();
			} else if (e.KeyCode == Keys.Escape) {
				txtCopy.Visible = false;
				btnCopy.Visible = true;
			}
		}
		private void txtCopy_Validated(object sender, EventArgs e) {
			try {
				if (!txtCopy.Visible) { return; }

				txtCopy.Visible = false;
				btnCopy.Visible = true;

				if (string.IsNullOrEmpty(txtCopy.Text)) { return; }

				string copyFilePath = Path.Combine(Path.GetDirectoryName(Save.FilePath), "saveFile" + int.Parse(txtCopy.Text) + ".sav");
				if (File.Exists(copyFilePath)) {
					if (MessageBox.Show(this, Path.GetFileName(copyFilePath) + " already exists. Do you want to overwrite?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes) {
						return;
					}
				}
				Save.Save(copyFilePath);

				MessageBox.Show(this, "Copied save to " + Path.GetFileName(copyFilePath));
			} catch (Exception ex) {
				MessageBox.Show(this, "Failed to write file: " + ex.ToString());
			} finally {
				AcceptButton = btnSave;
			}
		}
	}
}