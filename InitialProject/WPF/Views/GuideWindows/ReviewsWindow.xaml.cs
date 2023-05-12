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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for ReviewsWindow.xaml
    /// </summary>
    public partial class ReviewsWindow : Page
    {
        public ObservableCollection<GuideReview> Guests { get; set; }
        public GuideReviewController _guideReviewController;




        #region NotifyProperties
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private GuideReview _selectedGuest;

        public GuideReview SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                if (_selectedGuest != value)
                {
                    _selectedGuest = value;
                    OnPropertyChanged(nameof(SelectedGuest));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private bool _validity;
        public bool Validity
        {
            get => _validity;
            set
            {
                if (value != _validity)
                {
                    _validity = value;
                    OnPropertyChanged("Validity");
                }
            }
        }

        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                if (value != _header)
                {
                    _header = value;
                    OnPropertyChanged("Header");
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

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion



        public ReviewsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            _guideReviewController = new GuideReviewController();
            Guests = new ObservableCollection<GuideReview>(_guideReviewController.GetAll());
            

        }



        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {

            if (SelectedGuest != null)
            {
                ReviewsInformationWindow reviews = new ReviewsInformationWindow(SelectedGuest);
                this.NavigationService.Navigate(reviews);
            }

        }
    }
}
