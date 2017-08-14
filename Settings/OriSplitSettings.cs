using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace LiveSplit.OriDE.Settings {
	public partial class OriSplitSettings : UserControl {
		public string ControlType = "";
		private bool isDragging = false;
		private int mX = 0;
		private int mY = 0;
		public static SortedDictionary<string, string> DefaultSplits = new SortedDictionary<string, string>()
		{
			{"End of Forlorn Escape",    "-1162.265,-221.822,7.031,3.334"},
			{"End of Horu Escape",       "162.890,577.337,5.216,14.574"},
			{"Spirit Tree Reached",      "-96,-120,3,3"}
		};
		public static SortedDictionary<string, string> AvailableSplits = new SortedDictionary<string, string>()
		{
			{"Ability",                  "Value"},
			{"In Game",                  "Boolean"},
			{"In Menu",                  "Boolean"},
			{"Map %",                    "Value"},
			{"Hitbox",                   "Hitbox"},
			{"Start Game",               "Boolean"},
			{"Soul Flame",               "Boolean"},
			{"Spirit Flame",             "Boolean"},
			{"Wall Jump",                "Boolean"},
			{"Charge Flame",             "Boolean"},
			{"Darkness Lifted",          "Boolean"},
			{"Dash",                     "Boolean"},
			{"Double Jump",              "Boolean"},
			{"Bash",                     "Boolean"},
			{"Stomp",                    "Boolean"},
			{"Light Grenade",            "Boolean"},
			{"Glide",                    "Boolean"},
			{"Climb",                    "Boolean"},
			{"Charge Jump",              "Boolean"},
			{"Spirit Tree Reached",      "Hitbox"},
			{"Water Vein",               "Boolean"},
			{"Ginso Tree Entered",       "Boolean"},
			{"Clean Water",              "Boolean"}, // End of Escape
            {"Gumon Seal",               "Boolean"}, // Picked Up Seal
            {"Forlorn Ruins Entered",    "Boolean"},
			{"Wind Restored",            "Boolean"}, // Start of Escape
            {"End of Forlorn Escape",    "Hitbox"},  // End of Escape
            {"Sunstone",                 "Boolean"},
			{"Mount Horu Entered",       "Boolean"},
			{"Warmth Returned",          "Boolean"}, // Start of Escape
            {"End of Horu Escape",       "Hitbox"},  // End of Escape
            {"End Game",                 "Boolean"},
			{"Health Cells",             "Value"},
			{"Current Health",           "Value"},
			{"Energy Cells",             "Value"},
			{"Current Energy",           "Value"},
			{"Ability Cells",            "Value"},
			{"Level",                    "Value"},
			{"Key Stones",               "Value"},
			{"Valley 100%",              "Boolean"},
			{"Grotto 100%",              "Boolean"},
			{"Swamp 100%",               "Boolean"},
			{"Glades 100%",              "Boolean"},
			{"Sorrow 100%",              "Boolean"},
			{"Black Root 100%",          "Boolean"},
			{"Ginso 100%",               "Boolean"},
			{"Forlorn 100%",             "Boolean"},
			{"Horu 100%",                "Boolean"}
		};
		public OriSplitSettings() {
			InitializeComponent();
		}

		private void cboName_SelectedIndexChanged(object sender, EventArgs e) {
			bool isValue = cboName.SelectedValue.ToString().Equals("Value");
			bool isHitbox = cboName.SelectedValue.ToString().Equals("Hitbox");
			txtValue.Visible = isValue || isHitbox;

			int hitboxTextWidth = 130;
			int valueWidth = 60;

			if (ControlType == "Hitbox") {
				txtValue.Width -= hitboxTextWidth;
				btnRemove.Left -= hitboxTextWidth;
				chkShouldSplit.Left -= hitboxTextWidth;
			} else if (ControlType == "Boolean") {
				btnRemove.Left += valueWidth;
				chkShouldSplit.Left += valueWidth;
			}

			this.ControlType = cboName.SelectedValue.ToString();

			if (isValue) {
				txtValue.Text = "1";
			} else if (isHitbox) {
				txtValue.Text = "";
				txtValue.Focus();
				txtValue.Width += hitboxTextWidth;
				btnRemove.Left += hitboxTextWidth;
				chkShouldSplit.Left += hitboxTextWidth;
			} else {
				txtValue.Text = "True";
				btnRemove.Left -= valueWidth;
				chkShouldSplit.Left -= valueWidth;
			}

			if (DefaultSplits.ContainsKey(cboName.Text)) {
				txtValue.Text = DefaultSplits[cboName.Text];
			}
		}
		private void picHandle_MouseMove(object sender, MouseEventArgs e) {
			if (!isDragging) {
				if (e.Button == MouseButtons.Left) {
					int num1 = mX - e.X;
					int num2 = mY - e.Y;
					if (((num1 * num1) + (num2 * num2)) > 20) {
						DoDragDrop(this, DragDropEffects.All);
						isDragging = true;
						return;
					}
				}
			}
		}
		private void picHandle_MouseDown(object sender, MouseEventArgs e) {
			mX = e.X;
			mY = e.Y;
			isDragging = false;
		}
	}
}