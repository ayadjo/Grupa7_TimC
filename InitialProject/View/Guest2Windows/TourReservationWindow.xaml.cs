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
using System.Collections.ObjectModel;

namespace InitialProject.View.Guest2Window
{
    /// <summary>
    /// Interaction logic for TourReservationWindow.xaml
    /// </summary>
    public partial class TourReservationWindow : Window
    {
        

        public TourReservationController tourReservationController;
        public TourEventController _tourEventController;

        public string AvailableSpotsText { get; set; }
        public int AvailableSpots { get; set; }
        public TourEvent SelectedTourEvent { get; set; }

        public string NumberOfPeople { get; set; }

        public ObservableCollection<TourEvent> TourEvents { get; set; }

        public TourReservationWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = this;

            tourReservationController = new TourReservationController();

            NumberOfPeople = "";
            _tourEventController = new TourEventController();

            TourEvents = new ObservableCollection<TourEvent>(_tourEventController.GetAllTourEventsForTour(tour));
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            AvailableSpots = _tourEventController.CheckAvailability(SelectedTourEvent);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
