using InitialProject.Controller;
using InitialProject.Observser;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationsOverview.xaml
    /// </summary>
    public partial class AccommodationsOverview : Window, IObserver
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
            _accommodationController.Subscribe(this);
            _locationController = new LocationController();

            Accommodations = new ObservableCollection<Accommodation>(_accommodationController.GetAccommodations());

            for (int i = 0; i < Accommodations.Count; ++i)
            {
                Accommodations[i].Location = _locationController.GetLocations().Find(a => a.Id == Accommodations[i].Location.Id);

            }
        }

        private void UpdateAccommodationsList()
        {
            Accommodations.Clear();
            foreach (var accommodation in _accommodationController.GetAccommodations())
            {
                Accommodations.Add(accommodation);
            }
        }

        public void Update()
        {
            UpdateAccommodationsList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = AccommodationSearchByNameTextBox.Text;
            string city = AccommodationSearchByLocationTextBox.Text;
            string type = AccommodationSearchByTypeTextBox.Text;
            string numberOfGuests = AccommodationSearchByNumberOfGuestsTextBox.Text;
            string numerOfDaysForReservation = AccommodationSearchByNumerOfDaysForReservationTextBox.Text;

            // Load the accommodations from the CSV file
            List<Accommodation> accommodations = _accommodationController.GetAccommodations();

            for (int i = 0; i < Accommodations.Count; ++i)
            {
                Accommodations[i].Location = _locationController.GetLocations().Find(a => a.Id == Accommodations[i].Location.Id);

            }

            // Filter accommodations by name
            List<Accommodation> filteredAccommodations = accommodations.Where(a => a.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                                                                                && a.MaxGuests.ToString().StartsWith(numberOfGuests, StringComparison.OrdinalIgnoreCase)
                                                                                && a.MinDaysForReservation.ToString().StartsWith(numerOfDaysForReservation, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Location.City.StartsWith(city, StringComparison.OrdinalIgnoreCase)
                                                                                && a.Type.ToString().StartsWith(type, StringComparison.OrdinalIgnoreCase)).ToList();

            // Display the filtered accommodations in the DataGridView
            AccommodationsDataGrid.ItemsSource = filteredAccommodations;
        }
    }
}
