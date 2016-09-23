using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

		static SaveGameData() {
			Dictionary<string, FieldInfo> masterFields = new Dictionary<string, FieldInfo>();
			foreach (FieldInfo field in typeof(MasterAssets).GetFields(BindingFlags.Static | BindingFlags.Public)) {
				masterFields.Add(field.Name, field);
			}

			Type[] types = typeof(SceneID).Assembly.GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type asmType = types[i];
				if (asmType != typeof(SceneID) && typeof(SceneID).IsAssignableFrom(asmType)) {
					FieldInfo[] fields = asmType.GetFields(BindingFlags.Static | BindingFlags.Public);
					for (int j = 0; j < fields.Length; j++) {
						SceneID sceneValue = (SceneID)fields[j].GetValue(null);
						sceneValue.Name = fields[j].Name;
						FieldInfo field = null;
						if (masterFields.TryGetValue(asmType.Name, out field)) {
							sceneValue.Parent = (SceneID)field.GetValue(null);
						}
						SceneID.SceneNames.Add(sceneValue, sceneValue.Name);
					}
				}
			}

			SceneID.SceneNames.Add(SceneID.Assets, SceneID.Assets.Name);

			if (File.Exists("guids.txt")) {
				using (StreamReader reader = new StreamReader("guids.txt")) {
					string line = null;
					while ((line = reader.ReadLine()) != null) {
						string[] splits = line.Split('\t');
						if (splits.Length != 5) { continue; }

						SceneID id = new SceneID(int.Parse(splits[1]), int.Parse(splits[2]), int.Parse(splits[3]), int.Parse(splits[4]));
						if (!SceneID.SceneNames.ContainsKey(id)) {
							SceneID.SceneNames.Add(id, splits[0]);
						}
					}
				}
			}
		}

		public void WriteObjectsAsText(string filePath) {
			File.Delete(filePath);
			Encoding win = Encoding.GetEncoding(1252);
			byte[] seperator = win.GetBytes("------------------------------------------------------------------------------\n\n");

			using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite)) {
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
			using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite)) {
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
		public SceneData Find(SceneID sceneID) {
			foreach (SceneCollection collection in Scenes.Values) {
				SceneData data = collection[sceneID];
				if (data != null) { return data; }
			}
			return null;
		}
		public bool Remove(SceneID sceneID) {
			foreach (SceneCollection collection in Scenes.Values) {
				if (collection.Remove(sceneID)) {
					return true;
				}
			}
			return false;
		}
		public SceneCollection this[SceneID sceneGuid] {
			get {
				SceneCollection result;
				if (Scenes.TryGetValue(sceneGuid, out result)) {
					return result;
				}
				return null;
			}
		}
		public SceneCollection Insert(SceneID sceneGuid) {
			SceneCollection saveScene;
			if (Scenes.TryGetValue(sceneGuid, out saveScene)) {
				return saveScene;
			}
			saveScene = new SceneCollection {
				ID = sceneGuid
			};
			Scenes.Add(saveScene.ID, saveScene);
			return saveScene;
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
		public SceneData Add(SceneID id) {
			SceneData data = null;
			if (Objects.TryGetValue(id, out data)) {
				return data;
			}
			data = new SceneData();
			data.ID = id;
			Objects.Add(id, data);
			return data;
		}
		public bool Remove(SceneID sceneID) {
			return Objects.Remove(sceneID);
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
	public class SceneID {
		public static SceneID Assets = new MasterAssets();
		public static Dictionary<SceneID, string> SceneNames = new Dictionary<SceneID, string>();
		public SceneID Parent;
		public List<SceneID> Children;
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
			//return string.Concat(Left.ToString("X").PadLeft(16, '0'), Right.ToString("X").PadLeft(16, '0'));
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
		Forlorn,
		GinsoTree,
		HoruFields,
		BlackRoot,
		LostGrove,
		Grotto,
		MountHoru,
		Valley,
		HollowGrove,
		SunkenGlades,
		Swamp,
		SorrowPass
	}
	public enum Door {
		SlotsPending,
		AmountOfItemsUsed = 4,
		SlotsFilled = 8,
		CurrentState = 12
	}
	public enum Pickup {
		CurrentTime,
		Collected = 4
	}
	public enum Collectible {
		Collected,
		RemainingRespawnTime = 4
	}
	public enum WorldEvents {
		ForlornRuinsKey,
		GinsoTreeKey,
		MountHoruKey,
		GinsoTreeEntered,
		MistLifted,
		CleanWater,
		WindRestored,
		GumoFree,
		GravityActivated,
		SpiritTreeReached,
		WarmthReturned,
		DarknessLifted
	}
	public enum EntityDamage {
		Health,
		MaxHealth = 4
	}
}