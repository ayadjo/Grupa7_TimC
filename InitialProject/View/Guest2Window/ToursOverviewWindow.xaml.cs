using InitialProject.Controller;
using InitialProject.Model;
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

namespace InitialProject.View.Guest2Window
{
    /// <summary>
    /// Interaction logic for ToursOverviewWindow.xaml
    /// </summary>
    public partial class ToursOverviewWindow : Window
    {
       // private readonly TourController _tourcontroller;

        public ObservableCollection<Tour> Tours { get; set; }

       // public TourController _tourController;

        public Tour SelectedTour { get; set; }
        public ToursOverviewWindow()
        {
            InitializeComponent();

            DataContext = this;
            var app = Application.Current as App;

           // _tourcontroller = new TourController();

            //Tours = new ObservableCollection<Tour>(_tourcontroller.GetAllTours());
            
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
            /* if (SelectedTour != null)
             {
                 TourReservation tourReservation = new TourReservation();
                 tourReservation.Show();
             }
             else
             {
                 MessageBox.Show("Morate odabrati turu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
             }*/
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            /*
            string location = cbLocation.Text;
            //int numberOfPeople = tbNumberOfPeople.Text;
            string language = tbLanguage.Text;


            // Load the tour from the CSV file
            List<Tour> tours = _tourcontroller.GetAllTous();

            // Filter the tours by both location and language
            List<Tour> filteredTours = tours.Where(t => t.location.StartsWith(location, StringComparison.OrdinalIgnoreCase)
                                                                 && t.language.StartsWith(language, StringComparison.OrdinalIgnoreCase))
                                                       .ToList();

            // Display the filtered tours in the DataGridView
            tourOverview.ItemsSource = filteredTours;*/
        }
    }
}
