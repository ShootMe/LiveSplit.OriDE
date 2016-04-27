namespace LiveSplit.OriDE.Settings {
	partial class OriSplitSettings {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OriSplitSettings));
			this.chkShouldSplit = new System.Windows.Forms.CheckBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.cboName = new System.Windows.Forms.ComboBox();
			this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// chkShouldSplit
			// 
			this.chkShouldSplit.AutoSize = true;
			this.chkShouldSplit.Location = new System.Drawing.Point(306, 5);
			this.chkShouldSplit.Name = "chkShouldSplit";
			this.chkShouldSplit.Size = new System.Drawing.Size(15, 14);
			this.chkShouldSplit.TabIndex = 5;
			this.ToolTips.SetToolTip(this.chkShouldSplit, "Split for this setting");
			this.chkShouldSplit.UseVisualStyleBackColor = true;
			// 
			// btnRemove
			// 
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.Location = new System.Drawing.Point(274, 2);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(26, 23);
			this.btnRemove.TabIndex = 4;
			this.ToolTips.SetToolTip(this.btnRemove, "Remove this setting");
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.Location = new System.Drawing.Point(242, 2);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(26, 23);
			this.btnDown.TabIndex = 3;
			this.ToolTips.SetToolTip(this.btnDown, "Move this setting down");
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// btnUp
			// 
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.Location = new System.Drawing.Point(210, 2);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(26, 23);
			this.btnUp.TabIndex = 2;
			this.ToolTips.SetToolTip(this.btnUp, "Move this setting up");
			this.btnUp.UseVisualStyleBackColor = true;
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(150, 3);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(54, 20);
			this.txtValue.TabIndex = 1;
			// 
			// cboName
			// 
			this.cboName.FormattingEnabled = true;
			this.cboName.Location = new System.Drawing.Point(3, 3);
			this.cboName.Name = "cboName";
			this.cboName.Size = new System.Drawing.Size(141, 21);
			this.cboName.TabIndex = 0;
			this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
			// 
			// OriSplitSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.chkShouldSplit);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cboName);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "OriSplitSettings";
			this.Size = new System.Drawing.Size(324, 28);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.CheckBox chkShouldSplit;
		public System.Windows.Forms.Button btnRemove;
		public System.Windows.Forms.Button btnDown;
		public System.Windows.Forms.Button btnUp;
		public System.Windows.Forms.TextBox txtValue;
		public System.Windows.Forms.ComboBox cboName;
		private System.Windows.Forms.ToolTip ToolTips;
	}
}
