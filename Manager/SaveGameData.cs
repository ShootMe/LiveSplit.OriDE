using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace LiveSplit.OriDE {
	public class SaveGameData {
		public const int VERSION = 13;
		public const string HEADER_FORMAT_STRING = "OriSave";
		public const int DATA_VERSION = 1;
		public const string FILE_FORMAT_STRING = "SaveGameData";

		public string FilePath;
		public int Version;
		public int DataVersion;
		public string AreaName = string.Empty;
		public int Completion;
		public int Health;
		public int MaxHealth;
		public int Energy;
		public int MaxEnergy;
		public int Hours;
		public int Minutes;
		public int Seconds;
		public int Order;
		public WorldProgression Progression;
		public bool Completed;
		public bool WasKilled;
		public bool CompletedWithEverything;
		public SceneID Identifier;
		public DifficultyMode Difficulty = DifficultyMode.Normal;
		public DifficultyMode LowestDifficulty = DifficultyMode.Normal;
		public bool IsTrialSave;
		public bool DebugOn;

		public readonly Dictionary<SceneID, SceneCollection> Scenes = new Dictionary<SceneID, SceneCollection>();

		public SceneCollection Master { get { return this.Insert(SceneID.Assets); } }

		public void WriteObjectsAsText(string filePath) {
			File.Delete(filePath);
			Encoding win = Encoding.GetEncoding(1252);
			byte[] seperator = win.GetBytes("------------------------------------------------------------------------------\n\n");

			using (FileStream fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
				using (BinaryWriter writer = new BinaryWriter(fs)) {
					foreach (SceneCollection current in Scenes.Values) {
						byte[] output = win.GetBytes(current.ID.ToString() + " " + current.Count + "\n");
						writer.Write(output);
						writer.Write(seperator);

						foreach (SceneData data in current.Objects.Values) {
							output = win.GetBytes(data.ID.ToString() + " " + data.ToString() + "\n");
							writer.Write(output);
						}
						writer.Write(seperator);
					}
				}
			}
		}
		public void Save(string filePath) {
			using (FileStream fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
				using (BinaryWriter writer = new BinaryWriter(fs)) {
					writer.Write(HEADER_FORMAT_STRING);
					writer.Write(VERSION);

					writer.Write(AreaName);
					writer.Write(Completion);
					writer.Write(Health);
					writer.Write(MaxHealth);
					writer.Write(Energy);
					writer.Write(MaxEnergy);
					writer.Write(Hours);
					writer.Write(Minutes);
					writer.Write(Seconds);
					writer.Write((int)Progression);
					writer.Write(Completed);
					writer.Write(Identifier.GetBytes());
					writer.Write(DebugOn);
					writer.Write(Order);
					writer.Write((int)Difficulty);
					writer.Write(WasKilled);
					writer.Write(CompletedWithEverything);
					writer.Write((int)LowestDifficulty);
					writer.Write(IsTrialSave);

					writer.Write(FILE_FORMAT_STRING);
					writer.Write(DATA_VERSION);
					writer.Write(Scenes.Count);
					foreach (SceneCollection current in Scenes.Values) {
						writer.Write(current.ID.GetBytes());
						writer.Write(current.Count);
						foreach (SceneData data in current.Objects.Values) {
							writer.Write(data.ID.GetBytes());
							data.WriteData(writer);
						}
					}
				}
			}
		}
		public bool Load(string filePath) {
			using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
				using (BinaryReader reader = new BinaryReader(fs)) {
					if (reader.ReadString() != HEADER_FORMAT_STRING) { return false; }

					FilePath = filePath;
					Version = reader.ReadInt32();
					if (Version < 10) { return false; }

					AreaName = reader.ReadString();
					Completion = reader.ReadInt32();
					Health = reader.ReadInt32();
					MaxHealth = reader.ReadInt32();
					Energy = reader.ReadInt32();
					MaxEnergy = reader.ReadInt32();
					Hours = reader.ReadInt32();
					Minutes = reader.ReadInt32();
					Seconds = reader.ReadInt32();
					Progression = (WorldProgression)reader.ReadInt32();
					Completed = reader.ReadBoolean();
					Identifier = new SceneID(reader.ReadBytes(16));
					DebugOn = reader.ReadBoolean();
					Order = reader.ReadInt32();
					Difficulty = (DifficultyMode)reader.ReadInt32();
					WasKilled = reader.ReadBoolean();
					CompletedWithEverything = reader.ReadBoolean();
					LowestDifficulty = (DifficultyMode)reader.ReadInt32();
					IsTrialSave = reader.ReadBoolean();

					Scenes.Clear();
					if (reader.ReadString() != FILE_FORMAT_STRING) { return false; }

					DataVersion = reader.ReadInt32();
					int num = reader.ReadInt32();
					for (int i = 0; i < num; i++) {
						SceneCollection saveScene = new SceneCollection();
						saveScene.ID = new SceneID(reader.ReadBytes(16));
						this.Scenes.Add(saveScene.ID, saveScene);
						int num2 = reader.ReadInt32();
						for (int j = 0; j < num2; j++) {
							SceneID id = new SceneID(reader.ReadBytes(16));
							SceneData item = new SceneData() { ID = id };
							item.ReadData(reader);
							saveScene.Objects.Add(item.ID, item);
						}
					}
				}
			}
			return true;
		}
		public SceneCollection this[SceneID sceneGuid] {
			get {
				SceneCollection result;
				if (this.Scenes.TryGetValue(sceneGuid, out result)) {
					return result;
				}
				return null;
			}
		}
		public SceneCollection Insert(SceneID sceneGuid) {
			SceneCollection saveScene;
			if (this.Scenes.TryGetValue(sceneGuid, out saveScene)) {
				return saveScene;
			}
			saveScene = new SceneCollection {
				ID = sceneGuid
			};
			this.Scenes.Add(saveScene.ID, saveScene);
			return saveScene;
		}
		public bool SceneExists(SceneID sceneGUID) {
			return this.Scenes.ContainsKey(sceneGUID);
		}
	}
	public class SceneCollection {
		public SceneID ID;
		public readonly Dictionary<SceneID, SceneData> Objects = new Dictionary<SceneID, SceneData>();

		public int Count {
			get { return Objects.Count; }
		}
		public SceneData this[SceneID id] {
			get {
				SceneData data = null;
				Objects.TryGetValue(id, out data);
				return data;
			}
		}
		public override string ToString() {
			return "ID: " + ID.ToString() + " Objects: " + Objects.Count;
		}
	}

	public class SceneData {
		public SceneID ID;
		public byte[] Data;

		public void WriteData(BinaryWriter binaryWriter) {
			binaryWriter.Write(Data.Length);
			binaryWriter.BaseStream.Write(Data, 0, Data.Length);
		}
		public void ReadData(BinaryReader binaryReader) {
			int num = binaryReader.ReadInt32();
			Data = new byte[num];
			binaryReader.Read(Data, 0, num);
		}
		public byte this[int index] {
			get { return Data[index]; }
			set { Data[index] = value; }
		}
		public void WriteInt(int offset, int value) {
			byte[] data = BitConverter.GetBytes(value);
			Data[offset] = data[0];
			Data[offset + 1] = data[1];
			Data[offset + 2] = data[2];
			Data[offset + 3] = data[3];
		}
		public int GetInt(int offset) {
			return BitConverter.ToInt32(Data, offset);
		}
		public void WriteFloat(int offset, float value) {
			byte[] data = BitConverter.GetBytes(value);
			Data[offset] = data[0];
			Data[offset + 1] = data[1];
			Data[offset + 2] = data[2];
			Data[offset + 3] = data[3];
		}
		public float GetFloat(int offset) {
			return BitConverter.ToSingle(Data, offset);
		}
		public override string ToString() {
			StringBuilder key = new StringBuilder();
			key.Append("[");
			if (Data != null) {
				foreach (byte b in this.Data) {
					if (b < 16) {
						key.Append("0").Append(b.ToString("X")).Append(" ");
					} else {
						key.Append(b.ToString("X")).Append(" ");
					}
				}
				if (Data.Length > 0) { key.Length = key.Length - 1; }
			}
			key.Append("]");
			return key.ToString();
		}
	}
	public class MasterAssets : SceneID {
		public static SceneID SeinInventory = new SceneID("444B746E7F7A0AE0CC208C40DE7CD9B1");
		public static SceneID PlatformMovement = new SceneID("4AA674A355CA54E9321AEAB78E4E5599");
		public static SceneID SeinLevel = new SceneID("44D72845AB790E021CC526C2EEAC82A5");
		public static SceneID PlayerAbilities = new SceneID("4B417974465D2E6BE06A6D8DBD0F0BB3");
		public static SceneID SeinSoulFlame = new SceneID("4548C1A49142B7E7C26404C530CF0CAC");
		public static SceneID SeinDeathCounter = new SceneID("48B63153499A49ACEFDD874FE2C88CBC");
		public static SceneID GameTimer = new SceneID("454EE3A50EB0CBE41EEF281B35EB93A9");
		public static SceneID SeinHealthInfo = new SceneID("4544D2E4CB117A965E43AAEB8BFE26AA");
		public static SceneID SeinEnergyInfo = new SceneID("4DE917EC7C3072427FEBCC44A35880B9");
		public static SceneID SavePedestals = new SceneID("44C2B52E4830C74C96FEAD2C45332E8D");

		public MasterAssets() : base() {
			Name = "Assets";
		}
	}
	public class SunkenGladesRunaway : SceneID {
		public static SceneID ExpOrb_200 = new SceneID("4C26AFB84C5D17FB807A3F242B52489A");
		public static SceneID EnergyDoor4Slots = new SceneID("43A40D50BE779223A2A26CD46B5628BB");
		public SunkenGladesRunaway(string id) : base(id) {
			Name = "SunkenGladesRunaway";
		}
	}
	public class SunkenGladesIntroSplitA : SceneID {
		public static SceneID EnergyCellCreep = new SceneID("4ED390C049094115F50E3AF57DE268B5");

		public static SceneID SpiritTorch = new SceneID("4910D2B7359FA9753E1A14B2333041A3");

		public static SceneID ExpOrb_100_Water = new SceneID("4100B81D8EEA0DDA06B2395595D418AC");
		public static SceneID ExpOrb_100_Top = new SceneID("45C40E763E5E308C3587F4DA5A01E48B");
		public static SceneID ExpOrb_200 = new SceneID("492756A0419BBF912F9E9B27BDB73EB8");

		public static SceneID EnergyCell = new SceneID("439ED3AA504548A0D99342DB969A4FBE");
		public static SceneID SoulFlameCastScene = new SceneID("4489F7032693A716D73F7C275E422494");

		public static SceneID KeystoneDoor2Slots = new SceneID("45669AABB68ED164A1373739CE27BFBE");
		public static SceneID Keystone2 = new SceneID("4C475939548601B0FB9966635678B0BC");
		public static SceneID KeystoneDoorActionSequence = new SceneID("4F396EE8B0D77ADF6344B20E3362C994");
		public SunkenGladesIntroSplitA(string id) : base(id) {
			Name = "SunkenGladesIntroSplitA";
		}
	}
	public class SunkenGladesIntroSplitB : SceneID {
		public static SceneID TopLeftCreep = new SceneID("4F48E391C0A25D19DD56ADFDDFF8B9A2");
		public static SceneID TopRightCreep = new SceneID("49AE23D67D72B17ADE220F24B3676A88");
		public static SceneID MiddleCreep = new SceneID("4D674617516FD7F1B9CB5D26BA6720BF");
		public static SceneID BottomLeftCreep = new SceneID("431CAE019ED6BE9BD45E3426109CF58C");
		public static SceneID BottomRightCreep = new SceneID("43076535B1BB2689AC5CA60EE1F7D98B");

		public static SceneID SpringCreep = new SceneID("4A48F32F439A6A00AB7504A5E62736B5");

		public static SceneID WellTopLeftCreep = new SceneID("49A5CBF49FBBF56E2D9FCAA430B2BAA3");
		public static SceneID WellTopRightCreep = new SceneID("448757C955AA6E73DF888533A454CA9B");
		public static SceneID WellMiddleCreep = new SceneID("40F89FC252E52AA6376A13D735375B82");
		public static SceneID WellBottomLeftCreep = new SceneID("4D97D2584572ED74A14E6FC4576F838F");
		public static SceneID WellBottomRightCreep = new SceneID("4A0444CC36337745E3B97C046F6A5B88");

		public static SceneID SpiritWellCutScene = new SceneID("46D7E4D3B94C4FC71184C8B1ED93D5B3");
		public static SceneID NaruStatueHintScene = new SceneID("40C8354D4F6DC7A009171549D5A33E8B");
		public static SceneID NaruStoryCutScene = new SceneID("48BA9B844D681969E8554943BCF35897");
		public static SceneID NaruStorySlowZone = new SceneID("4C4C003EBAA5C1E2960451E349F8E895");

		public static SceneID ExpOrb_15 = new SceneID("4DF41D6CE1D7DDE31E001F93B159D986");
		public static SceneID AbilityPoint = new SceneID("4DEBD90CDA7ABF939560FD6B83DF049F");
		public static SceneID Keystone1 = new SceneID("4FFCE57D9489DB41C6B81037ECEBB6BA");
		public SunkenGladesIntroSplitB(string id) : base(id) {
			Name = "SunkenGladesIntroSplitB";
		}
	}
	public class SunkenGladesBackgroundB : SceneID {
		public static SceneID ExpOrb_15 = new SceneID("49B35E8028EED6921FBB100D9890D79E");
		public SunkenGladesBackgroundB(string id) : base(id) {
			Name = "SunkenGladesBackgroundB";
		}
	}
	public class NorthMangroveFallsIntro : SceneID {
		public static SceneID ExpOrb_100 = new SceneID("48DD36AA196A9E89F9A530AECF6988BE");
		public static SceneID AbilityPoint = new SceneID("41565E76B8B341C60D8EFDABE797318E");
		public NorthMangroveFallsIntro(string id) : base(id) {
			Name = "NorthMangroveFallsIntro";
		}
	}
	public class SunkenGladesIntroBackground : SceneID {
		public SunkenGladesIntroBackground(string id) : base(id) {
			Name = "SunkenGladesIntroBackground";
		}
	}
	public class TitleScreenSwallowsNest : SceneID {
		public TitleScreenSwallowsNest(string id) : base(id) {
			Name = "TitleScreenSwallowsNest";
		}
	}
	public class SceneID {
		public static SceneID Assets = new MasterAssets();
		public static SceneID TitleScreenSwallowsNest = new TitleScreenSwallowsNest("04A461101D3720069663E5ABCD4BFE5A");
		public static SceneID SunkenGladesIntroBackground = new SunkenGladesIntroBackground("C4C4FBDA80B3B8FE935C5EF58CF6C56A");
		public static SceneID SunkenGladesRunaway = new SunkenGladesRunaway("5324FBF48F2DDD5D9C1569E8F9F53778");
		public static SceneID SunkenGladesIntroSplitA = new SunkenGladesIntroSplitA("FD940220E460F5F9FFBE19CE2985B628");
		public static SceneID SunkenGladesIntroSplitB = new SunkenGladesIntroSplitB("47E4D2DD460CBF8B05F44FD77932CE28");
		public static SceneID SunkenGladesBackgroundB = new SunkenGladesBackgroundB("E8346DDE7C5797FC712CE0C018E91CCB");
		public static SceneID NorthMangroveFallsIntro = new NorthMangroveFallsIntro("5E69BDB4F5A5301E006007BFCBDDEE55");

		public static Dictionary<SceneID, string> SceneNames = new Dictionary<SceneID, string>();

		static SceneID() {
			SceneNames.Add(Assets, "assets");
			SceneNames.Add(TitleScreenSwallowsNest, "titleScreenSwallowsNest");
			SceneNames.Add(SunkenGladesIntroBackground, "sunkenGladesIntroBackground");
			SceneNames.Add(SunkenGladesRunaway, "sunkenGladesRunaway");
			SceneNames.Add(SunkenGladesIntroSplitA, "sunkenGladesIntroSplitA");
			SceneNames.Add(SunkenGladesIntroSplitB, "sunkenGladesIntroSplitB");
			SceneNames.Add(SunkenGladesBackgroundB, "sunkenGladesBackgroundB");
			SceneNames.Add(NorthMangroveFallsIntro, "northMangroveFallsIntro");

			if (File.Exists("guids.txt")) {
				using (StreamReader reader = new StreamReader("guids.txt")) {
					string line = null;
					while ((line = reader.ReadLine()) != null) {
						string[] splits = line.Split('\t');
						if (splits.Length != 5) { continue; }

						SceneID id = new SceneID(int.Parse(splits[1]), int.Parse(splits[2]), int.Parse(splits[3]), int.Parse(splits[4]));
						if (!SceneNames.ContainsKey(id)) {
							SceneNames.Add(id, splits[0]);
						}
					}
				}
			}
		}

		public string Name;
		public readonly long Left, Right;

		protected SceneID() : this(0, 0) { }
		public SceneID(int left1, int left2, int right1, int right2) : this(((long)left2 << 32) | ((long)left1 & ((1L << 32) - 1L)), ((long)right2 << 32) | ((long)right1 & ((1L << 32) - 1L))) { }
		public SceneID(byte[] bytes) : this(BitConverter.ToInt64(bytes, 0), BitConverter.ToInt64(bytes, 8)) { }
		public SceneID(long left, long right) {
			Left = left;
			Right = right;
			if (SceneNames != null) {
				SceneNames.TryGetValue(this, out Name);
			}
		}


		public SceneID(string id) {
			for (int i = 0; i < 16; i++) {
				long val = 0;
				switch (char.ToUpper(id[i])) {
					case '0': val = 0; break;
					case '1': val = 1; break;
					case '2': val = 2; break;
					case '3': val = 3; break;
					case '4': val = 4; break;
					case '5': val = 5; break;
					case '6': val = 6; break;
					case '7': val = 7; break;
					case '8': val = 8; break;
					case '9': val = 9; break;
					case 'A': val = 10; break;
					case 'B': val = 11; break;
					case 'C': val = 12; break;
					case 'D': val = 13; break;
					case 'E': val = 14; break;
					case 'F': val = 15; break;
				}
				Left |= val << (60 - i * 4);
			}
			for (int i = 16; i < 32; i++) {
				long val = 0;
				switch (char.ToUpper(id[i])) {
					case '0': val = 0; break;
					case '1': val = 1; break;
					case '2': val = 2; break;
					case '3': val = 3; break;
					case '4': val = 4; break;
					case '5': val = 5; break;
					case '6': val = 6; break;
					case '7': val = 7; break;
					case '8': val = 8; break;
					case '9': val = 9; break;
					case 'A': val = 10; break;
					case 'B': val = 11; break;
					case 'C': val = 12; break;
					case 'D': val = 13; break;
					case 'E': val = 14; break;
					case 'F': val = 15; break;
				}
				Right |= val << (60 - i * 4);
			}
			if (SceneNames != null) {
				SceneNames.TryGetValue(this, out Name);
			}
		}
		public override bool Equals(object obj) {
			return obj != null && obj is SceneID && ((SceneID)obj).Left == Left && ((SceneID)obj).Right == Right;
		}
		public override int GetHashCode() {
			return (int)(Left ^ Right);
		}
		public byte[] GetBytes() {
			byte[] bytes = new byte[16];
			byte[] left = BitConverter.GetBytes(Left);
			byte[] right = BitConverter.GetBytes(Right);
			for (int i = 0; i < 8; i++) {
				bytes[i] = left[i];
				bytes[i + 8] = right[i];
			}
			return bytes;
		}
		public override string ToString() {
			return string.Concat(Name, string.IsNullOrEmpty(Name) ? "" : " ", Left.ToString("X").PadLeft(16, '0'), Right.ToString("X").PadLeft(16, '0'));
		}
	}
	public enum WorldProgression {
		Prologue,
		StartOfGame = 10,
		SpiritTreeReached = 20,
		EnteredGinsoTree = 30,
		FinishedGinsoTree = 40,
		MistLifted = 50,
		WindRestored = 60,
		AfterNest = 70,
		WarmthReturned = 80,
		Finished = 90
	}
	public enum DifficultyMode {
		Easy,
		Normal,
		Hard,
		OneLife
	}
	public enum LevelInfo {
		CurrentLevel,
		Experience = 4,
		AbilityPoints = 8
	}
	public enum SaveInfo {
		PosX = 44,
		PosY = 48,
		SpeedX = 162,
		SpeedY = 166
	}
	public enum SoulFlameInfo {
		SoulFlamesCast = 26,
		HasSoulFlame = 30,
		SoulX = 31,
		SoulY = 35
	}
	public enum Abilities {
		Bash,
		ChargeFlame,
		WallJump,
		Stomp,
		DoubleJump,
		ChargeJump,
		Magnet,
		UltraMagnet,
		Climb,
		Glide,
		SpiritFlame,
		RapidFire,
		SoulEfficiency,
		WaterBreath,
		ChargeFlameBlast,
		ChargeFlameBurn,
		DoubleJumpUpgrade,
		BashBuff,
		UltraDefense,
		HealthEfficiency,
		Sense,
		StompUpgrade,
		QuickFlame,
		MapMarkers,
		EnergyEfficiency,
		HealthMarkers,
		EnergyMarkers,
		AbilityMarkers,
		Rekindle,
		Regroup,
		ChargeFlameEfficiency,
		UltraSoulFlame,
		SoulFlameEfficiency,
		SplitFlameUpgrade,
		SparkFlame,
		CinderFlame,
		UltraSplitFlame,
		Dash,
		Grenade,
		GrenadeUpgrade,
		ChargeDash,
		AirDash,
		GrenadeEfficiency
	}
	public enum InventoryInfo {
		Keystones,
		Mapstones = 4,
		SkillpointsPickedUp = 8
	}
	public enum SeinHealthController {
		Amount,
		MaxHealth = 4
	}
	public enum SeinEnergy {
		Current,
		Max = 4
	}
	public enum Pedestals {
		One,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		SunkenGlades,
		Eleven,
		Twelve
	}
	public enum Door {
		SlotsPending,
		AmountOfItemsUsed = 4,
		SlotsFilled = 8,
		CurrentState = 12
	}
}