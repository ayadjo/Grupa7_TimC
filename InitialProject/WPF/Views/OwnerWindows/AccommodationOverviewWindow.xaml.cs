using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.OwnerWindows;
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

namespace InitialProject.WPF.Views.OwnerWindows
{
    /// <summary>
    /// Interaction logic for AccommodationOverviewWindow.xaml
    /// </summary>
    public partial class AccommodationOverviewWindow : UserControl
    {

        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public AccommodationController _accommodationController;

        public Accommodation SelectedAccommodation { get; set; }

        public RelayCommand RegisterNewAccommodationCommand { get; set; }
        public RelayCommand ReviewsCommand { get; set; }

        public AccommodationOverviewWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            RegisterNewAccommodationCommand = new RelayCommand(RegistenNewAccommodationButton_Click, CanRegisterNewAccommodation);
            ReviewsCommand = new RelayCommand(AccommodationReviewsButton_Click, CanReview);

            _accommodationController = new AccommodationController();

            Accommodations = new ObservableCollection<Accommodation>(_accommodationController.GetByOwner(SignInForm.LoggedUser.Id)); 
            if(Accommodations.Count != 0)
            {
                SelectedAccommodation = Accommodations.ElementAt(0);
            }

          


        }
        void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            foreach (InputBinding ib in this.InputBindings)
            {
                window.InputBindings.Add(ib);
            }
        }

        public void Refresh()
        {
            Accommodations.Clear();
            foreach(Accommodation accommodation in _accommodationController.GetByOwner(SignInForm.LoggedUser.Id))
            {
                Accommodations.Add(accommodation);
            }
        }



        private bool CanRegisterNewAccommodation(object param)
        {
            return MainWindow.SelectedTab == 1;
        }

        private void RegistenNewAccommodationButton_Click(object sender)
        {
            RegisterNewAccommodation NewAccommodation = new RegisterNewAccommodation();
            NewAccommodation.ShowDialog();

            Refresh();
            
        }

        private bool CanReview(object param)
        {
            return SelectedAccommodation != null && MainWindow.SelectedTab == 1;
        }

        private void AccommodationReviewsButton_Click(object param)
        {
            
            AccommodationReviewsWindow AccommodationReviews = new AccommodationReviewsWindow(SelectedAccommodation);
            AccommodationReviews.Show();
        }
    }
}
