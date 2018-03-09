namespace LiveSplit.OriDE {
	partial class SaveManager {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveManager));
			this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// flowLayout
			// 
			this.flowLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayout.Location = new System.Drawing.Point(0, 0);
			this.flowLayout.Name = "flowLayout";
			this.flowLayout.Size = new System.Drawing.Size(421, 219);
			this.flowLayout.TabIndex = 1;
			// 
			// SaveManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(421, 219);
			this.Controls.Add(this.flowLayout);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save Manager";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveManager_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flowLayout;
		private System.Windows.Forms.ToolTip toolTips;
	}
}