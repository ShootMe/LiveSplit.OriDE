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
			this.btnAddSplit = new System.Windows.Forms.Button();
			this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
			this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.chkShowMapDisplay = new System.Windows.Forms.CheckBox();
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
			this.flowMain.AutoSize = true;
			this.flowMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowMain.Controls.Add(this.flowOptions);
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowMain.Location = new System.Drawing.Point(0, 0);
			this.flowMain.Margin = new System.Windows.Forms.Padding(0);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(161, 27);
			this.flowMain.TabIndex = 0;
			this.flowMain.WrapContents = false;
			// 
			// flowOptions
			// 
			this.flowOptions.AutoSize = true;
			this.flowOptions.Controls.Add(this.btnAddSplit);
			this.flowOptions.Controls.Add(this.chkShowMapDisplay);
			this.flowOptions.Location = new System.Drawing.Point(0, 0);
			this.flowOptions.Margin = new System.Windows.Forms.Padding(0);
			this.flowOptions.Name = "flowOptions";
			this.flowOptions.Size = new System.Drawing.Size(161, 27);
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
			this.chkShowMapDisplay.UseVisualStyleBackColor = true;
			this.chkShowMapDisplay.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
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
			this.Size = new System.Drawing.Size(161, 27);
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
	}
}
