using InitialProject.Controller;
using InitialProject.Enumerations;
using InitialProject.Domain.Models;
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
        public ObservableCollection<int> Grades { get; set; }
        public GuestReviewController _guestReviewController;
        public AccommodationReservationController _accommodationReservationController;

        #region NotifyProperties
        private int _selectedCleanliness;
        public int SelectedCleanliness
        {
            get => _selectedCleanliness;
            set
            {
                if (value != _selectedCleanliness)
                {
                    _selectedCleanliness = value;
                    OnPropertyChanged("SelectedCleanliness");
                }
            }
        }

        private int _selectedBehaviour;
        public int SelectedBehaviour
        {
            get => _selectedBehaviour;
            set
            {
                if (value != _selectedBehaviour)
                {
                    _selectedBehaviour = value;
                    OnPropertyChanged("SelectedBehaviour");
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
            Grades = new ObservableCollection<int>();
            Grades.Add(1);
            Grades.Add(2);
            Grades.Add(3);
            Grades.Add(4);
            Grades.Add(5);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            GuestReview guestReview = new GuestReview() {Reservation=reservation, Cleanliness = SelectedCleanliness, Behaviour = SelectedBehaviour, Comment = Comment };
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
