﻿using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.View.Guest2Window;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationsOverview.xaml
    /// </summary>
    public partial class AccommodationsOverview : Window
    {
        private readonly AccommodationController _accommodationController;
        private readonly LocationController _locationController;

        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public Accommodation SelectedAccommodation { get; set; }

        public AccommodationsOverview()
        {
            InitializeComponent();
            DataContext = this;

            _accommodationController = new AccommodationController();
            //_accommodationController.Subscribe(this);
            _locationController = new LocationController();

            Accommodations = new ObservableCollection<Accommodation>(_accommodationController.GetAll());

            for (int i = 0; i < Accommodations.Count; ++i)
            {
                Accommodations[i].Location = _locationController.GetAll().Find(a => a.Id == Accommodations[i].Location.Id);

            }
        }

        private void UpdateAccommodationsList()
        {
            Accommodations.Clear();
            foreach (var accommodation in _accommodationController.GetAll())
            {
                Accommodations.Add(accommodation);
            }
        }

        public void Update()
        {
            UpdateAccommodationsList();
        }
        

        /*
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string name = AccommodationSearchByNameTextBox.Text;
            string country = AccommodationSearchByCountryTextBox.Text;
            string city = AccommodationSearchByCityTextBox.Text;
            string type = AccommodationSearchByTypeTextBox.Text;
            string numberOfGuests = AccommodationSearchByNumberOfGuestsTextBox.Text;
            string numerOfDaysForReservation = AccommodationSearchByNumerOfDaysForReservationTextBox.Text;

            // Load the accommodations from the CSV file
            List<Accommodation> accommodations = _accommodationController.GetAll();

            for (int i = 0; i < Accommodations.Count; ++i)
            {
                Accommodations[i].Location = _locationController.GetAll().Find(a => a.Id == Accommodations[i].Location.Id);

            }

            // Filter accommodations by name
            List<Accommodation> filteredAccommodations = accommodations.Where(a => a.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                                                                                && a.MaxGuests.ToString().StartsWith(numberOfGuests, StringComparison.OrdinalIgnoreCase)
                                                                                && a.MinDaysForReservation.ToString().StartsWith(numerOfDaysForReservation, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Location.City.StartsWith(city, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Location.Country.StartsWith(country, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Type.ToString().StartsWith(type, StringComparison.OrdinalIgnoreCase)).ToList();

            // Display the filtered accommodations in the DataGridView
            AccommodationsDataGrid.ItemsSource = filteredAccommodations;
        }
        */

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string name = AccommodationSearchByNameTextBox.Text;
            string country = AccommodationSearchByCountryTextBox.Text;
            string city = AccommodationSearchByCityTextBox.Text;
            string type = AccommodationSearchByTypeTextBox.Text;

            int numberOfGuests = 0;
            int numberOfDaysForReservation = 0;

            try
            {
                numberOfGuests = Convert.ToInt32(AccommodationSearchByNumberOfGuestsTextBox.Text);
            }
            catch
            {

            }

            try
            {
                numberOfDaysForReservation = Convert.ToInt32(AccommodationSearchByNumerOfDaysForReservationTextBox.Text);
            }
            catch
            {

            }

            // Load the accommodations from the CSV file
            List<Accommodation> accommodations = _accommodationController.GetAll();

            for (int i = 0; i < Accommodations.Count; ++i)
            {
                Accommodations[i].Location = _locationController.GetAll().Find(a => a.Id == Accommodations[i].Location.Id);

            }

            // Filter accommodations by name
            List<Accommodation> filteredAccommodations = accommodations.Where(a => a.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                                                                                && (a.MaxGuests >= numberOfGuests)
                                                                                && (a.MinDaysForReservation >= numberOfDaysForReservation)
                                                                                && a.Location.City.StartsWith(city, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Location.Country.StartsWith(country, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Type.ToString().StartsWith(type, StringComparison.OrdinalIgnoreCase)).ToList();

            // Display the filtered accommodations in the DataGridView
            AccommodationsDataGrid.ItemsSource = filteredAccommodations;
        }
















        /*
        public ObservableCollection<Accommodation> Accommodations { get; set; }

        public AccommodationController _accommodationController;
        public LocationController _locationController;

        public string Name { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public string Type { get; set; }

        public string MaxGuests { get; set; }

        public string MinDaysForReservation { get; set; }


        public Accommodation SelectedAccommodation { get; set; }
        public AccommodationsOverview()
        {
            InitializeComponent();

            this.DataContext = this;

            _accommodationController = new AccommodationController();

            Accommodations = new ObservableCollection<Accommodation>(_accommodationController.GetAll());
            Name = "";
            Country = "";
            City = "";
            Type = "";
            MaxGuests = "";
            MinDaysForReservation = "";

        }

        private void UpdateAccommodationsList()
        {
            
            //Accommodations.Clear();
            //foreach (var accommodation in _accommodationController.GetAll())
            //{
            //    Accommodations.Add(accommodation);
            //}
        }

        public void Update()
        {
            UpdateAccommodationsList();
        }

        
        //private void buttonReserve_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SelectedTour != null)
        //    {
        //        TourReservationWindow tourReservation = new TourReservationWindow();
        //        tourReservation.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Morate odabrati turu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        

        private void RefreshAccommodations(List<Accommodation> accommodations)
        {
            Accommodations.Clear();
            foreach (Accommodation accommodation in accommodations)
            {
                Accommodations.Add(accommodation);
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            List<Accommodation> searchedAccommodations = _accommodationController.AccommodationSearch(Name, Country, City, Type, MaxGuests, MinDaysForReservation);
            RefreshAccommodations(searchedAccommodations);
        }
        */
    }
}
