using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;
namespace LiveSplit.OriDE {
    public class OriFactory : IComponentFactory {
        public string ComponentName { get { return "Ori DE Autosplitter v" + this.Version.ToString(); } }
        public string Description { get { return "Autosplitter for Ori DE"; } }
        public ComponentCategory Category { get { return ComponentCategory.Control; } }
        public IComponent Create(LiveSplitState state) { return new OriComponent(); }
        public string UpdateName { get { return this.ComponentName; } }
		public string UpdateURL { get { return "https://raw.githubusercontent.com/ShootMe/LiveSplit.OriDE/master/"; } }
		public string XMLURL { get { return this.UpdateURL + "Components/LiveSplit.OriDE.Updates.xml"; } }
		public Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
    }
}