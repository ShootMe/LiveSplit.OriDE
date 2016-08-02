using System;
using System.Threading;
namespace LiveSplit.OriDE {
	public class OriTest {
		private static OriComponent comp = new OriComponent();
		public static void Main(string[] args) {
			try {
				Thread t = new Thread(GetVals);
				t.IsBackground = true;
				t.Start();
				System.Windows.Forms.Application.Run();
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
			Console.ReadKey();
		}
		private static void GetVals() {
			try {
				while (true) {
					comp.GetValues();

					Thread.Sleep(5);
				}
			} catch(Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}
	}
}