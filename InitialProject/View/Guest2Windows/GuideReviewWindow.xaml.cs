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

namespace InitialProject.View.Guest2Windows
{
    /// <summary>
    /// Interaction logic for GuideReviewWindow.xaml
    /// </summary>
    public partial class GuideReviewWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<int> Grades { get; set; }
        public GuideReviewController _guideReviewController;
        public TourReservationController _tourReservationController;
        //public ImageController _imageController;

        public TourReservation TourReservation{ get; set; }

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


        public GuideReviewWindow(TourReservation selectedReservation)
        {
            InitializeComponent();
            this.DataContext = this;

            _guideReviewController = new GuideReviewController();
            _tourReservationController = new TourReservationController();
            //_imageController = new ImageController();

            Grades = new ObservableCollection<int>();
            Grades.Add(1);
            Grades.Add(2);
            Grades.Add(3);
            Grades.Add(4);
            Grades.Add(5);

            

        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            GuideReview guideReview = new GuideReview() { Reservation = TourReservation, Knowledge = SelectedKnowledge, Language = SelectedLanguage, Interestingness = SelectedInterestingness, Comment = Comment };
            _guideReviewController.Save(guideReview);
            TourReservation.GuideReview = guideReview;
            _tourReservationController.Update(TourReservation);

            Close();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
