using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OriMap {
    /// <summary>
    /// Interaktionslogik für Marker.xaml
    /// </summary>
    public partial class UIMarker : UserControl {
        public UIMarker() {
            InitializeComponent();
        }

        private Marker _marker = null;

        public void setMarker(Marker marker) {
            setCanvasPosition(MapCalc.ingameToMap(marker.IngamePosition));
            SolidColorBrush brush = new SolidColorBrush(marker.Color);
            brush.Opacity = 0.5;
            ellipse.Fill = brush;
            label.Content = marker.Name;
            _marker = marker;
        }

        private void setCanvasPosition(Point mapPos) {
            Canvas.SetLeft(this, mapPos.X - 15);
            Canvas.SetTop(this, mapPos.Y - 15);
        }

        private void editMenuItem_Click(object sender, RoutedEventArgs e) {
            MarkerEditor editor = new MarkerEditor();
            editor.setMarker(_marker);
            if (editor.ShowDialog() == true) {
                setMarker(editor.getMarker());
            }
        }

        private void removeMenuItem_Click(object sender, RoutedEventArgs e) {
            _marker.Removed = true;
            this.Visibility = Visibility.Collapsed;
            ((Canvas)Parent).Children.Remove(this);
        }
    }
}
