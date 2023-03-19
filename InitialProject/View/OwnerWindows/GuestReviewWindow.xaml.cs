using InitialProject.Controller;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InitialProject.View.OwnerWindows
{
    /// <summary>
    /// Interaction logic for GuestReviewWindow.xaml
    /// </summary>
    public partial class GuestReviewWindow : Window, INotifyPropertyChanged
    {
        public GuestReviewController _guestReviewController;
        public AccommodationReservationController _accommodationReservationController;

        #region NotifyProperties
        private int _cleanliness;
        public int Cleanliness
        {
            get => _cleanliness;
            set
            {
                if (value != _cleanliness)
                {
                    _cleanliness = value;
                    OnPropertyChanged("Cleanliness");
                }
            }
        }
        private int _beahviour;
        public int Behaviour
        {
            get => _beahviour;
            set
            {
                if (value != _beahviour)
                {
                    _beahviour = value;
                    OnPropertyChanged("Behaviour");
                }
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (value != _comment)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
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
        public AccommodationReservation reservation { get; set; }
        public GuestReviewWindow(AccommodationReservation accommodationReservation)
        {
            InitializeComponent();
            this.DataContext = this;

            _guestReviewController = new GuestReviewController();
            _accommodationReservationController = new AccommodationReservationController();
            reservation = accommodationReservation;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            GuestReview guestReview = new GuestReview() {Reservation=reservation, Cleanliness = Cleanliness, Behaviour = Behaviour, Comment = Comment };
            _guestReviewController.Save(guestReview);
             reservation.Review = guestReview;
             _accommodationReservationController.Update(reservation);

             Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
