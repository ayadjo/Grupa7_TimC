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

namespace InitialProject.View.GuideWindows
{
    /// <summary>
    /// Interaction logic for TodaysToursOverviewWindow.xaml
    /// </summary>
    public partial class TodaysToursOverviewWindow : Window
    {
        public TodaysToursOverviewWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TourPointsWindow tourPointsWindow = new TourPointsWindow();
            tourPointsWindow.Show();
        }
    }
}
