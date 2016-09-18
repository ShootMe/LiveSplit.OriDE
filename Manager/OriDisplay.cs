using System;
using System.Windows.Forms;
namespace LiveSplit.OriDE {
	public class OriDisplay {
        [STAThread]
		public static void Main(string[] args) {
			//try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new OriManager());
			//} catch (Exception ex) {
			//	Console.WriteLine(ex.ToString());
			//}
		}
	}
}