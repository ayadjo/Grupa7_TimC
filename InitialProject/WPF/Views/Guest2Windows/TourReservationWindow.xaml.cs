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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using InitialProject.Domain.Models;

namespace InitialProject.WPF.View.Guest2Window
{
    /// <summary>
    /// Interaction logic for TourReservationWindow.xaml
    /// </summary>
    public partial class TourReservationWindow : Window,INotifyPropertyChanged
    {
        

        public TourReservationController tourReservationController;
        public TourEventController _tourEventController;

        private string _availableSpotsText { get; set; }
        private int _availableSpots { get; set; }
        

        private TourEvent _selectedTourEvent;

        public string AvailableSpotsText
        {
            get => _availableSpotsText;
            set
            {
                if (_availableSpotsText != value)
                {
                    _availableSpotsText = value;
                    OnPropertyChanged("AvailableSpotsText");
                }
            }
        }

        public int AvailableSpots
        {
            get => _availableSpots;
            set
            {
                if (_availableSpots != value)
                {
                    _availableSpots = value;
                    OnPropertyChanged("AvailableSpots");
                }
            }
        }


        public TourEvent SelectedTourEvent
        {
            get => _selectedTourEvent;
            set
            {
                if (_selectedTourEvent != value)
                {
                    _selectedTourEvent = value;
                    OnPropertyChanged("SelectedTourEvent");
                }
            }
        }

        public int NumberOfPeople { get; set; }

        public TourPoint tourPointWhenGuestCame;

        public ObservableCollection<TourEvent> TourEvents { get; set; }

        public TourReservationWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = this;

            tourReservationController = new TourReservationController();

            //NumberOfPeople = "";
            _tourEventController = new TourEventController();

            TourEvents = new ObservableCollection<TourEvent>(tour.TourEvents);
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            if (AvailableSpots >= NumberOfPeople)
            {
                User user = new User() { Id = 1 };
                TourReservation tourReservation = new TourReservation(-1, NumberOfPeople, SelectedTourEvent, user, tourPointWhenGuestCame);
                tourReservationController.Create(tourReservation);
                MessageBox.Show("Uspesno ste izvrsili rezervaciju");
                Close();
            }
            else
            {
                MessageBox.Show("Nema dovoljno mesta");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTours(List<TourEvent> tourEvents)
        {
            TourEvents.Clear();
            foreach (TourEvent tourEvent in tourEvents)
            {
                TourEvents.Add(tourEvent);
            }
        }

        private void Check_Availability_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTourEvent == null)
            {
                return;
            }
            int reservedSpots = _tourEventController.CheckAvailability(SelectedTourEvent);
            AvailableSpots = SelectedTourEvent.Tour.MaxGuests - reservedSpots;
            if (AvailableSpots < NumberOfPeople)
            {
                AvailableSpotsText = "Nema dovoljno mesta";
                //TourEvents = new ObservableCollection<TourEvent>(_tourEventController.GetAll());
               
            }
            else
            {
                AvailableSpotsText = "Broj slobodnih:";
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Suggest_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedTourEvent == null)
            {
                return;
            }
            List<TourEvent> tourEventsForLocation = _tourEventController.GetAvailableTourEventsForLocation(SelectedTourEvent.Tour.Location, NumberOfPeople);
            RefreshTours(tourEventsForLocation);
        }
    }
}
