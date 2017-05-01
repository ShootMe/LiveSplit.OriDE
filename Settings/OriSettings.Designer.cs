namespace LiveSplit.OriDE.Settings {
	partial class OriSettings {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btnAddSplit = new System.Windows.Forms.Button();
			this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
			this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.chkShowMapDisplay = new System.Windows.Forms.CheckBox();
			this.chkRainbowDash = new System.Windows.Forms.CheckBox();
			this.flowRandomizer = new System.Windows.Forms.FlowLayoutPanel();
			this.chkRandomizer = new System.Windows.Forms.CheckBox();
			this.txtSeed = new System.Windows.Forms.TextBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.flowMain.SuspendLayout();
			this.flowOptions.SuspendLayout();
			this.flowRandomizer.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddSplit
			// 
			this.btnAddSplit.Location = new System.Drawing.Point(3, 3);
			this.btnAddSplit.Name = "btnAddSplit";
			this.btnAddSplit.Size = new System.Drawing.Size(57, 21);
			this.btnAddSplit.TabIndex = 0;
			this.btnAddSplit.Text = "Add Split";
			this.btnAddSplit.UseVisualStyleBackColor = true;
			this.btnAddSplit.Click += new System.EventHandler(this.btnAddSplit_Click);
			// 
			// flowMain
			// 
			this.flowMain.AutoSize = true;
			this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowMain.Controls.Add(this.flowOptions);
			this.flowMain.Controls.Add(this.flowRandomizer);
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowMain.Location = new System.Drawing.Point(0, 0);
			this.flowMain.Margin = new System.Windows.Forms.Padding(0);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(311, 53);
			this.flowMain.TabIndex = 0;
			this.flowMain.WrapContents = false;
			// 
			// flowOptions
			// 
			this.flowOptions.AutoSize = true;
			this.flowOptions.Controls.Add(this.btnAddSplit);
			this.flowOptions.Controls.Add(this.chkShowMapDisplay);
			this.flowOptions.Controls.Add(this.chkRainbowDash);
			this.flowOptions.Location = new System.Drawing.Point(0, 0);
			this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
			this.flowOptions.Name = "flowOptions";
			this.flowOptions.Size = new System.Drawing.Size(311, 27);
			this.flowOptions.TabIndex = 0;
			// 
			// chkShowMapDisplay
			// 
			this.chkShowMapDisplay.AutoSize = true;
			this.chkShowMapDisplay.Location = new System.Drawing.Point(66, 3);
			this.chkShowMapDisplay.Name = "chkShowMapDisplay";
			this.chkShowMapDisplay.Size = new System.Drawing.Size(92, 17);
			this.chkShowMapDisplay.TabIndex = 1;
			this.chkShowMapDisplay.Text = "Map% Display";
			this.toolTips.SetToolTip(this.chkShowMapDisplay, "Adds a component that displays Map%");
			this.chkShowMapDisplay.UseVisualStyleBackColor = true;
			this.chkShowMapDisplay.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// chkRainbowDash
			// 
			this.chkRainbowDash.AutoSize = true;
			this.chkRainbowDash.Location = new System.Drawing.Point(164, 3);
			this.chkRainbowDash.Name = "chkRainbowDash";
			this.chkRainbowDash.Size = new System.Drawing.Size(144, 17);
			this.chkRainbowDash.TabIndex = 2;
			this.chkRainbowDash.Text = "Rainbow Dash Activated";
			this.toolTips.SetToolTip(this.chkRainbowDash, "Turns Ori\'s Dash trail into a rainbow");
			this.chkRainbowDash.UseVisualStyleBackColor = true;
			this.chkRainbowDash.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// flowRandomizer
			// 
			this.flowRandomizer.AutoSize = true;
			this.flowRandomizer.Controls.Add(this.chkRandomizer);
			this.flowRandomizer.Controls.Add(this.txtSeed);
			this.flowRandomizer.Location = new System.Drawing.Point(0, 27);
			this.flowRandomizer.Margin = new System.Windows.Forms.Padding(0);
			this.flowRandomizer.Name = "flowRandomizer";
			this.flowRandomizer.Size = new System.Drawing.Size(194, 26);
			this.flowRandomizer.TabIndex = 1;
			// 
			// chkRandomizer
			// 
			this.chkRandomizer.AutoSize = true;
			this.chkRandomizer.Location = new System.Drawing.Point(3, 3);
			this.chkRandomizer.Name = "chkRandomizer";
			this.chkRandomizer.Size = new System.Drawing.Size(82, 17);
			this.chkRandomizer.TabIndex = 0;
			this.chkRandomizer.Text = "Randomizer";
			this.toolTips.SetToolTip(this.chkRandomizer, "Activate the Randomizer that will switch Skills around in Ori");
			this.chkRandomizer.UseVisualStyleBackColor = true;
			this.chkRandomizer.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// txtSeed
			// 
			this.txtSeed.Location = new System.Drawing.Point(91, 3);
			this.txtSeed.MaxLength = 10;
			this.txtSeed.Name = "txtSeed";
			this.txtSeed.Size = new System.Drawing.Size(100, 20);
			this.txtSeed.TabIndex = 1;
			this.toolTips.SetToolTip(this.txtSeed, "Seed used for the Randomizer. Leave blank for a random seed each playthrough.");
			this.txtSeed.Visible = false;
			this.txtSeed.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
			// 
			// OriSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowMain);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "OriSettings";
			this.Size = new System.Drawing.Size(311, 53);
			this.Load += new System.EventHandler(this.OriSettings_Load);
			this.flowMain.ResumeLayout(false);
			this.flowMain.PerformLayout();
			this.flowOptions.ResumeLayout(false);
			this.flowOptions.PerformLayout();
			this.flowRandomizer.ResumeLayout(false);
			this.flowRandomizer.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAddSplit;
		private System.Windows.Forms.FlowLayoutPanel flowMain;
		private System.Windows.Forms.FlowLayoutPanel flowOptions;
		private System.Windows.Forms.CheckBox chkShowMapDisplay;
		private System.Windows.Forms.CheckBox chkRainbowDash;
		private System.Windows.Forms.FlowLayoutPanel flowRandomizer;
		private System.Windows.Forms.CheckBox chkRandomizer;
		private System.Windows.Forms.TextBox txtSeed;
		private System.Windows.Forms.ToolTip toolTips;
	}
}
