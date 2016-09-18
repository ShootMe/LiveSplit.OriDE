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
using System.Windows.Shapes;

namespace OriMap {
    /// <summary>
    /// Interaktionslogik für OriMap.xaml
    /// </summary>
    public partial class OriMapWindow : Window {
        private TranslateTransform mapTransform;
        const double FACTOR_X = 4.11;
        const double FACTOR_Y = 4.12;
        const float TRANSFORM_TO_ORIGIN_X = -4509;
        const float TRANSFORM_TO_ORIGIN_Y = -3975;

        public OriMapWindow() {
            InitializeComponent();
            mapTransform = new TranslateTransform();
            mapImage.RenderTransform = mapTransform;
        }

        public void setPos(System.Drawing.PointF pos) {
            mapTransform.X = ((-pos.X) * FACTOR_X + TRANSFORM_TO_ORIGIN_X) + this.ActualWidth / 2;
            mapTransform.Y = ((pos.Y) * FACTOR_Y + TRANSFORM_TO_ORIGIN_Y) + this.ActualHeight / 2;
        }
    }
}
