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
			this.txtValue = new System.Windows.Forms.TextBox();
			this.cboName = new System.Windows.Forms.ComboBox();
			this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
			this.picHandle = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picHandle)).BeginInit();
			this.SuspendLayout();
			// 
			// chkShouldSplit
			// 
			this.chkShouldSplit.AutoSize = true;
			this.chkShouldSplit.Location = new System.Drawing.Point(261, 5);
			this.chkShouldSplit.Name = "chkShouldSplit";
			this.chkShouldSplit.Size = new System.Drawing.Size(15, 14);
			this.chkShouldSplit.TabIndex = 5;
			this.ToolTips.SetToolTip(this.chkShouldSplit, "Split for this setting");
			this.chkShouldSplit.UseVisualStyleBackColor = true;
			// 
			// btnRemove
			// 
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.Location = new System.Drawing.Point(229, 2);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(26, 23);
			this.btnRemove.TabIndex = 4;
			this.ToolTips.SetToolTip(this.btnRemove, "Remove this setting");
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(169, 3);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(54, 20);
			this.txtValue.TabIndex = 1;
			// 
			// cboName
			// 
			this.cboName.FormattingEnabled = true;
			this.cboName.Location = new System.Drawing.Point(22, 3);
			this.cboName.Name = "cboName";
			this.cboName.Size = new System.Drawing.Size(141, 21);
			this.cboName.TabIndex = 0;
			this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
			// 
			// picHandle
			// 
			this.picHandle.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.picHandle.Image = ((System.Drawing.Image)(resources.GetObject("picHandle.Image")));
			this.picHandle.Location = new System.Drawing.Point(3, 4);
			this.picHandle.Name = "picHandle";
			this.picHandle.Size = new System.Drawing.Size(20, 20);
			this.picHandle.TabIndex = 6;
			this.picHandle.TabStop = false;
			this.picHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHandle_MouseDown);
			this.picHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHandle_MouseMove);
			// 
			// OriSplitSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.chkShouldSplit);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.cboName);
			this.Controls.Add(this.picHandle);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "OriSplitSettings";
			this.Size = new System.Drawing.Size(287, 28);
			((System.ComponentModel.ISupportInitialize)(this.picHandle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.CheckBox chkShouldSplit;
		public System.Windows.Forms.Button btnRemove;
		public System.Windows.Forms.TextBox txtValue;
		public System.Windows.Forms.ComboBox cboName;
		private System.Windows.Forms.ToolTip ToolTips;
		private System.Windows.Forms.PictureBox picHandle;
	}
}
