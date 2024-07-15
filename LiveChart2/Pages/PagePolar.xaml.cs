using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
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

namespace LiveChart2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePolar.xaml
    /// </summary>
    public partial class PagePolar : Page
    {
        public PagePolar()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ISeries[] Series { get; set; } =
        {
            new PolarLineSeries<int>
            {
                Values = new[] { 7, 5, 7, 5, 6 },
                LineSmoothness = 0,
                GeometrySize= 0,
                Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90))
            },
            new PolarLineSeries<int>
            {
                Values = new[] { 2, 7, 5, 9, 7 },
                LineSmoothness = 1,
                GeometrySize = 0,
                Fill = new SolidColorPaint(SKColors.Red.WithAlpha(90))
            }
        };

        public PolarAxis[] AngleAxes { get; set; } =
        {
            new PolarAxis
            {
                LabelsRotation = LiveCharts.TangentAngle,
                Labels = new[] { "first", "second", "third", "forth", "fifth" }
            }
        };
    }
}
