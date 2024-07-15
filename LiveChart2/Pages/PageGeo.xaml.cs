using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
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
    /// Логика взаимодействия для PageGeo.xaml
    /// </summary>
    public partial class PageGeo : Page
    {
        private readonly IWeigthedMapLand _brazil;
        private readonly Random _r = new Random();
        public PageGeo()
        {
            InitializeComponent();

            var lands = new HeatLand[]
            {
            new HeatLand() { Name = "bra", Value = 13 },
            new HeatLand() { Name = "mex", Value = 10 },
            new HeatLand() { Name = "usa", Value = 15 },
            new HeatLand() { Name = "can", Value = 8 },
            new HeatLand() { Name = "ind", Value = 12 },
            new HeatLand() { Name = "deu", Value = 13 },
            new HeatLand() { Name= "jpn", Value = 15 },
            new HeatLand() { Name = "chn", Value = 14 },
            new HeatLand() { Name = "rus", Value = 11 },
            new HeatLand() { Name = "fra", Value = 8 },
            new HeatLand() { Name = "esp", Value = 7 },
            new HeatLand() { Name = "kor", Value = 10 },
            new HeatLand() { Name = "zaf", Value = 12 },
            new HeatLand() { Name = "are", Value = 13 }
            };

            Series = new HeatLandSeries[] { new HeatLandSeries { Lands = lands } };

            //DoRandomChanges();
            DataContext = this;
        }

        public HeatLandSeries[] Series { get; set; }

        private async void DoRandomChanges()
        {
            await Task.Delay(1000);

            while (true)
            {
                foreach (var shape in Series[0].Lands ?? Enumerable.Empty<IWeigthedMapLand>())
                {
                    shape.Value = _r.Next(0, 20);
                }

                await Task.Delay(500);
            }
        }
    }
}
