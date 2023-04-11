using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.Enumerations;
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

namespace InitialProject.WPF.Views.Guest1Windows
{
    /// <summary>
    /// Interaction logic for AccommodationOwnerReviewWindow.xaml
    /// </summary>
    public partial class AccommodationOwnerReviewWindow : Window
    {
        public ObservableCollection<int> Grades { get; set; }
        public AccommodationOwnerReviewController _accommodationOwnerReviewController;
        public AccommodationReservationController _accommodationReservationController;

        public List<Domain.Models.Image> AllImages { get; set; }

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

        private int _selectedCorrectness;
        public int SelectedCorrectness
        {
            get => _selectedCorrectness;
            set
            {
                if (value != _selectedCorrectness)
                {
                    _selectedCorrectness = value;
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

        public AccommodationOwnerReviewWindow(AccommodationReservation accommodationReservation)
        {
            InitializeComponent();
            this.DataContext = this;

            _accommodationOwnerReviewController = new AccommodationOwnerReviewController();
            _accommodationReservationController = new AccommodationReservationController();
            reservation = accommodationReservation;
            Grades = new ObservableCollection<int>();
            Grades.Add(1);
            Grades.Add(2);
            Grades.Add(3);
            Grades.Add(4);
            Grades.Add(5);

            AllImages = new List<Domain.Models.Image>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (CleanlinessComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Niste uneli ocenu smestaja!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (CorrectnessComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Niste uneli ocenu vlasnika!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(CommentTextBox.Text))
            {
                MessageBox.Show("Niste uneli komentar", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AccommodationOwnerReview accommodationOwnerReview = new AccommodationOwnerReview() { Reservation = reservation, Cleanliness = SelectedCleanliness, Correctness = SelectedCorrectness, Comment = Comment, Images = AllImages };
                //_accommodationOwnerReviewController.Save(accommodationOwnerReview);
                _accommodationOwnerReviewController.SaveImages(accommodationOwnerReview);
                reservation.AccommodationReview = accommodationOwnerReview;
                _accommodationReservationController.Update(reservation);
                MessageBox.Show("Uspešno ste ocenili smeštaj i vlasnika!", "Ocenjeno!", MessageBoxButton.OK);
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ImagesButton_Click(object sender, RoutedEventArgs e)
        {
            ImageAddingWindow imageAddingWindow = new ImageAddingWindow(ImageResource.reservation, AllImages);
            imageAddingWindow.Show();
        }
    }
}
