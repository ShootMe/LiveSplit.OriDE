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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

namespace OriMap {
    /// <summary>
    /// Interaktionslogik für OriMap.xaml
    /// </summary>
    public partial class OriMapWindow : Window {
        private TranslateTransform mapTransform;
        private Point contextMenuPosition = new Point(0, 0);
        private Point currentPlayerPosition = new Point(0, 0);

        private List<Marker> markers = new List<Marker>();

        public OriMapWindow() {
            InitializeComponent();
            mapTransform = new TranslateTransform();
            mapGrid.RenderTransform = mapTransform;
        }

        public void setPos(System.Drawing.PointF pos) {
            currentPlayerPosition.X = pos.X;
            currentPlayerPosition.Y = pos.Y;
            mapTransform.X = ((-pos.X) * MapCalc.FACTOR_X + MapCalc.TRANSFORM_TO_ORIGIN_X) + mainGrid.ActualWidth / 2;
            mapTransform.Y = ((pos.Y) * MapCalc.FACTOR_Y + MapCalc.TRANSFORM_TO_ORIGIN_Y) + mainGrid.ActualHeight / 2;
        }

        private void loadMarkers() {
            markers.Clear();
            markersCanvas.Children.Clear();

            if (File.Exists("markers.xml")) {
                XDocument doc = XDocument.Load("markers.xml");
                foreach (XElement element in doc.Element("markers").Elements("marker")) {
                    Marker marker = new OriMap.Marker();
                    marker.Color = Color.FromRgb(
                        byte.Parse(element.Attribute("color_r").Value),
                        byte.Parse(element.Attribute("color_g").Value),
                        byte.Parse(element.Attribute("color_b").Value)
                    );
                    marker.IngamePosition = new Point(
                        double.Parse(element.Attribute("pos_x").Value, CultureInfo.GetCultureInfo("en-US")),
                        double.Parse(element.Attribute("pos_y").Value, CultureInfo.GetCultureInfo("en-US"))
                    );
                    marker.Name = element.Attribute("name").Value;
                    markers.Add(marker);
                }

                foreach (Marker marker in markers) {
                    UIMarker uiMarker = new UIMarker();
                    uiMarker.setMarker(marker);
                    markersCanvas.Children.Add(uiMarker);
                }
            }
        }

        private void saveMarkers() {
            XDocument doc = new XDocument();
            XElement root = new XElement("markers");

            foreach (Marker marker in markers) {
                if (marker.Removed) continue;

                XElement markerElement = new XElement("marker");

                markerElement.Add(new XAttribute("color_r", marker.Color.R.ToString()));
                markerElement.Add(new XAttribute("color_g", marker.Color.G.ToString()));
                markerElement.Add(new XAttribute("color_b", marker.Color.B.ToString()));
                markerElement.Add(new XAttribute("pos_x", marker.IngamePosition.X.ToString(CultureInfo.GetCultureInfo("en-US"))));
                markerElement.Add(new XAttribute("pos_y", marker.IngamePosition.Y.ToString(CultureInfo.GetCultureInfo("en-US"))));
                markerElement.Add(new XAttribute("name", marker.Name));

                root.Add(markerElement);
            }

            doc.Add(root);
            doc.Save("markers.xml");
        }

        public static Point GetMousePosition() {
            System.Drawing.Point point = System.Windows.Forms.Cursor.Position;
            return new Point(point.X, point.Y);
        }

        private void addNewMarkerAtPosition(Point pos) {
            Marker marker = new Marker();
            marker.IngamePosition = pos;
            marker.Color = Colors.Red;
            marker.Name = "New Marker";

            MarkerEditor editor = new MarkerEditor();
            editor.setMarker(marker);
            editor.Owner = this;

            if (editor.ShowDialog() == true) {
                UIMarker uiMarker = new UIMarker();
                markers.Add(marker);
                uiMarker.setMarker(editor.getMarker());
                markersCanvas.Children.Add(uiMarker);
            }
        }

        private void zoomInMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX *= 1.5;
            mapScale.ScaleY *= 1.5;
        }

        private void zoomOutMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX /= 1.5;
            mapScale.ScaleY /= 1.5;
        }

        private void resetZoomMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX = 1;
            mapScale.ScaleY = 1;
        }

        private void mainGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            contextMenuPosition = MapCalc.mapToIngame(mapGrid.PointFromScreen(GetMousePosition()));
            Console.WriteLine(contextMenuPosition);
        }

        private void addMarkerAtClickPositionMenuItem_Click(object sender, RoutedEventArgs e) {
            addNewMarkerAtPosition(contextMenuPosition);
        }

        private void addMarkerAtPlayerPositionMenuItem_Click(object sender, RoutedEventArgs e) {
            addNewMarkerAtPosition(currentPlayerPosition);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            saveMarkers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            loadMarkers();
        }
    }
}
