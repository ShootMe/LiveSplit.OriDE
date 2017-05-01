namespace LiveSplit.OriDE {
	public class OriSplit {
		public string Field { get; set; }
		public string Value { get; set; }
		public bool ShouldSplit { get; set; }

		public OriSplit(string field, string value, bool shouldSplit = true) {
			this.Field = field;
			this.Value = value;
			this.ShouldSplit = shouldSplit;
		}

		public override string ToString() {
			return Field + " = " + Value + (ShouldSplit ? " Split" : "");
		}
	}
}