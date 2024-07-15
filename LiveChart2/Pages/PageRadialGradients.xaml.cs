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
    /// Логика взаимодействия для PageRadialGradients.xaml
    /// </summary>
    public partial class PageRadialGradients : Page
    {
        public PageRadialGradients()
        {
            InitializeComponent();
            DataContext = this;
        }

        private static readonly SKColor[] s_colors =
        {
            new SKColor(179, 229, 252),
            new SKColor(1, 87, 155)
        };

        public ISeries[] Series { get; set; } =
        {
            new PieSeries<int>
            {
                Name = "Maria",
                Values = new []{ 7 },
                Stroke = null,
                Fill = new RadialGradientPaint(s_colors),
                Pushout = 10,
                OuterRadiusOffset = 20
            },
            new PieSeries<int>
            {
                Name = "Charles",
                Values = new []{ 3 },
                Stroke = null,
                Fill = new RadialGradientPaint(new SKColor(255, 205, 210), new SKColor(183, 28, 28))
            }
        };
    }
}
