using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AccommodationReservationReschedulingWindow.xaml
    /// </summary>
    public partial class AccommodationReservationReschedulingWindow : Window
    {
        public ReservationRescheduleRequestController _reservationRescheduleRequestController;
        public AccommodationReservationController _accommodationReservationController;
        public User guest { get; set; }
        public string comment;
        public RequestStatusType status { get; set; }

        /*
        #region NotifyProperties
        private DateTime _selectedNewStartDate;
        public DateTime SelectedNewStartDate
        {
            get => _selectedNewStartDate;
            set
            {
                if (value != _selectedNewStartDate)
                {
                    _selectedNewStartDate = value;
                    OnPropertyChanged("SelectedNewStartDate");
                }
            }
        }

        private DateTime _selectedNewEndDate;
        public DateTime SelectedNewEndDate
        {
            get => _selectedNewEndDate;
            set
            {
                if (value != _selectedNewEndDate)
                {
                    _selectedNewEndDate = value;
                    OnPropertyChanged("SelectedNewEndDate");
                }
            }
        }

        #endregion
        */

        DateTime SelectedNewStartDate;
        private void NewStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedNewStartDate = (DateTime)e.AddedItems[0];
        }

        DateTime SelectedNewEndDate;
        private void NewEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedNewEndDate = (DateTime)e.AddedItems[0];
        }

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
        public AccommodationReservation reservation { get; set; }

        public AccommodationReservationReschedulingWindow(AccommodationReservation accommodationReservation, User user)
        {
            InitializeComponent();
            this.DataContext = this;
            guest = user;

            _reservationRescheduleRequestController = new ReservationRescheduleRequestController();
            _accommodationReservationController = new AccommodationReservationController();
            reservation = accommodationReservation;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SendRescheduleRequestButton_Click(object sender, RoutedEventArgs e)
        {
            comment = "";
            status = 0;
            ReservationRescheduleRequest reservationRescheduleRequest = new ReservationRescheduleRequest() { Reservation = reservation, Guest = guest, NewStart = SelectedNewStartDate, NewEnd = SelectedNewEndDate, Comment = comment, Status = status };
            _reservationRescheduleRequestController.Save(reservationRescheduleRequest);
            MessageBox.Show("Uspešno ste poslali zahtev za pomeranje rezervacije smeštaja!", "Poslato!", MessageBoxButton.OK);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
