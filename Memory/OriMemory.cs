using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
namespace LiveSplit.OriDE.Memory {
	public partial class OriMemory {
		private ProgramPointer gameWorld, gameplayCamera, worldEvents, seinCharacter, scenesManager, gameStateMachine, rainbowDash, gameController, tas, coreInput;
		public Process Program { get; set; }
		public bool IsHooked { get; set; } = false;
		private static Skill[] AllSkills = new Skill[] { Skill.Sein, Skill.WallJump, Skill.ChargeFlame, Skill.Dash, Skill.DoubleJump, Skill.Bash, Skill.Stomp, Skill.Glide, Skill.Climb, Skill.ChargeJump, Skill.Grenade };

		public OriMemory() {
			gameWorld = new ProgramPointer(this, MemPointer.GameWorld) { AutoDeref = false };
			gameplayCamera = new ProgramPointer(this, MemPointer.GameplayCamera) { AutoDeref = false };
			worldEvents = new ProgramPointer(this, MemPointer.WorldEvents) { AutoDeref = false };
			seinCharacter = new ProgramPointer(this, MemPointer.SeinCharacter) { AutoDeref = false };
			scenesManager = new ProgramPointer(this, MemPointer.ScenesManager) { AutoDeref = false };
			gameStateMachine = new ProgramPointer(this, MemPointer.GameStateMachine) { AutoDeref = false };
			rainbowDash = new ProgramPointer(this, MemPointer.RainbowDash) { AutoDeref = false };
			gameController = new ProgramPointer(this, MemPointer.GameController) { AutoDeref = false };
			tas = new ProgramPointer(this, MemPointer.TAS) { AutoDeref = false };
			coreInput = new ProgramPointer(this, MemPointer.Input) { AutoDeref = false };
		}

		public int SeinInputDir() {
			bool down = seinCharacter.Read<bool>(0x0, 0x34, 0x8, 0x8);
			bool left = seinCharacter.Read<bool>(0x0, 0x34, 0xc, 0x8);
			bool right = seinCharacter.Read<bool>(0x0, 0x34, 0x10, 0x8);
			bool up = seinCharacter.Read<bool>(0x0, 0x34, 0x14, 0x8);
			return down ? 1 : up ? 2 : left ? 3 : right ? 4 : 0;
		}
		public float WaterSpeed() {
			return seinCharacter.Read<float>(0x0, 0x10, 0x3c, 0x98);
		}
		public void SetSpeed(float maxSpeed, float accGround, float accAir, float waterSpeed, float bashSpeed, float stompSpeed, float wallJumpImp, float chargeJumpSpeed, float wallChargeJumpSpeed, float jumpHeight, float climbSpeed, float dashSpeed, float chargeDashSpeed) {
			seinCharacter.Write(accGround, 0x0, 0x48, 0x14, 0x28, 0x8, 0x8);
			seinCharacter.Write(accGround / 2f, 0x0, 0x48, 0x14, 0x28, 0x8, 0xc);
			seinCharacter.Write(maxSpeed, 0x0, 0x48, 0x14, 0x28, 0x8, 0x10);

			seinCharacter.Write(accAir, 0x0, 0x48, 0x14, 0x28, 0xc, 0x8);
			seinCharacter.Write(accAir, 0x0, 0x48, 0x14, 0x28, 0xc, 0xc);
			seinCharacter.Write(maxSpeed, 0x0, 0x48, 0x14, 0x28, 0xc, 0x10);

			seinCharacter.Write(waterSpeed, 0x0, 0x10, 0x3c, 0x98);

			seinCharacter.Write(bashSpeed, 0x0, 0x10, 0x50, 0x88);

			seinCharacter.Write(stompSpeed, 0x0, 0x10, 0x20, 0x7c);

			seinCharacter.Write(wallJumpImp, 0x0, 0x10, 0x10, 0x44);
			seinCharacter.Write(wallJumpImp * 2, 0x0, 0x10, 0x10, 0x48);

			seinCharacter.Write(chargeJumpSpeed, 0x0, 0x10, 0x18, 0x4c);
			seinCharacter.Write(wallChargeJumpSpeed, 0x0, 0x10, 0x1c, 0x48);

			if (jumpHeight == 3f) {
				seinCharacter.Write(3f, 0x0, 0x10, 0xc, 0x60);
				seinCharacter.Write(3f, 0x0, 0x10, 0xc, 0x54);
				seinCharacter.Write(3f, 0x0, 0x10, 0xc, 0x64);
				seinCharacter.Write(3.75f, 0x0, 0x10, 0xc, 0x70);
				seinCharacter.Write(4.25f, 0x0, 0x10, 0xc, 0x74);
				seinCharacter.Write(4.25f, 0x0, 0x10, 0xc, 0x58);
			} else {
				seinCharacter.Write(jumpHeight, 0x0, 0x10, 0xc, 0x60);
				seinCharacter.Write(jumpHeight, 0x0, 0x10, 0xc, 0x54);
				seinCharacter.Write(jumpHeight, 0x0, 0x10, 0xc, 0x64);
				seinCharacter.Write(jumpHeight, 0x0, 0x10, 0xc, 0x70);
				seinCharacter.Write(jumpHeight, 0x0, 0x10, 0xc, 0x74);
				seinCharacter.Write(jumpHeight * 2f, 0x0, 0x10, 0xc, 0x58);
			}

			seinCharacter.Write(climbSpeed, 0x0, 0x10, 0x30, 0x5c);
			seinCharacter.Write(climbSpeed, 0x0, 0x10, 0x30, 0x60);

			seinCharacter.Write(dashSpeed, 0x0, 0x10, 0x80, 0x20, 0x8, 0x84);
			seinCharacter.Write(chargeDashSpeed, 0x0, 0x10, 0x80, 0x24, 0x8, 0x84);
		}
		public PointF CurrentSpeed() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = seinCharacter.Read<float>(0x0, 0x48, 0x10, 0xbc);
			float py = seinCharacter.Read<float>(0x0, 0x48, 0x10, 0xc0);
			bool onGround = seinCharacter.Read<bool>(0x0, 0x48, 0x10, 0x18, 0x9);
			float gravityAngle = seinCharacter.Read<float>(0x0, 0x48, 0x10, 0xb8);
			float gx = seinCharacter.Read<float>(0x0, 0x48, 0x10, 0x60);
			float gy = seinCharacter.Read<float>(0x0, 0x48, 0x10, 0x64);
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
			if (coreInput.Value == IntPtr.Zero) { return new PointF(); }
			float mx = coreInput.Read<float>();
			float my = coreInput.Read<float>(0x4);
			return new PointF(mx, my);
		}
		public void ActivateRainbowDash() {
			if (GetAbility("Dash") && rainbowDash.Value != IntPtr.Zero && !rainbowDash.Read<bool>()) {
				rainbowDash.Write(true);
			}
		}
		public PointF GetCameraTargetPosition() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = gameplayCamera.Read<float>(0x0, 0x14, 0x10);
			float py = gameplayCamera.Read<float>(0x0, 0x14, 0x14);
			return new PointF(px, py);
		}
		public Dictionary<string, bool> GetEvents() {
			IntPtr start = worldEvents.Value + 0x40;

			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in events) {
				results[pair.Key] = Program.Read<bool>(start + pair.Value);
			}
			return results;
		}
		public bool GetEvent(string name) {
			IntPtr start = worldEvents.Value + 0x40;
			int ev = events[name];
			return Program.Read<bool>(start + ev);
		}
		public Dictionary<string, bool> GetKeys() {
			IntPtr start = worldEvents.Value;

			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in keys) {
				results[pair.Key] = Program.Read<bool>(start + pair.Value);
			}
			return results;
		}
		public bool GetKey(string name) {
			IntPtr start = worldEvents.Value;
			int key = keys[name];
			return Program.Read<bool>(start + key);
		}
		public Dictionary<string, bool> GetAbilities() {
			IntPtr start = (IntPtr)seinCharacter.Read<uint>(0x00, 0x4c);

			Dictionary<string, bool> results = new Dictionary<string, bool>();
			foreach (var pair in abilities) {
				results[pair.Key] = Program.Read<bool>(start, pair.Value * 4, 0x08);
			}
			return results;
		}
		public bool GetAbility(string name) {
			IntPtr start = (IntPtr)seinCharacter.Read<uint>(0x00, 0x4c);
			int ability = abilities[name];
			return Program.Read<bool>(start, ability * 4, 0x08);
		}
		public void SetAbility(string name, bool enable) {
			IntPtr start = (IntPtr)seinCharacter.Read<uint>(0x00, 0x4c);
			int ability = abilities[name];
			Program.Write(start, enable, ability * 4, 0x08);
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
			if (gameWorld.Value != IntPtr.Zero) {
				IntPtr current = (IntPtr)gameWorld.Read<uint>(0x0, 0x1c);
				Area currentArea = GetArea(current);
				IntPtr listHead = (IntPtr)gameWorld.Read<uint>(0x0, 0x18, 0x08);
				int listSize = gameWorld.Read<int>(0x0, 0x18, 0x0c);

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
			if (gameWorld.Value != IntPtr.Zero) {
				return GetArea((IntPtr)gameWorld.Read<uint>(0x0, 0x1c));
			}
			return default(Area);
		}
		public decimal GetTotalMapCompletion() {
			decimal total = 0;
			int listSize = 0;
			if (gameWorld.Value != IntPtr.Zero) {
				IntPtr listHead = (IntPtr)gameWorld.Read<uint>(0x0, 0x18, 0x08);
				listSize = gameWorld.Read<int>(0x0, 0x18, 0x0c);
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
			IntPtr activeScenesHead = (IntPtr)scenesManager.Read<uint>(0x0, 0x14);
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
			return gameController.Read<bool>(0x0, 0x68) || gameController.Read<bool>(0x0, 0x69) || seinCharacter.Value == IntPtr.Zero || (GetCurrentLevel() == 0 && GetCurrentENMax() == 3 && GetCurrentHPMax() == 3);
		}
		public bool CanMove() {
			return !gameController.Read<bool>(0x0, 0x7c) && !gameController.Read<bool>(0x0, 0x7b) && !seinCharacter.Read<bool>(0x0, 0x18, 0x38) && !seinCharacter.Read<bool>(0x0, 0x18, 0x40);
		}
		public GameState GetGameState() {
			return (GameState)gameStateMachine.Read<int>(0x0, 0x14);
		}
		public int GetKeyStones() {
			return seinCharacter.Read<int>(0x00, 0x2c, 0x1c);
		}
		public int GetMapStones() {
			return seinCharacter.Read<int>(0x00, 0x2c, 0x20);
		}
		public int GetAbilityCells() {
			return seinCharacter.Read<int>(0x00, 0x2c, 0x24);
		}
		public int GetSkillPointsAvailable() {
			return seinCharacter.Read<int>(0x00, 0x38, 0x24);
		}
		public int GetCurrentLevel() {
			return seinCharacter.Read<int>(0x00, 0x38, 0x28);
		}
		public int GetExperience() {
			return seinCharacter.Read<int>(0x00, 0x38, 0x2c);
		}
		public int GetCurrentHP() {
			return (int)seinCharacter.Read<float>(0x00, 0x40, 0x0c, 0x1c);
		}
		public int GetCurrentHPMax() {
			return seinCharacter.Read<int>(0x00, 0x40, 0x0c, 0x20) / 4;
		}
		public float GetCurrentEN() {
			return seinCharacter.Read<float>(0x00, 0x3c, 0x20);
		}
		public float GetCurrentENMax() {
			return seinCharacter.Read<float>(0x00, 0x3c, 0x24);
		}
		public void SetTASCharacter(byte keyCode) {
			if (tas.Value != IntPtr.Zero) {
				tas.Write(keyCode);
			}
		}
		public int GetTASState() {
			return tas.Read<int>(-0x1c);
		}
		public string GetTASCurrentInput() {
			return tas.Read(0x4);
		}
		public string GetTASNextInput() {
			return tas.Read(0x8);
		}
		public string GetTASExtraInfo() {
			return tas.Read(0xc);
		}
		public PointF GetTASOriPositon() {
			if (!IsHooked) { return new PointF(0, 0); }

			float px = tas.Read<float>(0x20);
			float py = tas.Read<float>(0x24);
			return new PointF(px, py);
		}
		public bool HasTAS() {
			return tas.Value != IntPtr.Zero;
		}

		public bool HookProcess() {
			if (Program == null || Program.HasExited) {
				Process[] processes = Process.GetProcessesByName("OriDE");
				Program = processes.Length == 0 ? null : processes[0];
				if (processes.Length == 0 || Program.HasExited) {
					IsHooked = false;
					return IsHooked;
				}

				IsHooked = true;
			}

			return IsHooked;
		}
		public string GetPointer(string name) {
			switch (name) {
				case "GameWorld": return gameWorld.Value.ToString("X");
				case "GameplayCamera": return gameplayCamera.Value.ToString("X");
				case "WorldEvents": return worldEvents.Value.ToString("X");
				case "SeinCharacter": return seinCharacter.Value.ToString("X");
				case "ScenesManager": return scenesManager.Value.ToString("X");
				case "GameStateMachine": return gameStateMachine.Value.ToString("X");
				case "RainbowDash": return rainbowDash.Value.ToString("X");
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
	public enum MemVersion {
		None,
		V1
	}
	public enum MemPointer {
		GameController,
		ScenesManager,
		GameStateMachine,
		WorldEvents,
		SeinCharacter,
		GameplayCamera,
		GameWorld,
		RainbowDash,
		TAS,
		Input
	}
	public class ProgramPointer {
		private static Dictionary<MemVersion, Dictionary<MemPointer, string>> funcPatterns = new Dictionary<MemVersion, Dictionary<MemPointer, string>>() {
			{MemVersion.V1, new Dictionary<MemPointer, string>() {
					{MemPointer.GameController,   "8B05????????83EC086A0050E8????????83C41085C074208B450883EC0C50E8????????83C41083EC0C50E8????????83C410E9????????8B4D08B8????????89088B450883EC0C50|-71" },
					{MemPointer.ScenesManager,    "558BEC5783EC148B7D08B8????????893883EC0C57E8????????83C4108B05????????8B40208B40308945EC85FF0F84????????83EC0C68????????E8????????83C4108BC88B45EC897910|-65"},
					{MemPointer.GameStateMachine, "558BEC5783EC148B7D08B8????????8938E8????????83EC0868????????50E8????????83C41085C0741183EC0C57E8????????83C410E9????????E8????????83EC0868????????50E8????????83C41085C0740E83EC0C57|-79"},
					{MemPointer.WorldEvents,      "558BEC83EC08B8????????C60000B8????????C60000B8????????C60000B8????????C60000B8????????C60000B8????????C60000B8????????C60000B8????????C6000083EC0C6A00E8????????83C410B8????????C60000B8????????C60000B8????????C60000C9C3|-94"},
					{MemPointer.SeinCharacter,    "558BEC5783EC048B7D08B8????????8938B8????????893883EC0C68????????E8????????83C41083EC08578945F850E8????????83C4108B45F889473483EC0C57E8????????83C41083EC085057E8????????83C4108D65FC5FC9C3|-82"},
					{MemPointer.GameplayCamera,   "05480000008B08894DE88B4804894DEC8B40088945F08B05|-28"},
					{MemPointer.GameWorld,        "558BEC53575683EC0C8B7D08B8????????89388B47|-8"},
					{MemPointer.RainbowDash,      "EC535783EC108B7D08C687????????000FB605????????85C074|-7" },
					{MemPointer.TAS,              "558BEC53575683EC0CD9EED95DF00FB73D????????83EC0C6A02E8????????83C410D95DF083EC086AFF6A05E8????????83C4108BD883EC0C6A05E8|-43" },
					{MemPointer.Input,            "558BEC83EC488B05????????8B40188B40108945B8B8????????8B08894DC08B40048945C48D45C883EC0483EC088B4DC0890C248B4DC4894C240450E8????????83C40C8B45B88D4DD483EC0C83EC0C8B55C88914248B55CC|-67" }
			}},
		};
		private IntPtr pointer;
		public OriMemory Memory { get; set; }
		public MemPointer Name { get; set; }
		public MemVersion Version { get; set; }
		public bool AutoDeref { get; set; }
		private int lastID;
		private DateTime lastTry;
		public ProgramPointer(OriMemory memory, MemPointer pointer) {
			this.Memory = memory;
			this.Name = pointer;
			this.AutoDeref = true;
			lastID = memory.Program == null ? -1 : memory.Program.Id;
			lastTry = DateTime.MinValue;
		}

		public IntPtr Value {
			get {
				GetPointer();
				return pointer;
			}
		}
		public T Read<T>(params int[] offsets) where T : struct {
			return Memory.Program.Read<T>(Value, offsets);
		}
		public string Read(params int[] offsets) {
			if (!Memory.IsHooked) { return string.Empty; }

			bool is64bit = Memory.Program.Is64Bit();
			IntPtr p = IntPtr.Zero;
			if (is64bit) {
				p = (IntPtr)Memory.Program.Read<ulong>(Value, offsets);
			} else {
				p = (IntPtr)Memory.Program.Read<uint>(Value, offsets);
			}
			return Memory.Program.Read(p);
		}
		public void Write(int value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(long value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(double value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(float value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(short value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(byte value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		public void Write(bool value, params int[] offsets) {
			Memory.Program.Write(Value, value, offsets);
		}
		private void GetPointer() {
			if (!Memory.IsHooked) {
				pointer = IntPtr.Zero;
				Version = MemVersion.None;
				return;
			}

			if (Memory.Program.Id != lastID) {
				pointer = IntPtr.Zero;
				Version = MemVersion.None;
				lastID = Memory.Program.Id;
			}
			if (pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1)) {
				lastTry = DateTime.Now;
				pointer = GetVersionedFunctionPointer();
				if (pointer != IntPtr.Zero) {
					bool is64bit = Memory.Program.Is64Bit();
					pointer = (IntPtr)Memory.Program.Read<uint>(pointer);
					if (AutoDeref) {
						if (is64bit) {
							pointer = (IntPtr)Memory.Program.Read<ulong>(pointer);
						} else {
							pointer = (IntPtr)Memory.Program.Read<uint>(pointer);
						}
					}
				}
			}
		}
		private IntPtr GetVersionedFunctionPointer() {
			foreach (MemVersion version in Enum.GetValues(typeof(MemVersion))) {
				Dictionary<MemPointer, string> patterns = null;
				if (!funcPatterns.TryGetValue(version, out patterns)) { continue; }

				string pattern = null;
				if (!patterns.TryGetValue(Name, out pattern)) { continue; }

				IntPtr ptr = Memory.Program.FindSignatures(pattern)[0];
				if (ptr != IntPtr.Zero) {
					Version = version;
					return ptr;
				}
			}
			Version = MemVersion.None;
			return IntPtr.Zero;
		}
	}
}