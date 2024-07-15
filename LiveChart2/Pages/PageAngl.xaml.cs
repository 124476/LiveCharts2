using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.VisualElements;
using LiveChartsCore;
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
using System.Windows.Threading;
using LiveChartsCore.SkiaSharpView.VisualElements;

namespace LiveChart2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAngl.xaml
    /// </summary>
    public partial class PageAngl : Page
    {
        public IEnumerable<ISeries> Series { get; set; }
        public IEnumerable<VisualElement<SkiaSharpDrawingContext>> VisualElements { get; set; }

        public NeedleVisual anglValue { get; set; }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public PageAngl()
        {

            InitializeComponent();
            anglValue = new NeedleVisual
            {
                Value = 0
            };

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);

            Refresh();
        }

        private void Refresh()
        {
            var sectionsOuter = 130;
            var sectionsWidth = 20;

            Series = GaugeGenerator.BuildAngularGaugeSections(
                new GaugeItem(60, s => SetStyle(sectionsOuter, sectionsWidth, s)),
                new GaugeItem(30, s => SetStyle(sectionsOuter, sectionsWidth, s)),
                new GaugeItem(10, s => SetStyle(sectionsOuter, sectionsWidth, s)));

            VisualElements = new VisualElement<SkiaSharpDrawingContext>[]
            {
                new AngularTicksVisual
                {
                    LabelsSize = 16,
                    LabelsOuterOffset = 15,
                    OuterOffset = 65,
                    TicksLength = 20
                },
                anglValue
            };

            DataContext = null;
            DataContext = this;
        }

        private static void SetStyle(
            double sectionsOuter, double sectionsWidth, PieSeries<ObservableValue> series)
        {
            series.OuterRadiusOffset = sectionsOuter;
            series.MaxRadialColumnWidth = sectionsWidth;
        }

        private void SetAngl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick -= SetAnglStop;
            dispatcherTimer.Tick += SetAnglStart;
            dispatcherTimer.Start();
        }

        private void SetAnglStart(object sender, EventArgs e)
        {
            if (anglValue.Value + 5 > 100)
                return;
            anglValue = new NeedleVisual
            {
                Value = anglValue.Value + 5
            };
            Refresh();
        }

        private void SetAngl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick += SetAnglStop;
            dispatcherTimer.Tick -= SetAnglStart;
            dispatcherTimer.Start();
        }

        private void SetAnglStop(object sender, EventArgs e)
        {
            if (anglValue.Value - 5 < 0)
                return;
            anglValue = new NeedleVisual
            {
                Value = anglValue.Value - 5
            };
            Refresh();
        }
    }
}
