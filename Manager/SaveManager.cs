using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class SaveManager : Form {
		public SaveManager() {
			InitializeComponent();

			Assembly asm = Assembly.GetExecutingAssembly();
			Stream file = asm.GetManifestResourceStream("LiveSplit.OriDE.Manager.Images.kuroBG.png");
			if (file != null) {
				flowLayout.BackgroundImage = Image.FromStream(file);
			}

			GetAllSaves();
		}

		private void GetAllSaves() {
			Assembly asm = Assembly.GetExecutingAssembly();

			string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Ori and the Blind Forest DE\");
			string[] files = Directory.GetFiles(savePath, "*.sav", SearchOption.TopDirectoryOnly);

			flowLayout.SuspendLayout();

			int count = 0;
			for (int i = 0; i < files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(files[i]);

				if (name.IndexOf("bkup", StringComparison.OrdinalIgnoreCase) >= 0) { continue; }

				count++;
				SaveGameData save = new SaveGameData();
				save.Load(files[i]);

				SceneData data = save.Master[SaveEditor.SeinLevel];
				int currentLevel = data.GetInt((int)LevelInfo.CurrentLevel);
				int currentXP = data.GetInt((int)LevelInfo.Experience);
				int currentAP = data.GetInt((int)LevelInfo.AbilityPoints);

				PictureBox saveImage = new PictureBox();
				saveImage.Name = "image" + name;
				saveImage.Size = new Size(70, 64);
				saveImage.Cursor = Cursors.Hand;
				saveImage.TabStop = false;
				saveImage.Click += SaveImage_Click;
				saveImage.Tag = save;

				Stream file = asm.GetManifestResourceStream("LiveSplit.OriDE.Manager.Images." + save.AreaName + ".png");
				if (file != null) {
					saveImage.Image = Image.FromStream(file);
				}

				Label saveLabel = new Label();
				saveLabel.Name = "label" + name;
				saveLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				saveLabel.Size = new Size(110, 64);
				saveLabel.TextAlign = ContentAlignment.MiddleCenter;
				saveLabel.BackColor = Color.Transparent;
				saveLabel.Text = name + "\n" +
					save.Health + "/" + save.MaxHealth + " HP " + save.Energy + "/" + save.MaxEnergy + " EN\n" +
					"Lvl" + currentLevel + " " + currentXP + " XP " + currentAP + " AP\n" +
					(save.Hours > 0 ? save.Hours + ":" : "") + save.Minutes.ToString(save.Hours > 0 ? "00" : "0") + ":" + save.Seconds.ToString("00") + " " + save.Completion + "%";

				FlowLayoutPanel saveLayout = new FlowLayoutPanel();
				saveLayout.SuspendLayout();
				saveLayout.AutoSize = true;
				saveLayout.Controls.Add(saveImage);
				saveLayout.Controls.Add(saveLabel);
				saveLayout.FlowDirection = FlowDirection.LeftToRight;
				saveLayout.Name = "layout" + name;
				saveLayout.BackColor = Color.Transparent;
				
				flowLayout.Controls.Add(saveLayout);
			}

			foreach(Control c in flowLayout.Controls) {
				FlowLayoutPanel panel = c as FlowLayoutPanel;
				if(panel != null) {
					panel.ResumeLayout(false);
					panel.PerformLayout();
				}
			}

			flowLayout.ResumeLayout(false);
			flowLayout.PerformLayout();

			int sqSize = (int)Math.Ceiling(Math.Sqrt(count));
			if (count > sqSize * (sqSize - 1)) {
				this.ClientSize = new Size(sqSize * 200, sqSize * 78);
			} else {
				this.ClientSize = new Size((sqSize - 1) * 200, sqSize * 78);
			}
		}

		private void SaveImage_Click(object sender, EventArgs e) {
			try {
				using (SaveEditor editor = new SaveEditor()) {
					editor.Save = (SaveGameData)((PictureBox)sender).Tag;
					editor.ShowDialog(this);
				}

				flowLayout.SuspendLayout();

				foreach (Control c in flowLayout.Controls) {
					FlowLayoutPanel panel = c as FlowLayoutPanel;
					if (panel != null) {
						foreach (Control pc in panel.Controls) {
							PictureBox pb = pc as PictureBox;
							if (pb != null) {
								pb.Click -= SaveImage_Click;
							}
							pc.Dispose();
						}
						panel.Controls.Clear();
					}
				}

				flowLayout.Controls.Clear();
				flowLayout.ResumeLayout(false);
				flowLayout.PerformLayout();

				GetAllSaves();
			} catch { }
		}
	}
}