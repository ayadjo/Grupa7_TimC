using InitialProject.Controller;
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
using InitialProject.Enumerations;
using InitialProject.Domain.Models;

namespace InitialProject.WPF.View.Guest2Window
{
    /// <summary>
    /// Interaction logic for ToursOverviewWindow.xaml
    /// </summary>
    public partial class ToursOverviewWindow : Window
    {
       

        public ObservableCollection<Tour> Tours { get; set; }

        public TourController _tourController;

        public string Country { get; set; }

        public string City { get; set; }

        public string Languages { get; set; }

        public string Duration { get; set; }
        
        public string NumberOfPeople { get; set; }


        public Tour SelectedTour { get; set; }
        public ToursOverviewWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            _tourController = new TourController();

            Tours = new ObservableCollection<Tour>(_tourController.GetAll());
            Country = "";
            City = "";
            Languages = "";
            Duration = "";
            NumberOfPeople = "";
            
        }

        private void UpdateToursList()
        {/*
            Tours.Clear();
            foreach (var tour in _tourcontroller.GetAllTours())
            {
                Tours.Add(tour);
            }*/
        }

        public void Update()
        {
            UpdateToursList();
        }


        private void buttonReserve_Click(object sender, RoutedEventArgs e)
        {
             if (SelectedTour != null)
             {
                 TourReservationWindow tourReservation = new TourReservationWindow(SelectedTour);
                 tourReservation.Show();
             }
             else
             {
                 MessageBox.Show("Morate odabrati turu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
             }
        }

        private void RefreshTours(List<Tour> tours)
        {
            Tours.Clear();
            foreach(Tour tour in tours)
            {
                Tours.Add(tour);
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

            List<Tour> searchedTours = _tourController.TourSearch(Country,City,Languages,NumberOfPeople,Duration);
            RefreshTours(searchedTours);
        }
    }
}
