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
		private bool allSkills = false;

		public OriRandomizer(OriMemory mem) {
			this.mem = mem;
			skills = new Skill[11];
			ClearRandomizer();
		}
		public void ClearRandomizer() {
			if (skills == null) { return; }

			skills = null;
			skillsGained.Clear();
			allSkills = false;

			treeHitboxes = new Dictionary<Skill, HitBox>() {
				{ Skill.Sein,        new HitBox("-165,-262,1,2") },
				{ Skill.WallJump,    new HitBox("-317,-302,5,5") },
				{ Skill.ChargeFlame, new HitBox("-53,-154,5,5") },
				{ Skill.Dash,        new HitBox("293,-252,5,5") },
				{ Skill.DoubleJump,  new HitBox("785,-405,5,5") },
				{ Skill.Bash,        new HitBox("532,333,5,5") },
				{ Skill.Stomp,       new HitBox("859,-89,5,5") },
				{ Skill.Glide,       new HitBox("-458,-14,5,5") },
				{ Skill.Climb,       new HitBox("-1189,-96,5,5") },
				{ Skill.ChargeJump,  new HitBox("-697,412,5,5") },
				{ Skill.Grenade,     new HitBox("69,-374,5,5") }
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
						mem.SetSkills(true);
						allSkills = true;
					} else {
						skillsGained.Add(skills[(int)tree.Key]);
						treeToRemove = tree.Key;
						touchingAnyTree = false;
					}

					break;
				}
			}

			if (treeToRemove != Skill.None) {
				treeHitboxes.Remove(treeToRemove);
			}
			if (!touchingAnyTree && allSkills) {
				allSkills = false;

				mem.SetSkills(false);
				mem.SetSkills(true, skillsGained.ToArray());
			}
		}
		public void UpdateRandomSkills(string seed) {
			TextTitle = "S: ";

			Random rnd = null;
			iteration = 0;
			if (string.IsNullOrEmpty(seed)) {
				seed = "Random";
				rnd = new Random();
				iteration = rnd.Next(1, 7087);
			} else if (int.TryParse(seed, out iteration)) {
				if (iteration < 1 || iteration > 7086) {
					iteration = (iteration % 7086) + 1;
				}
			} else {
				rnd = new Random(seed.GetHashCode());
				iteration = rnd.Next(1, 7087);
			}
			Seed = seed;
			TextTitle = seed + " - " + iteration;
			TextInfo = "Last Skill: N/A";

			skills = new Skill[11];
			skills[(int)Skill.Sein] = Skill.Sein;

			HashSet<Skill> usedSkills = new HashSet<Skill>();
			usedSkills.Add(Skill.Sein);

			IterateWallJump(iteration, usedSkills);
		}
		private int IterateWallJump(int count, HashSet<Skill> usedSkills) {
			List<Skill> treeSkills = new List<Skill>() { Skill.DoubleJump, Skill.Climb, Skill.ChargeJump };

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
				usedSkills.Add(pickedSkill);

				count--;

				usedSkills.Remove(pickedSkill);
			}

			return count;
		}
	}
}