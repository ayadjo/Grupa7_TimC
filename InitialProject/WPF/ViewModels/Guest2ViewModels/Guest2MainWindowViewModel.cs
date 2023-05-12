using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Commands;
using System.Windows.Navigation;
using InitialProject.WPF.Views.Guest2Window;
using System.Windows.Controls;
using InitialProject.WPF.Views;
using InitialProject.Domain.Models;
using System.Windows;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{
    public class Guest2MainWindowViewModel : ViewModel
    {
        /*private bool checker;
        public bool Checker
        {
            get { return checker; }
            set
            {
                checker = value;
                OnPropertyChanged();
            }
        }
        */
        public NavigationService NavigationService { get; set; }

        public RelayCommand NavigateToToursOverviewCommand { get; set; }

        public RelayCommand NavigateToMyToursCommand { get; set; }

        public RelayCommand NavigateToMyRequestsCommand { get; set; }

        public RelayCommand LogOutCommand { get; set; }

        public Action CloseAction { get; set; }

        private string _guestFullName { get; set; }
        public string GuestFullName
        {
            get => _guestFullName;
            set
            {
                if (_guestFullName != value)
                {
                    _guestFullName = value;
                    OnPropertyChanged("GuestFullName");
                }
            }
        }

        #region Akcije
        private void Execute_NavigateToToursOverviewCommand(object obj)
        {
            this.NavigationService.Navigate(
                new Uri("WPF/Views/Guest2Windows/ToursOverviewWindow.xaml", UriKind.Relative));
            //alternativa
            ///UserControl tours = new ToursOverviewWindow();
            //this.frame.NavigationService.Navigate(tours);
        }

        private void Execute_NavigateToMyToursCommand(object obj)
        {
            this.NavigationService.Navigate(
                new Uri("WPF/Views/Guest2Windows/MyToursWindow.xaml", UriKind.Relative));
        }

        private void Execute_LogOutCommand(object sender)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            if (CloseAction != null)
            {
                CloseAction();   //????
            }  
        }

        private bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

        #endregion

        #region Konstruktori
        public Guest2MainWindowViewModel(NavigationService navigationService)
        {
            this.NavigationService = navigationService;
            this.NavigateToToursOverviewCommand = new RelayCommand(Execute_NavigateToToursOverviewCommand, CanExecute_NavigateCommand);
            this.NavigateToMyToursCommand = new RelayCommand(Execute_NavigateToMyToursCommand, CanExecute_NavigateCommand);
            //this.NavigateToMyRequestsCommand = new RelayCommand(Execute_NavigateToMyRequestsCommand, CanExecute_NavigateCommand);
            this.LogOutCommand = new RelayCommand(Execute_LogOutCommand, CanExecute_NavigateCommand);
           // this.Checker = false;

            GuestFullName = SignInForm.LoggedUser.FirstName + " " + SignInForm.LoggedUser.LastName;
        }

        public Guest2MainWindowViewModel()
        {
        }
        #endregion

    }
}
