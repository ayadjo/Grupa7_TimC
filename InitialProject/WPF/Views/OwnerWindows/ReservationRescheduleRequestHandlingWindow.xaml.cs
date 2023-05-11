using InitialProject.Controller;
using InitialProject.Domain.Models;
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

namespace InitialProject.WPF.Views.OwnerWindows
{
    /// <summary>
    /// Interaction logic for ReservationRescheduleRequestHandlingWindow.xaml
    /// </summary>
    public partial class ReservationRescheduleRequestHandlingWindow : Window, INotifyPropertyChanged
    {
        public ReservationRescheduleRequestController _reservationRescheduleRequestController;
        public AccommodationReservationController _accommodationReservationController;
       
        #region NotifyProperties
        private string _guest;
        public string Guest
        {
            get => _guest;
            set
            {
                if (value != _guest)
                {
                    _guest = value;
                    OnPropertyChanged("Guest");
                }
            }
        }

        private string _available;
        public string Available
        {
            get => _available;
            set
            {
                if (value != _available)
                {
                    _available = value;
                    OnPropertyChanged("Available");
                }
            }
        }
        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
        public ReservationRescheduleRequest rescheduleRequest { get; set; }

        public RelayCommand AcceptCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public ReservationRescheduleRequestHandlingWindow(ReservationRescheduleRequest reservationRescheduleRequest)
        {
            InitializeComponent();
            this.DataContext = this;

            _reservationRescheduleRequestController = new ReservationRescheduleRequestController();
            _accommodationReservationController = new AccommodationReservationController();

            rescheduleRequest = reservationRescheduleRequest;
            Guest = rescheduleRequest.Guest.FirstName + " " + rescheduleRequest.Guest.LastName;
            if (!_accommodationReservationController.IsReschedulePossible(rescheduleRequest))
            {
                Available = "Smeštaj je zauzet.";
                MessageBox.Show("Smeštaj je rezervisan u traženim datumima.");

            }
            else
            {
                Available = "Smeštaj je slobodan.";
            }

            AcceptCommand = new RelayCommand(AcceptRequestButton_Click, CanAccept);

            CancelCommand = new RelayCommand(DeclineRequestButton_Click);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanAccept(object param)
        {
            return true;
        }
        private void AcceptRequestButton_Click(object sender)
        {
            rescheduleRequest.Status = Enumerations.RequestStatusType.Approved;
            rescheduleRequest.Reservation.Start = rescheduleRequest.NewStart;
            rescheduleRequest.Reservation.End = rescheduleRequest.NewEnd;
            _accommodationReservationController.Update(rescheduleRequest.Reservation); 
            _reservationRescheduleRequestController.Update(rescheduleRequest);
            Close();
        }

        private void DeclineRequestButton_Click(object sender)
        {
            DeclineReservationRescheduleRequestCommentWindow Comment = new DeclineReservationRescheduleRequestCommentWindow(rescheduleRequest);
            Comment.Show();
            Close();

        }
    }
}
