﻿using InitialProject.Controller;
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
    public partial class GuideReviewWindow : Window, INotifyPropertyChanged, IDataErrorInfo
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


            if (IsValid)
            {
                _guideReviewController.Save(guideReview);
                MessageBox.Show("Uspešno ste ocenili!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Neispravno uneti podaci!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private void SetReviewForGuideKnowledge(object sender, RoutedEventArgs e)
        {
            if (knowledge1.IsChecked == true)
                SelectedKnowledge = 1;
            else if (knowledge2.IsChecked == true)
                SelectedKnowledge = 2;
            else if (knowledge3.IsChecked == true)
                SelectedKnowledge = 3;
            else if (knowledge4.IsChecked == true)
                SelectedKnowledge = 4;
            else if (knowledge5.IsChecked == true)
                SelectedKnowledge = 5;
        }

        private void SetReviewForGuideLanguage(object sender, RoutedEventArgs e)
        {
            if (language1.IsChecked == true)
                SelectedLanguage = 1;
            else if (language2.IsChecked == true)
                SelectedLanguage = 2;
            else if (language3.IsChecked == true)
                SelectedLanguage = 3;
            else if (language4.IsChecked == true)
                SelectedLanguage = 4;
            else if (language5.IsChecked == true)
                SelectedLanguage = 5;
        }

        private void SetReviewForGuideInterestingness(object sender, RoutedEventArgs e)
        {
            if (interestingness1.IsChecked == true)
                SelectedInterestingness = 1;
            else if (interestingness2.IsChecked == true)
                SelectedInterestingness = 2;
            else if (interestingness3.IsChecked == true)
                SelectedInterestingness = 3;
            else if (interestingness4.IsChecked == true)
                SelectedInterestingness = 4;
            else if (interestingness5.IsChecked == true)
                SelectedInterestingness = 5;
        }

        //Validacija

        public string Error => null;

        public string this[string columnName]
        {
            get
            {

                if (columnName == "Comment")
                {
                    if (string.IsNullOrEmpty(Comment))
                        return "Ovo polje ne sme biti prazno";
                }


                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Comment" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }
    }
}
