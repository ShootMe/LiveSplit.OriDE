using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
namespace LiveSplit.OriDE.Memory {
	public partial class OriMemory {
		private static ProgramPointer GameWorld = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC53575683EC0C8B7D08B8????????89388B47", 13));
		private static ProgramPointer GameplayCamera = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "05480000008B08894DE88B4804894DEC8B40088945F08B05", -4));
		private static ProgramPointer WorldEvents = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC5783EC048B7D0C83EC0868????????57393FE8????????83C41083EC0868", 33));
		private static ProgramPointer SeinCharacter = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC5783EC048B7D08B8????????8938B8????????893883EC0C68", 11));
		private static ProgramPointer ScenesManager = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC5783EC148B7D08B8????????893883EC0C57E8????????83C4108B05", 11));
		private static ProgramPointer GameStateMachine = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC5783EC148B7D08B8????????8938E8????????83EC0868", 11));
		private static ProgramPointer RainbowDash = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "EC535783EC108B7D08C687????????000FB605????????85C074", 19));
		private static ProgramPointer GameController = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "8B05????????83EC086A0050E8????????83C41085C074208B450883EC0C50E8", 2));
		private static ProgramPointer TAS = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "C745D8F1DEBC9AC745DC785634128D45D8", -6));
		private static ProgramPointer CoreInput = new ProgramPointer(AutoDeref.Single, new ProgramSignature(PointerVersion.V1, "558BEC83EC488B05????????8B40188B40108945B8B8????????8B08894DC08B400489", 22));
		public Process Program { get; set; }
		public bool IsHooked { get; set; } = false;
		private DateTime lastHooked;
		private static Skill[] AllSkills = new Skill[] { Skill.Sein, Skill.WallJump, Skill.ChargeFlame, Skill.Dash, Skill.DoubleJump, Skill.Bash, Skill.Stomp, Skill.Glide, Skill.Climb, Skill.ChargeJump, Skill.Grenade };

		public OriMemory() {
			lastHooked = DateTime.MinValue;
		}

		public int SeinInputDir() {
			bool down = SeinCharacter.Read<bool>(Program, 0x0, 0x34, 0x8, 0x8);
			bool left = SeinCharacter.Read<bool>(Program, 0x0, 0x34, 0xc, 0x8);
			bool right = SeinCharacter.Read<bool>(Program, 0x0, 0x34, 0x10, 0x8);
			bool up = SeinCharacter.Read<bool>(Program, 0x0, 0x34, 0x14, 0x8);
			return down ? 1 : up ? 2 : left ? 3 : right ? 4 : 0;
		}
		public float WaterSpeed() {
			return SeinCharacter.Read<float>(Program, 0x0, 0x10, 0x3c, 0x98);
		}
		public void SetSpeed(float maxSpeed, float accGround, float accAir, float waterSpeed, float bashSpeed, float stompSpeed, float wallJumpImp, float chargeJumpSpeed, float wallChargeJumpSpeed, float jumpHeight, float climbSpeed, float dashSpeed, float chargeDashSpeed) {
			SeinCharacter.Write(Program, accGround, 0x0, 0x48, 0x14, 0x28, 0x8, 0x8);
			SeinCharacter.Write(Program, accGround / 2f, 0x0, 0x48, 0x14, 0x28, 0x8, 0xc);
			SeinCharacter.Write(Program, maxSpeed, 0x0, 0x48, 0x14, 0x28, 0x8, 0x10);

			SeinCharacter.Write(Program, accAir, 0x0, 0x48, 0x14, 0x28, 0xc, 0x8);
			SeinCharacter.Write(Program, accAir, 0x0, 0x48, 0x14, 0x28, 0xc, 0xc);
			SeinCharacter.Write(Program, maxSpeed, 0x0, 0x48, 0x14, 0x28, 0xc, 0x10);

			SeinCharacter.Write(Program, waterSpeed, 0x0, 0x10, 0x3c, 0x98);

			SeinCharacter.Write(Program, bashSpeed, 0x0, 0x10, 0x50, 0x88);

			SeinCharacter.Write(Program, stompSpeed, 0x0, 0x10, 0x20, 0x7c);

			SeinCharacter.Write(Program, wallJumpImp, 0x0, 0x10, 0x10, 0x44);
			SeinCharacter.Write(Program, wallJumpImp * 2, 0x0, 0x10, 0x10, 0x48);

			SeinCharacter.Write(Program, chargeJumpSpeed, 0x0, 0x10, 0x18, 0x4c);
			SeinCharacter.Write(Program, wallChargeJumpSpeed, 0x0, 0x10, 0x1c, 0x48);

			if (jumpHeight == 3f) {
				SeinCharacter.Write(Program, 3f, 0x0, 0x10, 0xc, 0x60);
				SeinCharacter.Write(Program, 3f, 0x0, 0x10, 0xc, 0x54);
				SeinCharacter.Write(Program, 3f, 0x0, 0x10, 0xc, 0x64);
				SeinCharacter.Write(Program, 3.75f, 0x0, 0x10, 0xc, 0x70);
				SeinCharacter.Write(Program, 4.25f, 0x0, 0x10, 0xc, 0x74);
				SeinCharacter.Write(Program, 4.25f, 0x0, 0x10, 0xc, 0x58);
			} else {
				SeinCharacter.Write(Program, jumpHeight, 0x0, 0x10, 0xc, 0x60);
				SeinCharacter.Write(Program, jumpHeight, 0x0, 0x10, 0xc, 0x54);
				SeinCharacter.Write(Program, jumpHeight, 0x0, 0x10, 0xc, 0x64);
				SeinCharacter.Write(Program, jumpHeight, 0x0, 0x10, 0xc, 0x70);
				SeinCharacter.Write(Program, jumpHeight, 0x0, 0x10, 0xc, 0x74);
				SeinCharacter.Write(Program, jumpHeight * 2f, 0x0, 0x10, 0xc, 0x58);
			}

			SeinCharacter.Write(Program, climbSpeed, 0x0, 0x10, 0x30, 0x5c);
			SeinCharacter.Write(Program, climbSpeed, 0x0, 0x10, 0x30, 0x60);

			SeinCharacter.Write(Program, dashSpeed, 0x0, 0x10, 0x80, 0x20, 0x8, 0x84);
			SeinCharacter.Write(Program, chargeDashSpeed, 0x0, 0x10, 0x80, 0x24, 0x8, 0x84);
		}
		public PointF CurrentSpeed() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = SeinCharacter.Read<float>(Program, 0x0, 0x48, 0x10, 0xbc);
			float py = SeinCharacter.Read<float>(Program, 0x0, 0x48, 0x10, 0xc0);
			bool onGround = SeinCharacter.Read<bool>(Program, 0x0, 0x48, 0x10, 0x18, 0x9);
			float gravityAngle = SeinCharacter.Read<float>(Program, 0x0, 0x48, 0x10, 0xb8);
			float gx = SeinCharacter.Read<float>(Program, 0x0, 0x48, 0x10, 0x60);
			float gy = SeinCharacter.Read<float>(Program, 0x0, 0x48, 0x10, 0x64);
			PointF groundNormal = new PointF(gx, gy);
			PointF groundBinomial = new PointF(gy, -gx);

			return (py > 0.0001f || !onGround) ? Rotate(new PointF(px, py), gravityAngle) : Add(Mul(groundNormal, py), Mul(groundBinomial, px));
		}
		public static PointF Add(PointF one, PointF two) {
			return new PointF(one.X + two.X, one.Y + two.Y);
		}
		public static PointF Mul(PointF one, float scale) {
			return new PointF(one.X * scale, one.Y * scale);
		}
		public static PointF Rotate(PointF v, float angle) {
			if (angle == 0f) {
				return v;
			}
			float f = angle * 0.0174532924f;
			float num = (float)Math.Cos(f);
			float num2 = (float)Math.Sin(f);
			return new PointF(v.X * num - v.Y * num2, v.X * num2 + v.Y * num);
		}
		public PointF GetCursorPosition() {
			float mx = CoreInput.Read<float>(Program);
			float my = CoreInput.Read<float>(Program, 0x4);
			return new PointF(mx, my);
		}
		public void ActivateRainbowDash() {
			if (GetAbility("Dash") && RainbowDash.GetPointer(Program) != IntPtr.Zero && !RainbowDash.Read<bool>(Program)) {
				RainbowDash.Write<bool>(Program, true);
			}
		}
		public PointF GetCameraTargetPosition() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = GameplayCamera.Read<float>(Program, 0x0, 0x14, 0x10);
			float py = GameplayCamera.Read<float>(Program, 0x0, 0x14, 0x14);
			return new PointF(px, py);
		}
		public Dictionary<string, bool> GetEvents() {
			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in events) {
				results[pair.Key] = WorldEvents.Read<bool>(Program, pair.Value + 0x40);
			}
			return results;
		}
		public bool GetEvent(string name) {
			int offset = events[name];
			return WorldEvents.Read<bool>(Program, offset + 0x40);
		}
		public Dictionary<string, bool> GetKeys() {
			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in keys) {
				results[pair.Key] = WorldEvents.Read<bool>(Program, pair.Value);
			}
			return results;
		}
		public bool GetKey(string name) {
			int key = keys[name];
			return WorldEvents.Read<bool>(Program, key);
		}
		public Dictionary<string, bool> GetAbilities() {
			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in abilities) {
				results[pair.Key] = SeinCharacter.Read<bool>(Program, 0x0, 0x4c, pair.Value * 4, 0x08);
			}
			return results;
		}
		public bool GetAbility(string name) {
			int ability = abilities[name];
			return SeinCharacter.Read<bool>(Program, 0x0, 0x4c, ability * 4, 0x08);
		}
		public void SetAbility(string name, bool enable) {
			int ability = abilities[name];
			SeinCharacter.Write<bool>(Program, enable, 0x0, 0x4c, ability * 4, 0x08);
		}
		public void SetSkills(bool enable, params Skill[] skills) {
			if (skills == null || skills.Length == 0) {
				skills = AllSkills;
			}

			for (int i = 0; i < skills.Length; i++) {
				switch (skills[i]) {
					case Skill.Sein: SetAbility("Spirit Flame", enable); break;
					case Skill.WallJump: SetAbility("Wall Jump", enable); break;
					case Skill.ChargeFlame: SetAbility("Charge Flame", enable); break;
					case Skill.Dash: SetAbility("Dash", enable); break;
					case Skill.DoubleJump: SetAbility("Double Jump", enable); break;
					case Skill.Bash: SetAbility("Bash", enable); break;
					case Skill.Stomp: SetAbility("Stomp", enable); break;
					case Skill.Glide: SetAbility("Glide", enable); break;
					case Skill.Climb: SetAbility("Climb", enable); break;
					case Skill.ChargeJump: SetAbility("Charge Jump", enable); break;
					case Skill.Grenade: SetAbility("Light Grenade", enable); break;
				}
			}
		}
		public List<Area> GetMapCompletion() {
			List<Area> areas = new List<Area>();
			if (GameWorld.GetPointer(Program) != IntPtr.Zero) {
				IntPtr current = (IntPtr)GameWorld.Read<uint>(Program, 0x0, 0x1c);
				Area currentArea = GetArea(current);
				IntPtr listHead = (IntPtr)GameWorld.Read<uint>(Program, 0x0, 0x18, 0x08);
				int listSize = GameWorld.Read<int>(Program, 0x0, 0x18, 0x0c);

				for (var i = 0; i < listSize; i++) {
					IntPtr gameWorldAreaHead = (IntPtr)Program.Read<uint>(listHead, 0x10 + (i * 4));

					Area area = GetArea(gameWorldAreaHead);
					if (area.Name.Equals(currentArea.Name, StringComparison.OrdinalIgnoreCase)) {
						area.Current = true;
					}
					areas.Add(area);
				}
			}

			return areas;
		}
		public Area GetCurrentArea() {
			if (GameWorld.GetPointer(Program) != IntPtr.Zero) {
				return GetArea((IntPtr)GameWorld.Read<uint>(Program, 0x0, 0x1c));
			}
			return default(Area);
		}
		public decimal GetTotalMapCompletion() {
			decimal total = 0;
			int listSize = 0;
			if (GameWorld.GetPointer(Program) != IntPtr.Zero) {
				IntPtr listHead = (IntPtr)GameWorld.Read<uint>(Program, 0x0, 0x18, 0x08);
				listSize = GameWorld.Read<int>(Program, 0x0, 0x18, 0x0c);
				for (var i = 0; i < listSize; i++) {
					IntPtr gameWorldAreaHead = (IntPtr)Program.Read<uint>(listHead, 0x10 + (i * 4));
					Area area = GetArea(gameWorldAreaHead);
					total += area.Progress;
				}
			}

			return total / (decimal)(listSize == 0 ? 1 : listSize);
		}
		private Area GetArea(IntPtr areaAddress) {
			float completionAmount = Program.Read<float>(areaAddress, 0x14);
			string areaName = Program.Read((IntPtr)Program.Read<uint>(areaAddress, 0x08, 0x1c));
			if (areaName.IndexOf("Mangrove", StringComparison.OrdinalIgnoreCase) >= 0) {
				areaName = "Black Root";
			}

			Area area = new Area();
			area.Name = areaName;
			area.Progress = Math.Round((decimal)completionAmount * 100, 2, MidpointRounding.AwayFromZero);
			area.Current = false;
			return area;
		}
		public List<Scene> GetScenes(PointF currentPos = default(PointF)) {
			IntPtr activeScenesHead = (IntPtr)ScenesManager.Read<uint>(Program, 0x0, 0x14);
			int listSize = Program.Read<int>(activeScenesHead, 0x0c);

			if (currentPos == default(PointF)) {
				currentPos = GetCameraTargetPosition();
			}
			HitBox cameraBox = new HitBox(currentPos, 0f, 0f, true);
			bool foundActive = false;

			List<Scene> scenes = new List<Scene>();
			for (int i = 0; i < listSize; i++) {
				IntPtr sceneManagerHead = (IntPtr)Program.Read<uint>(activeScenesHead, 0x08, 0x10 + (i * 4));
				IntPtr runtimeSceneHead = (IntPtr)Program.Read<uint>(sceneManagerHead, 0x0c);

				Scene scene = new Scene();
				scene.Name = Program.Read((IntPtr)Program.Read<uint>(runtimeSceneHead, 0x08));
				scene.State = (SceneState)Program.Read<int>(sceneManagerHead, 0x14);
				bool dependantScene = Program.Read<bool>(runtimeSceneHead, 0x34);

				if (!foundActive && !dependantScene) {
					runtimeSceneHead = (IntPtr)Program.Read<uint>(runtimeSceneHead, 0x14);
					int boundaryCount = Program.Read<int>(runtimeSceneHead, 0x0c);
					for (int j = 0; j < boundaryCount; j++) {
						float bx = Program.Read<float>(runtimeSceneHead, 0x08, 0x10 + (j * 16));
						float by = Program.Read<float>(runtimeSceneHead, 0x08, 0x14 + (j * 16));
						float bw = Program.Read<float>(runtimeSceneHead, 0x08, 0x18 + (j * 16));
						float bh = Program.Read<float>(runtimeSceneHead, 0x08, 0x1c + (j * 16));
						HitBox rect = new HitBox(new PointF(bx, by + bh), bw, bh, false);
						if (rect.Intersects(cameraBox)) {
							scene.Active = true;
							foundActive = true;
							break;
						}
					}
				}

				scenes.Add(scene);
			}

			return scenes;
		}
		public bool IsEnteringGame() {
			return GameController.Read<bool>(Program, 0x0, 0x68) || GameController.Read<bool>(Program, 0x0, 0x69) || SeinCharacter.Read<uint>(Program) == 0 || (GetCurrentLevel() == 0 && GetCurrentENMax() == 3 && GetCurrentHPMax() == 3);
		}
		public bool CanMove() {
			return !GameController.Read<bool>(Program, 0x0, 0x7c) && !GameController.Read<bool>(Program, 0x0, 0x7b) && !SeinCharacter.Read<bool>(Program, 0x0, 0x18, 0x38) && !SeinCharacter.Read<bool>(Program, 0x0, 0x18, 0x40);
		}
		public GameState GetGameState() {
			return (GameState)GameStateMachine.Read<int>(Program, 0x0, 0x14);
		}
		public int GetKeyStones() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x2c, 0x1c);
		}
		public int GetMapStones() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x2c, 0x20);
		}
		public int GetAbilityCells() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x2c, 0x24);
		}
		public int GetSkillPointsAvailable() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x38, 0x24);
		}
		public int GetCurrentLevel() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x38, 0x28);
		}
		public int GetExperience() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x38, 0x2c);
		}
		public int GetCurrentHP() {
			return (int)SeinCharacter.Read<float>(Program, 0x0, 0x40, 0x0c, 0x1c);
		}
		public int GetCurrentHPMax() {
			return SeinCharacter.Read<int>(Program, 0x0, 0x40, 0x0c, 0x20) / 4;
		}
		public float GetCurrentEN() {
			return SeinCharacter.Read<float>(Program, 0x0, 0x3c, 0x20);
		}
		public float GetCurrentENMax() {
			return SeinCharacter.Read<float>(Program, 0x0, 0x3c, 0x24);
		}
		public void SetTASCharacter(byte keyCode) {
			if (TAS.GetPointer(Program) != IntPtr.Zero) {
				TAS.Write<byte>(Program, keyCode, 0xc);
			}
		}
		public int GetTASState() {
			return TAS.Read<int>(Program, -0x10);
		}
		public string GetTASCurrentInput() {
			return TAS.Read(Program, 0x10);
		}
		public string GetTASNextInput() {
			return TAS.Read(Program, 0x14);
		}
		public string GetTASExtraInfo() {
			return TAS.Read(Program, 0x18);
		}
		public PointF GetTASOriPositon() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = TAS.Read<float>(Program, 0x2c);
			float py = TAS.Read<float>(Program, 0x30);
			return new PointF(px, py);
		}
		public bool HasTAS() {
			return TAS.GetPointer(Program) != IntPtr.Zero;
		}
		public bool HookProcess() {
			IsHooked = Program != null && !Program.HasExited;
			if (!IsHooked && DateTime.Now > lastHooked.AddSeconds(1)) {
				lastHooked = DateTime.Now;
				Process[] processes = Process.GetProcessesByName("OriDE");
				Program = processes.Length == 0 ? null : processes[0];
				if (Program != null && !Program.HasExited) {
					MemoryReader.Update64Bit(Program);
					IsHooked = true;
				}
			}

			return IsHooked;
		}
		public string GetPointer(string name) {
			switch (name) {
				case "GameWorld": return GameWorld.Pointer.ToString("X");
				case "GameplayCamera": return GameplayCamera.Pointer.ToString("X");
				case "WorldEvents": return WorldEvents.Pointer.ToString("X");
				case "SeinCharacter": return SeinCharacter.Pointer.ToString("X");
				case "ScenesManager": return ScenesManager.Pointer.ToString("X");
				case "GameStateMachine": return GameStateMachine.Pointer.ToString("X");
				case "RainbowDash": return RainbowDash.Pointer.ToString("X");
			}
			return string.Empty;
		}
		public void AddLogItems(List<string> items) {
			foreach (string key in keys.Keys) {
				items.Add(key);
			}
			foreach (string key in events.Keys) {
				items.Add(key);
			}
			foreach (string key in abilities.Keys) {
				items.Add(key);
			}
		}
		public void Dispose() {
			if (Program != null) { this.Program.Dispose(); }
		}

		public static Dictionary<string, int> keys = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
		{
			{"Water Vein",   0},
			{"Gumon Seal",   1},
			{"Sunstone",     2},
		};
		public static Dictionary<string, int> events = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
		{
			{"Ginso Tree Entered",   0},
			{"Mist Lifted",          1},
			{"Clean Water",          2},
			{"Wind Restored",        3},
			{"Gumo Free",            4},
			{"Spirit Tree Reached",  5},
			{"Warmth Returned",      6},
			{"Darkness Lifted",      7}
		};
		public static Dictionary<string, int> abilities = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
		{
			{"Bash",                     5},
			{"Charge Flame",             6},
			{"Wall Jump",                7},
			{"Stomp",                    8},
			{"Double Jump",              9},
			{"Charge Jump",              10},
			{"Magnet",                   11},
			{"Ultra Magnet",             12},
			{"Climb",                    13},
			{"Glide",                    14},
			{"Spirit Flame",             15},
			{"Rapid Fire",               16},
			{"Soul Efficiency",          17},
			{"Water Breath",             18},
			{"Charge Flame Blast",       19},
			{"Charge Flame Burn",        20},
			{"Double Jump Upgrade",      21},
			{"Bash Upgrade",             22},
			{"Ultra Defense",            23},
			{"Health Efficiency",        24},
			{"Sense",                    25},
			{"Stomp Upgrade",            26},
			{"Quick Flame",              27},
			{"Map Markers",              28},
			{"Energy Efficiency",        29},
			{"Health Markers",           30},
			{"Energy Markers",           31},
			{"Ability Markers",          32},
			{"Rekindle",                 33},
			{"Regroup",                  34},
			{"Charge Flame Efficiency",  35},
			{"Ultra Soul Flame",         36},
			{"Soul Flame Efficiency",    37},
			{"Split Flame",              38},
			{"Spark Flame",              39},
			{"Cinder Flame",             40},
			{"Ultra Split Flame",        41},
			{"Light Grenade",            42},
			{"Dash",                     43},
			{"Grenade Upgrade",          44},
			{"Charge Dash",              45},
			{"Air Dash",                 46},
			{"Grenade Efficiency",       47}
		};
	}
	public enum PointerVersion {
		V1
	}
	public enum AutoDeref {
		None,
		Single,
		Double
	}
	public class ProgramSignature {
		public PointerVersion Version { get; set; }
		public string Signature { get; set; }
		public int Offset { get; set; }
		public ProgramSignature(PointerVersion version, string signature, int offset) {
			Version = version;
			Signature = signature;
			Offset = offset;
		}
		public override string ToString() {
			return Version.ToString() + " - " + Signature;
		}
	}
	public class ProgramPointer {
		private int lastID;
		private DateTime lastTry;
		private ProgramSignature[] signatures;
		private int[] offsets;
		public IntPtr Pointer { get; private set; }
		public PointerVersion Version { get; private set; }
		public AutoDeref AutoDeref { get; private set; }

		public ProgramPointer(AutoDeref autoDeref, params ProgramSignature[] signatures) {
			AutoDeref = autoDeref;
			this.signatures = signatures;
			lastID = -1;
			lastTry = DateTime.MinValue;
		}
		public ProgramPointer(AutoDeref autoDeref, params int[] offsets) {
			AutoDeref = autoDeref;
			this.offsets = offsets;
			lastID = -1;
			lastTry = DateTime.MinValue;
		}

		public T Read<T>(Process program, params int[] offsets) where T : struct {
			GetPointer(program);
			return program.Read<T>(Pointer, offsets);
		}
		public string Read(Process program, params int[] offsets) {
			GetPointer(program);
			return program.Read((IntPtr)program.Read<uint>(Pointer, offsets));
		}
		public byte[] ReadBytes(Process program, int length, params int[] offsets) {
			GetPointer(program);
			return program.Read(Pointer, length, offsets);
		}
		public void Write<T>(Process program, T value, params int[] offsets) where T : struct {
			GetPointer(program);
			program.Write<T>(Pointer, value, offsets);
		}
		public void Write(Process program, byte[] value, params int[] offsets) {
			GetPointer(program);
			program.Write(Pointer, value, offsets);
		}
		public IntPtr GetPointer(Process program) {
			if (program == null) {
				Pointer = IntPtr.Zero;
				lastID = -1;
				return Pointer;
			} else if (program.Id != lastID) {
				Pointer = IntPtr.Zero;
				lastID = program.Id;
			}

			if (Pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1)) {
				lastTry = DateTime.Now;

				Pointer = GetVersionedFunctionPointer(program);
				if (Pointer != IntPtr.Zero) {
					if (AutoDeref != AutoDeref.None) {
						Pointer = (IntPtr)program.Read<uint>(Pointer);
						if (AutoDeref == AutoDeref.Double) {
							if (MemoryReader.is64Bit) {
								Pointer = (IntPtr)program.Read<ulong>(Pointer);
							} else {
								Pointer = (IntPtr)program.Read<uint>(Pointer);
							}
						}
					}
				}
			}
			return Pointer;
		}
		private IntPtr GetVersionedFunctionPointer(Process program) {
			if (signatures != null) {
				MemorySearcher searcher = new MemorySearcher();
				searcher.MemoryFilter = delegate (MemInfo info) {
					return (info.State & 0x1000) != 0 && (info.Protect & 0x40) != 0 && (info.Protect & 0x100) == 0;
				};
				for (int i = 0; i < signatures.Length; i++) {
					ProgramSignature signature = signatures[i];

					IntPtr ptr = searcher.FindSignature(program, signature.Signature);
					if (ptr != IntPtr.Zero) {
						Version = signature.Version;
						return ptr + signature.Offset;
					}
				}
			} else {
				IntPtr ptr = (IntPtr)program.Read<uint>(program.MainModule.BaseAddress, offsets);
				if (ptr != IntPtr.Zero) {
					return ptr;
				}
			}

			return IntPtr.Zero;
		}
	}
}