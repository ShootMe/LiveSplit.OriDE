using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OriMap {
    public class Marker {
        public bool Removed { get; set; } = false;
        public Point IngamePosition { get; set; } = new Point();
        public string Name { get; set; } = "Marker";
        public Color Color { get; set; } = Colors.Red;
    }
}
