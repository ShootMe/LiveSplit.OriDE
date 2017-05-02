using LiveSplit.OriDE.Memory;
using System;
using System.Collections.Generic;
namespace LiveSplit.OriDE {
	public class OriRandomizer {
		public string TextTitle, TextInfo, Seed;
		private Skill[] skills;
		private OriMemory mem;
		private int iteration;
		private Dictionary<Skill, HitBox> treeHitboxes;
		private List<Skill> skillsGained = new List<Skill>();
		private Skill lastSkill = Skill.None;
		public bool Running { get { return skills != null; } }

		public OriRandomizer(OriMemory mem) {
			this.mem = mem;
			skills = new Skill[11];
			ClearRandomizer();
		}
		public void ClearRandomizer() {
			if (skills == null) { return; }

			skills = null;
			skillsGained.Clear();
			lastSkill = Skill.None;

			treeHitboxes = new Dictionary<Skill, HitBox>() {
				{ Skill.Sein,        new HitBox("-165,-262,1,2") },
				{ Skill.WallJump,    new HitBox("-317,-301,5,6") },
				{ Skill.ChargeFlame, new HitBox("-53,-153,5,6") },
				{ Skill.Dash,        new HitBox("293,-251,5,6") },
				{ Skill.DoubleJump,  new HitBox("785,-404,5,6") },
				{ Skill.Bash,        new HitBox("532,334,5,6") },
				{ Skill.Stomp,       new HitBox("859,-88,5,6") },
				{ Skill.Glide,       new HitBox("-458,-13,5,6") },
				{ Skill.Climb,       new HitBox("-1189,-95,5,6") },
				{ Skill.ChargeJump,  new HitBox("-697,413,5,6") },
				{ Skill.Grenade,     new HitBox("69,-373,5,6") }
			};
			UpdateRandomSkills(Seed);
		}
		public void Update() {
			HitBox ori = new HitBox(mem.GetCameraTargetPosition(), 0.68f, 1.15f, true);

			Skill treeToRemove = Skill.None;
			bool touchingAnyTree = false;
			foreach (KeyValuePair<Skill, HitBox> tree in treeHitboxes) {
				bool touchingTree = tree.Value.Intersects(ori);

				if (touchingTree) {
					touchingAnyTree = true;

					if (mem.CanMove()) {
						lastSkill = skills[(int)tree.Key];
						mem.SetSkills(true, lastSkill);
					} else {
						skillsGained.Add(lastSkill);
						treeToRemove = tree.Key;
						touchingAnyTree = false;
						TextInfo = GetSkillName(tree.Key) + " -> " + GetSkillName(lastSkill);
						if (!skillsGained.Contains(tree.Key)) {
							mem.SetSkills(false, tree.Key);
						}
					}

					break;
				}
			}

			if (treeToRemove != Skill.None) {
				treeHitboxes.Remove(treeToRemove);
				lastSkill = Skill.None;
			} else if (!touchingAnyTree && lastSkill != Skill.None) {
				mem.SetSkills(false, lastSkill);
				lastSkill = Skill.None;
			}
		}
		private string GetSkillName(Skill skill) {
			switch (skill) {
				case Skill.Sein: return "Spirit Flame";
				case Skill.WallJump: return "Wall Jump";
				case Skill.ChargeFlame: return "Charge Flame";
				case Skill.Dash: return "Dash";
				case Skill.DoubleJump: return "Double Jump";
				case Skill.Bash: return "Bash";
				case Skill.Stomp: return "Stomp";
				case Skill.Glide: return "Feather";
				case Skill.Climb: return "Climb";
				case Skill.ChargeJump: return "Charge Jump";
				case Skill.Grenade: return "Light Burst";
			}
			return "N/A";
		}
		public void UpdateRandomSkills(string seed) {
			Random rnd = null;
			iteration = 0;
			if (string.IsNullOrEmpty(seed)) {
				seed = "Random";
				rnd = new Random();
				iteration = rnd.Next(1, 49851);
			} else if (int.TryParse(seed, out iteration)) {
				if (iteration < 1 || iteration > 49850) {
					iteration = (iteration % 49850) + 1;
				}
			} else {
				rnd = new Random(seed.GetHashCode());
				iteration = rnd.Next(1, 49851);
			}
			Seed = seed;
			TextTitle = seed + " - " + iteration;
			TextInfo = "Last Skill: N/A";
			
			IterateSein(iteration);
		}
		private int IterateSein(int count) {
			HashSet<Skill> usedSkills = new HashSet<Skill>();
			skills = new Skill[11];

			//49850 with just sein, 1427794 with sein, stomp, and charge jump
			List<Skill> treeSkills = new List<Skill>() { Skill.Sein };

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.Sein] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateWallJump(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateWallJump(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if (usedSkills.Contains(Skill.ChargeJump)) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.WallJump && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				treeSkills.Add(Skill.DoubleJump);
				treeSkills.Add(Skill.Climb);
				treeSkills.Add(Skill.ChargeJump);
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.WallJump] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateChargeFlame(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateChargeFlame(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if (usedSkills.Contains(Skill.ChargeJump)) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.ChargeFlame && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				treeSkills.Add(Skill.ChargeJump);
				treeSkills.Add(Skill.Grenade);
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.ChargeFlame] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateDash(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateDash(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if (usedSkills.Contains(Skill.WallJump) || usedSkills.Contains(Skill.DoubleJump) || usedSkills.Contains(Skill.ChargeJump) || usedSkills.Contains(Skill.Climb)
				|| (usedSkills.Contains(Skill.Bash) && usedSkills.Contains(Skill.Grenade))) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.Dash && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				treeSkills.Add(Skill.WallJump);
				treeSkills.Add(Skill.DoubleJump);
				treeSkills.Add(Skill.ChargeJump);
				treeSkills.Add(Skill.Climb);
				if (usedSkills.Contains(Skill.Grenade)) { treeSkills.Add(Skill.Bash); }
				if (usedSkills.Contains(Skill.Bash)) { treeSkills.Add(Skill.Grenade); }
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.Dash] = pickedSkill;
				usedSkills.Add(pickedSkill);

				if ((usedSkills.Contains(Skill.WallJump) || usedSkills.Contains(Skill.DoubleJump) || usedSkills.Contains(Skill.ChargeJump) || usedSkills.Contains(Skill.Climb))
					&& (usedSkills.Contains(Skill.Grenade) || usedSkills.Contains(Skill.ChargeFlame) || usedSkills.Contains(Skill.Stomp))) {
					count = IterateDoubleJump(count, usedSkills);
				}

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateDoubleJump(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if ((usedSkills.Contains(Skill.ChargeJump) && usedSkills.Contains(Skill.Climb)) || (usedSkills.Contains(Skill.DoubleJump) && usedSkills.Contains(Skill.WallJump))) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.DoubleJump && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				if (usedSkills.Contains(Skill.ChargeJump)) { treeSkills.Add(Skill.Climb); }
				if (usedSkills.Contains(Skill.Climb)) { treeSkills.Add(Skill.ChargeJump); }
				if (usedSkills.Contains(Skill.DoubleJump)) { treeSkills.Add(Skill.WallJump); }
				if (usedSkills.Contains(Skill.WallJump) && !usedSkills.Contains(Skill.ChargeJump)) { treeSkills.Add(Skill.Climb); }
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.DoubleJump] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateBash(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateBash(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if (usedSkills.Contains(Skill.ChargeJump)
				|| (usedSkills.Contains(Skill.Bash) && (usedSkills.Contains(Skill.WallJump) || usedSkills.Contains(Skill.DoubleJump)))) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.Bash && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				treeSkills.Add(Skill.ChargeJump);
				if (usedSkills.Contains(Skill.Bash) && !usedSkills.Contains(Skill.WallJump)) { treeSkills.Add(Skill.WallJump); }
				if (usedSkills.Contains(Skill.Bash) && !usedSkills.Contains(Skill.DoubleJump)) { treeSkills.Add(Skill.DoubleJump); }
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.Bash] = pickedSkill;
				usedSkills.Add(pickedSkill);

				if (usedSkills.Contains(Skill.Stomp)) {
					count = IterateStomp(count, usedSkills);
				}

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateStomp(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>();
			if (usedSkills.Contains(Skill.Bash)) {
				foreach (Skill s in Enum.GetValues(typeof(Skill))) {
					if (s != Skill.Stomp && !usedSkills.Contains(s)) {
						treeSkills.Add(s);
					}
				}
			} else {
				treeSkills.Add(Skill.Bash);
			}

			for (int i = 0; i < treeSkills.Count && count > 0; i++) {
				Skill pickedSkill = treeSkills[i];
				skills[(int)Skill.Stomp] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateGlide(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateGlide(int count, HashSet<Skill> usedSkills) {
			foreach (Skill pickedSkill in Enum.GetValues(typeof(Skill))) {
				if (pickedSkill == Skill.Glide || usedSkills.Contains(pickedSkill) || count <= 0) { continue; }

				skills[(int)Skill.Glide] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateClimb(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateClimb(int count, HashSet<Skill> usedSkills) {
			foreach (Skill pickedSkill in Enum.GetValues(typeof(Skill))) {
				if (pickedSkill == Skill.Climb || usedSkills.Contains(pickedSkill) || count <= 0) { continue; }

				skills[(int)Skill.Climb] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateChargeJump(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateChargeJump(int count, HashSet<Skill> usedSkills) {
			foreach (Skill pickedSkill in Enum.GetValues(typeof(Skill))) {
				if (pickedSkill == Skill.ChargeJump || usedSkills.Contains(pickedSkill) || count <= 0) { continue; }

				skills[(int)Skill.ChargeJump] = pickedSkill;
				usedSkills.Add(pickedSkill);

				count = IterateGrenade(count, usedSkills);

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
		private int IterateGrenade(int count, HashSet<Skill> usedSkills) {
			foreach (Skill pickedSkill in Enum.GetValues(typeof(Skill))) {
				if (pickedSkill == Skill.Grenade || usedSkills.Contains(pickedSkill) || count <= 0) { continue; }

				skills[(int)Skill.Grenade] = pickedSkill;
				
				count--;
			}

			return count;
		}
	}
}