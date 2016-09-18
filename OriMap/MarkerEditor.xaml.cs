using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OriMap {
    /// <summary>
    /// Interaktionslogik für MarkerEditor.xaml
    /// </summary>
    public partial class MarkerEditor : Window {
        private Marker _marker = null;

        public void setMarker(Marker marker) {
            _marker = marker;
            colorBorder.Background = new SolidColorBrush(_marker.Color);
            nameTextBox.Text = _marker.Name;
            positionLabel.Content = _marker.IngamePosition.ToString();
        }

        public Marker getMarker() {
            return _marker;
        }

        public MarkerEditor() {
            InitializeComponent();
        }

        private void changeColorButton_Click(object sender, RoutedEventArgs e) {
            if (_marker == null) return;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                _marker.Color = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                colorBorder.Background = new SolidColorBrush(_marker.Color);
            }
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (_marker == null) return;
            _marker.Name = nameTextBox.Text;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            Close();
        }
    }
}
