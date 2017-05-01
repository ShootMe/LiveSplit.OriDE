using System.Drawing;
using System.Globalization;
namespace LiveSplit.OriDE.Memory {
	public enum Skill {
		Sein,
		WallJump,
		ChargeFlame,
		Dash,
		DoubleJump,
		Bash,
		Stomp,
		Glide,
		Climb,
		ChargeJump,
		Grenade,
		None
	}
	public struct Scene {
		public string Name { get; set; }
		public bool Active { get; set; }
		public SceneState State { get; set; }

		public override string ToString() {
			return Name + " - " + State.ToString();
		}
	}

	public struct Area {
		public string Name { get; set; }
		public decimal Progress { get; set; }
		public bool Current { get; set; }

		public override string ToString() {
			return (string.IsNullOrEmpty(Name) ? "N/A" : Name) + " - " + Progress.ToString("0.00") + "%";
		}
	}
	public enum GameState {
		Logos,
		StartScreen,
		TitleScreen,
		InGame,
		WatchCutscenes,
		TrialEnd,
		Prologue
	}
	public enum SceneState {
		Disabling,
		Disabled,
		Loading,
		LoadingCancelled,
		Loaded
	}
	public class HitBox {
		public float X { get; set; }
		public float Y { get; set; }
		public float W { get; set; }
		public float H { get; set; }

		public HitBox(string cordinates) {
			string[] cords = cordinates.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
			if (cords.Length == 4) {
				float temp = 0;
				float.TryParse(cords[0], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out temp);
				this.X = temp;
				float.TryParse(cords[1], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out temp);
				this.Y = temp;
				float.TryParse(cords[2], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out temp);
				this.W = temp;
				float.TryParse(cords[3], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out temp);
				this.H = temp;
			} else {
				this.X = 0;
				this.Y = 0;
				this.W = 0;
				this.H = 0;
			}
		}
		public HitBox(PointF pos, float w, float h, bool center) {
			if (center) {
				this.X = pos.X - (w / 2);
				this.Y = pos.Y + (h / 2);
			} else {
				this.X = pos.X;
				this.Y = pos.Y;
			}

			this.W = w;
			this.H = h;
		}

		public PointF GetCenter() {
			return new PointF(X + (W / 2), Y - (H / 2));
		}

		public bool Intersects(HitBox other) {
			return X + W >= other.X && other.X + other.W >= X && Y - H <= other.Y && other.Y - other.H <= Y;
		}

		public override string ToString() {
			return string.Concat(X.ToString("0.000", CultureInfo.CreateSpecificCulture("en-US")), ", ", Y.ToString("0.000", CultureInfo.CreateSpecificCulture("en-US")), ", ", W.ToString("0.000", CultureInfo.CreateSpecificCulture("en-US")), ", ", H.ToString("0.000", CultureInfo.CreateSpecificCulture("en-US")));
		}
	}
}