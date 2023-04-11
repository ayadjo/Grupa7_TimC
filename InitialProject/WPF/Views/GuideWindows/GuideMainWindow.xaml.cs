using InitialProject.Domain.Models;
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

        private void ScheduledToursButton_Click(object sender, RoutedEventArgs e)
        {

            ScheduledTours scheduledTours = new ScheduledTours();
            scheduledTours.Show();

        }

        private void ReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviews = new Reviews();
            reviews.Show();
        }

        private void TourStatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            TourStatistics tourStatistics = new TourStatistics();
            tourStatistics.Show();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

           
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            this.Close();

        }
    }
}
