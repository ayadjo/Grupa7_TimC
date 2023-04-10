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
    /// Interaction logic for AccommodationReservationReschedulingSelectionWindow.xaml
    /// </summary>
    public partial class AccommodationReservationReschedulingSelectionWindow : Window
    {
        private readonly AccommodationReservationController _accommodationReservationController;

        public ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public AccommodationReservation SelectedAccommodationReservation { get; set; }

        public User guest { get; set; }

        public int userId;

        public AccommodationReservationReschedulingSelectionWindow(User user)
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

        private void AccommodationReservationReschedulingButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAccommodationReservation != null)
            {
                AccommodationReservationReschedulingWindow accommodationReservationReschedulingWindow = new AccommodationReservationReschedulingWindow(SelectedAccommodationReservation, guest);
                accommodationReservationReschedulingWindow.Show();
            }
            else
            {
                MessageBox.Show("Prvo morate odabrati smeštaj!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
