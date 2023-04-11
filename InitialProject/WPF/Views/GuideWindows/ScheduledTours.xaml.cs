using InitialProject.Controller;
using InitialProject.Domain.Models;
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
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for ScheduledTours.xaml
    /// </summary>
    public partial class ScheduledTours : Window
    {

        public ObservableCollection<TourEvent> TodaysEvents { get; set; }
        private TourEventController _tourEventController;
        private TourReservationController _tourReservationController;

        public TourEvent SelectedTourEvent { get; set; }
        public ScheduledTours()
        {
            InitializeComponent();
            this.DataContext = this;
            _tourEventController = new TourEventController();
            _tourReservationController = new TourReservationController();

            TodaysEvents = new ObservableCollection<TourEvent>(_tourEventController.GetTourEventsInFuture());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (SelectedTourEvent != null)
            {
                _tourReservationController.CancelAllTourReservationsForTourEvent(SelectedTourEvent.Id);
                MessageBox.Show("Uspesno ste otkazali turu");
            }
            
            
        }
    }
}
