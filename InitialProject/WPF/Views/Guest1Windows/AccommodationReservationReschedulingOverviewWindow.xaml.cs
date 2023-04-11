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
    /// Interaction logic for AccommodationReservationReschedulingOverviewWindow.xaml
    /// </summary>
    public partial class AccommodationReservationReschedulingOverviewWindow : Window
    {
        private readonly ReservationRescheduleRequestController _reservationRescheduleRequestController;

        public ObservableCollection<ReservationRescheduleRequest> StandByReservationRescheduleRequests { get; set; }
        public ObservableCollection<ReservationRescheduleRequest> ApprovedReservationRescheduleRequests { get; set; }
        public ObservableCollection<ReservationRescheduleRequest> DeclinedReservationRescheduleRequests { get; set; }

        public User guest { get; set; }

        public AccommodationReservationReschedulingOverviewWindow(User user)
        {
            InitializeComponent();
            DataContext = this;
            guest = user;

            _reservationRescheduleRequestController = new ReservationRescheduleRequestController();

            StandByReservationRescheduleRequests = new ObservableCollection<ReservationRescheduleRequest>(_reservationRescheduleRequestController.GetStandBy(guest.Id));
            ApprovedReservationRescheduleRequests = new ObservableCollection<ReservationRescheduleRequest>(_reservationRescheduleRequestController.GetApproved(guest.Id));
            DeclinedReservationRescheduleRequests = new ObservableCollection<ReservationRescheduleRequest>(_reservationRescheduleRequestController.GetDeclined(guest.Id));
        }

        /*
        private void UpdateRequestsList()
        {
            ReservationRescheduleRequests.Clear();
            foreach (var accommodation in _reservationRescheduleRequestController.GetAll())
            {
                ReservationRescheduleRequests.Add(accommodation);
            }
        }

        public void Update()
        {
            UpdateRequestsList();
        }
        */

        private void AccommodationReservationReschedulingSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReservationReschedulingSelectionWindow accommodationReservationReschedulingSelectionWindow = new AccommodationReservationReschedulingSelectionWindow(guest);
            accommodationReservationReschedulingSelectionWindow.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
