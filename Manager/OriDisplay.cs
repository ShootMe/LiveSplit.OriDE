using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public class OriDisplay {
		public static void Main(string[] args) {
			try {
				//string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Ori and the Blind Forest DE\");
				//SaveGameData save = new SaveGameData();
				//string lastSaveFile = Path.Combine(savePath, "saveFile2.sav");

				//save.Load(lastSaveFile);

				//SceneID abilities = new SceneID("4B417974465D2E6BE06A6D8DBD0F0BB3");
				//SceneData data = save.Master[abilities];
				//data[(int)Abilities.QuickFlame] = 1;
				//data[(int)Abilities.Rekindle] = 1;
				//data[(int)Abilities.Magnet] = 1;

				//SceneID levelInfo = new SceneID("44D72845AB790E021CC526C2EEAC82A5");
				//data = save.Master[levelInfo];
				//data.WriteInt((int)LevelInfo.CurrentLevel, 5);
				//data.WriteInt((int)LevelInfo.Experience, 250);
				//data.WriteInt((int)LevelInfo.AbilityPoints, 1);

				//SceneID saveInfo = new SceneID("4AA674A355CA54E9321AEAB78E4E5599");
				//data = save.Master[saveInfo];

				//data.WriteFloat((int)SaveInfo.PosX, 525);
				//data.WriteFloat((int)SaveInfo.PosY, 335);

				//data.WriteFloat((int)SaveInfo.SpeedX, 50);
				//data.WriteFloat((int)SaveInfo.SpeedY, 50000);

				//save.Save(lastSaveFile);
				//return;

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new OriManager());
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}
	}
}