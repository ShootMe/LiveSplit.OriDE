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
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.rdSortGame = new System.Windows.Forms.RadioButton();
			this.rdSortAlpha = new System.Windows.Forms.RadioButton();
			this.lblSort = new System.Windows.Forms.Label();
			this.flowMain.SuspendLayout();
			this.flowOptions.SuspendLayout();
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
			this.flowMain.AllowDrop = true;
			this.flowMain.AutoSize = true;
			this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowMain.Controls.Add(this.flowOptions);
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowMain.Location = new System.Drawing.Point(0, 0);
			this.flowMain.Margin = new System.Windows.Forms.Padding(0);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(452, 27);
			this.flowMain.TabIndex = 0;
			this.flowMain.WrapContents = false;
			this.flowMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowMain_DragDrop);
			this.flowMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowMain_DragEnter);
			this.flowMain.DragOver += new System.Windows.Forms.DragEventHandler(this.flowMain_DragOver);
			// 
			// flowOptions
			// 
			this.flowOptions.AutoSize = true;
			this.flowOptions.Controls.Add(this.btnAddSplit);
			this.flowOptions.Controls.Add(this.chkShowMapDisplay);
			this.flowOptions.Controls.Add(this.chkRainbowDash);
			this.flowOptions.Controls.Add(this.lblSort);
			this.flowOptions.Controls.Add(this.rdSortGame);
			this.flowOptions.Controls.Add(this.rdSortAlpha);
			this.flowOptions.Location = new System.Drawing.Point(0, 0);
			this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
			this.flowOptions.Name = "flowOptions";
			this.flowOptions.Size = new System.Drawing.Size(452, 27);
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
			this.chkRainbowDash.Size = new System.Drawing.Size(96, 17);
			this.chkRainbowDash.TabIndex = 2;
			this.chkRainbowDash.Text = "Rainbow Dash";
			this.toolTips.SetToolTip(this.chkRainbowDash, "Turns Ori\'s Dash trail into a rainbow");
			this.chkRainbowDash.UseVisualStyleBackColor = true;
			this.chkRainbowDash.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
			// 
			// rdSortGame
			// 
			this.rdSortGame.AutoSize = true;
			this.rdSortGame.Checked = true;
			this.rdSortGame.Location = new System.Drawing.Point(338, 3);
			this.rdSortGame.Name = "rdSortGame";
			this.rdSortGame.Size = new System.Drawing.Size(53, 17);
			this.rdSortGame.TabIndex = 3;
			this.rdSortGame.TabStop = true;
			this.rdSortGame.Text = "Game";
			this.rdSortGame.UseVisualStyleBackColor = true;
			// 
			// rdSortAlpha
			// 
			this.rdSortAlpha.AutoSize = true;
			this.rdSortAlpha.Location = new System.Drawing.Point(397, 3);
			this.rdSortAlpha.Name = "rdSortAlpha";
			this.rdSortAlpha.Size = new System.Drawing.Size(52, 17);
			this.rdSortAlpha.TabIndex = 4;
			this.rdSortAlpha.Text = "Alpha";
			this.rdSortAlpha.UseVisualStyleBackColor = true;
			this.rdSortAlpha.CheckedChanged += new System.EventHandler(this.rdSort_CheckedChanged);
			// 
			// lblSort
			// 
			this.lblSort.Location = new System.Drawing.Point(266, 0);
			this.lblSort.Name = "lblSort";
			this.lblSort.Size = new System.Drawing.Size(66, 21);
			this.lblSort.TabIndex = 5;
			this.lblSort.Text = "Sort Combo:";
			this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.Size = new System.Drawing.Size(452, 27);
			this.Load += new System.EventHandler(this.OriSettings_Load);
			this.flowMain.ResumeLayout(false);
			this.flowMain.PerformLayout();
			this.flowOptions.ResumeLayout(false);
			this.flowOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAddSplit;
		private System.Windows.Forms.FlowLayoutPanel flowMain;
		private System.Windows.Forms.FlowLayoutPanel flowOptions;
		private System.Windows.Forms.CheckBox chkShowMapDisplay;
		private System.Windows.Forms.CheckBox chkRainbowDash;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.Label lblSort;
		private System.Windows.Forms.RadioButton rdSortGame;
		private System.Windows.Forms.RadioButton rdSortAlpha;
	}
}
