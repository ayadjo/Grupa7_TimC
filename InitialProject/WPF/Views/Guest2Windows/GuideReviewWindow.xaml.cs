using InitialProject.Controller;
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
using System.Xml.Linq;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for GuideReviewWindow.xaml
    /// </summary>
    public partial class GuideReviewWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<int> Grades { get; set; }
        public ObservableCollection<string> Images { get; set; }

        public GuideReviewController _guideReviewController;
        public TourReservationController _tourReservationController;
        public ImageController _imageController;

        public TourReservation SelectedTourReservation { get; set; }

        public string SelectedUrl { get; set; }

        private int _selectedKnowledge;
        public int SelectedKnowledge
        {
            get => _selectedKnowledge;
            set
            {
                if (value != _selectedKnowledge)
                {
                    _selectedKnowledge = value;
                    OnPropertyChanged("SelectedKnowledge");
                }
            }
        }

        private int _selectedLanguage;
        public int SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value != _selectedLanguage)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged("SelectedLanguage");
                }
            }
        }

        private int _selectedInterestingness;
        public int SelectedInterestingness
        {
            get => _selectedInterestingness;
            set
            {
                if (value != _selectedInterestingness)
                {
                    _selectedInterestingness = value;
                    OnPropertyChanged("SelectedInterestingness");
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

        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                if (value != _url)
                {
                    _url = value;
                    OnPropertyChanged("Url");
                }
            }
        }


        public GuideReviewWindow(TourReservation tourReservation)
        {
            InitializeComponent();
            this.DataContext = this;

            _guideReviewController = new GuideReviewController();
            _tourReservationController = new TourReservationController();
            _imageController = new ImageController();

            Images = new ObservableCollection<string>();

            Grades = new ObservableCollection<int>();
            Grades.Add(1);
            Grades.Add(2);
            Grades.Add(3);
            Grades.Add(4);
            Grades.Add(5);

            SelectedTourReservation = tourReservation;
            SelectedKnowledge = 0;
            SelectedLanguage = 0;
            SelectedInterestingness = 0;
            //Comment = ""

        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> images = new List<string>(Images);
            GuideReview guideReview = new GuideReview(-1,SelectedTourReservation,SelectedKnowledge,SelectedLanguage,SelectedInterestingness,Comment,images,false);  

            List<GuideReview> userReviews = _guideReviewController.GetReviewsForUser(SelectedTourReservation.Id, SignInForm.LoggedUser.Id);

            foreach (GuideReview userReview in userReviews)
            {
                if (guideReview != userReview)
                {
                    MessageBox.Show("Vec ste ocenili ovu turu.");
                    return;
                }
            }

            _guideReviewController.Save(guideReview);
            MessageBox.Show("Uspešno ste ocenili!");
            this.Close();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            Images.Add(Url);
            Url = "";
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUrl == null)
            {
                return;
            }
                
            Images.Remove(SelectedUrl);
            SelectedUrl = null;
        }
    }
}
