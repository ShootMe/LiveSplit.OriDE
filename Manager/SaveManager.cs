using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public partial class SaveManager : Form {
		public SaveManager() {
			InitializeComponent();

			Assembly asm = Assembly.GetExecutingAssembly();
			Stream file = asm.GetManifestResourceStream("LiveSplit.OriDE.Images.kuroBG.png");
			if (file != null) {
				flowLayout.BackgroundImage = Image.FromStream(file);
			}

			GetAllSaves();
		}

		private void GetAllSaves() {
			try {
				Assembly asm = Assembly.GetExecutingAssembly();

				string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Ori and the Blind Forest DE\");
				List<string> files = new List<string>(Directory.GetFiles(savePath, "*.sav", SearchOption.TopDirectoryOnly));
				files.Sort(delegate (string file1, string file2) {
					int f1 = 0;
					int.TryParse(Path.GetFileNameWithoutExtension(file1).Substring(8), out f1);
					int f2 = 0;
					int.TryParse(Path.GetFileNameWithoutExtension(file2).Substring(8), out f2);
					return f1 > f2 ? 1 : f1 < f2 ? -1 : 0;
				});

				bool shouldSuspend = this.Visible;
				if (shouldSuspend) { SuspendUpdate.Suspend(this); }

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
				toolTips.RemoveAll();

				int count = 0;
				for (int i = 0; i < files.Count; i++) {
					string name = Path.GetFileNameWithoutExtension(files[i]);

					if (name.IndexOf("bkup", StringComparison.OrdinalIgnoreCase) >= 0) { continue; }

					count++;
					SaveGameData save = new SaveGameData();
					try {
						save.Load(files[i]);
					} catch { continue; }

					SceneData data = save.Master[MasterAssets.SeinLevel];
					int currentLevel = (data?.GetInt((int)LevelInfo.CurrentLevel)).GetValueOrDefault(0);
					int currentXP = (data?.GetInt((int)LevelInfo.Experience)).GetValueOrDefault(0);
					int currentAP = (data?.GetInt((int)LevelInfo.AbilityPoints)).GetValueOrDefault(0);

					PictureBox saveImage = new PictureBox();
					saveImage.Name = "image" + name;
					saveImage.Size = new Size(70, 64);
					saveImage.Cursor = Cursors.Hand;
					saveImage.TabStop = false;
					saveImage.Click += SaveImage_Click;
					saveImage.Tag = save;

					data = save.Master[MasterAssets.SaveDescription];
					if (data != null) {
						toolTips.SetToolTip(saveImage, Encoding.GetEncoding(1252).GetString(data.Data));
					}

					Stream file = asm.GetManifestResourceStream("LiveSplit.OriDE.Images." + save.AreaName + ".png");
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

					if (data != null) {
						toolTips.SetToolTip(saveLabel, Encoding.GetEncoding(1252).GetString(data.Data));
					}

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

				foreach (Control c in flowLayout.Controls) {
					FlowLayoutPanel panel = c as FlowLayoutPanel;
					if (panel != null) {
						panel.ResumeLayout(true);
					}
				}

				flowLayout.ResumeLayout(true);

				int sqSize = (int)Math.Ceiling(Math.Sqrt(count));
				if (count > sqSize * (sqSize - 1)) {
					this.ClientSize = new Size(sqSize * 200, sqSize * 78);
				} else {
					this.ClientSize = new Size((sqSize - 1) * 200, sqSize * 78);
				}
				if (shouldSuspend) { SuspendUpdate.Resume(this); }
			} catch { }
		}
		private void SaveImage_Click(object sender, EventArgs e) {
			try {
				using (SaveEditor editor = new SaveEditor()) {
					editor.Save = (SaveGameData)((PictureBox)sender).Tag;
					editor.Save.Load(editor.Save.FilePath);
					editor.ShowDialog(this);
				}

				GetAllSaves();
			} catch { }
		}
		private void SaveManager_KeyDown(object sender, KeyEventArgs e) {
			try {
				if (e.KeyCode == Keys.F5) {
					GetAllSaves();
				}
			} catch { }
		}
	}
	public static class SuspendUpdate {
		private const int WM_SETREDRAW = 0x000B;

		public static void Suspend(Control control) {
			Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
			NativeWindow window = NativeWindow.FromHandle(control.Handle);
			window.DefWndProc(ref msgSuspendUpdate);
		}

		public static void Resume(Control control) {
			IntPtr wparam = new IntPtr(1);
			Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam, IntPtr.Zero);
			NativeWindow window = NativeWindow.FromHandle(control.Handle);
			window.DefWndProc(ref msgResumeUpdate);
			control.Refresh();
		}
	}
}