using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LiveChartsCore.ConditionalDraw;

namespace LiveChart2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageConditionalDraw.xaml
    /// </summary>
    public partial class PageConditionalDraw : Page
    {
        private readonly ObservableCollection<ObservableValue> _values = new ObservableCollection<ObservableValue>();
        public PageConditionalDraw()
        {
            InitializeComponent();

            var dangerPaint = new SolidColorPaint(SKColors.Red);

            _values = new ObservableCollection<ObservableValue>
                {
                    new ObservableValue(2), new ObservableValue(5), new ObservableValue(4), new ObservableValue(6), new ObservableValue(8), new ObservableValue(3), new ObservableValue(2), new ObservableValue(4), new ObservableValue(6)
                };

            var series = new ColumnSeries<ObservableValue>
            {
                Name = "Mary",
                Values = _values
            }
            .OnPointMeasured(point =>
            {
                if (point.Visual is null) return;

                var isDanger = point.Model?.Value > 5;

                point.Visual.Fill = isDanger
                    ? dangerPaint
                    : null;
            });

            Series = new ISeries[] { series };

            Randomize();
            DataContext = this;
        }

        public ISeries[] Series { get; set; }

        public RectangularSection[] Sections { get; set; } =
        {
        new RectangularSection
        {
            Label = "Danger zone!",
            LabelSize = 15,
            LabelPaint = new SolidColorPaint(SKColors.Red)
            {
                SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
            },
            Yj = 5,
            Fill = new SolidColorPaint(SKColors.Red.WithAlpha(50))
        }
    };

        public Axis[] Y { get; set; } =
        {
        new Axis { MinLimit = 0 }
    };

        private async void Randomize()
        {
            var r = new Random();

            while (true)
            {
                await Task.Delay(3000);

                foreach (var item in _values)
                {
                    item.Value = r.Next(0, 10);
                }
            }
        }
    }
}
