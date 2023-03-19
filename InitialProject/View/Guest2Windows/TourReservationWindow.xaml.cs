using InitialProject.Controller;
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
using InitialProject.Model;

namespace InitialProject.View.Guest2Window
{
    /// <summary>
    /// Interaction logic for TourReservationWindow.xaml
    /// </summary>
    public partial class TourReservationWindow : Window
    {
        public TourController tourController;
        public TourReservationController tourReservationController;

        public TourReservationWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = tour;
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {
            //TourNotificatioWindow tourNotification = new TourNotificatioWindow();
            //tourNotification.Show();
        }
    }
}
