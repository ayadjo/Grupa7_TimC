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
    /// Interaction logic for AccommodationOwnerReviewSelectionWindow.xaml
    /// </summary>
    public partial class AccommodationOwnerReviewSelectionWindow : Window
    {
        private readonly AccommodationReservationController _accommodationReservationController;

        public ObservableCollection<AccommodationReservation> AccommodationReservations { get; set; }
        public AccommodationReservation SelectedAccommodationReservation { get; set; }

        public User guest { get; set; }

        public int userId;

        public AccommodationOwnerReviewSelectionWindow(User user)
        {
            InitializeComponent();
            DataContext = this;

            guest = user;


            _accommodationReservationController = new AccommodationReservationController();

            AccommodationReservations = new ObservableCollection<AccommodationReservation>(_accommodationReservationController.GetAllReservationsWithoutAccommodationOwnerReview(guest.Id));
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now > SelectedAccommodationReservation.End.AddDays(5))
            {
                MessageBox.Show("Prošao je poslednji rok za ocenjivanje ovog smeštaja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AccommodationOwnerReviewWindow accommodationOwnerReviewWindow = new AccommodationOwnerReviewWindow(SelectedAccommodationReservation);
                accommodationOwnerReviewWindow.Show();
            }
        }
    }
}
