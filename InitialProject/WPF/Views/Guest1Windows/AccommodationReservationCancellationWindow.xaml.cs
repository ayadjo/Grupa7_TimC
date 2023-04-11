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

namespace InitialProject.WPF.Views.Guest1Windows
{
    /// <summary>
    /// Interaction logic for AccommodationReservationCancellationWindow.xaml
    /// </summary>
    public partial class AccommodationReservationCancellationWindow : Window
    {
        private readonly AccommodationReservationController _accommodationReservationController;

        public ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public AccommodationReservation SelectedAccommodationReservation { get; set; }

        public User guest { get; set; }

        public int userId;

        public AccommodationReservationCancellationWindow(User user)
        {
            InitializeComponent();
            DataContext = this;

            guest = user;


            _accommodationReservationController = new AccommodationReservationController();

            AccommodationReservations = new ObservableCollection<AccommodationReservation>(_accommodationReservationController.GetByUserId(guest.Id));
        }

        private void UpdateAccommodationReservationsList()
        {
            AccommodationReservations.Clear();
            foreach (var accommodationReservation in _accommodationReservationController.GetAll())
            {
                AccommodationReservations.Add(accommodationReservation);
            }
        }

        public void Update()
        {
            UpdateAccommodationReservationsList();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelReservationButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAccommodationReservation != null)
            {
                if (DateTime.Now > SelectedAccommodationReservation.Start.AddDays(-SelectedAccommodationReservation.Accommodation.CancelationPeriod))
                {
                    MessageBox.Show("Prošao je krajnji rok za otkazivanje ove rezervacije!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (SelectedAccommodationReservation.Accommodation.CancelationPeriod == 0)
                {
                    if (DateTime.Now > SelectedAccommodationReservation.Start.AddDays(-1))
                    {
                        MessageBox.Show("Prošao je krajnji rok za otkazivanje ove rezervacije!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _accommodationReservationController.Delete(SelectedAccommodationReservation);
                        MessageBox.Show("Uspešno ste otkazali smeštaj!", "Otkazano!", MessageBoxButton.OK);
                        this.Close();
                    }
                }
                else
                {
                    _accommodationReservationController.Delete(SelectedAccommodationReservation);
                    MessageBox.Show("Uspešno ste otkazali smeštaj!", "Otkazano!", MessageBoxButton.OK);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Prvo morate izabrati rezervaciju!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
