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

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for GuideMainWindow.xaml
    /// </summary>
    public partial class GuideMainWindow : Window
    {
        public GuideMainWindow()
        {
            InitializeComponent();
        }

        private void MyTourssButton_Click(object sender, RoutedEventArgs e)
        {
            TourOverviewWindow tourOverviewWindow = new TourOverviewWindow();
            tourOverviewWindow.Show();
        }

        

     

        private void TodaysToursButton_Click(object sender, RoutedEventArgs e)
        {
            TodaysToursOverviewWindow todaysToursOverviewWindow = new TodaysToursOverviewWindow();
            todaysToursOverviewWindow.Show();   

        }
    }
}
