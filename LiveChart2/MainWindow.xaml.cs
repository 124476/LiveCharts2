using LiveChart2.Pages;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LiveChart2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int SelectedPage = 0;
        int maxPages = 6;
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Navigate(new PageAngl());
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedPage--;
            if (SelectedPage < 0)
                SelectedPage = maxPages;
            Refresh();
        }

        private void Refresh()
        {
            if (SelectedPage == 0)
                MyFrame.Navigate(new PageAngl());
            else if (SelectedPage == 1)
                MyFrame.Navigate(new PageGeo());
            else if (SelectedPage == 2)
                MyFrame.Navigate(new PagePolar());
            else if (SelectedPage == 3)
                MyFrame.Navigate(new PageRadialGradients());
            else if (SelectedPage == 4)
                MyFrame.Navigate(new PageConditionalDraw());
            else if (SelectedPage == 5)
                MyFrame.Navigate(new PageRealTime());
            else if (SelectedPage == 6)
                MyFrame.Navigate(new PageBaicHeat());
        }

        private void UpBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedPage++;
            if (SelectedPage > maxPages)
                SelectedPage = 0;
            Refresh();
        }
    }
}
