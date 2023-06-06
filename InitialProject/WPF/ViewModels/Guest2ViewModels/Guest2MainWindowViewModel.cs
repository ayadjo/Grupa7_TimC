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
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{
    
    public class BoolToBrushConverter1 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); // Transparent brush

            return (int)value == 1 ? new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)) : new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)); // Green or black brush
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BoolToBrushConverter2 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); // Transparent brush

            return (int)value == 2 ? new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)) : new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)); // Green or black brush
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BoolToBrushConverter3 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)); // Transparent brush

            return (int)value == 3 ? new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)) : new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)); // Green or black brush
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class Guest2MainWindowViewModel : ViewModelBase
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

        private int openPage;
        public int OpenPage
        {
            get { return openPage; }
            set
            {
                if (openPage != value)
                {
                    openPage = value;
                    OnPropertyChanged("OpenPage");
                }
            }
        }


      

        private bool isDarkTheme;

        public bool IsDarkTheme
        {
            get { return isDarkTheme; }
            set
            {
                if (isDarkTheme != value)
                {
                    isDarkTheme = value;
                    UpdateTheme();
                    OnPropertyChanged(nameof(IsDarkTheme));
                }
            }
        }

        private string currentLanguage;

        public string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
            }
        }

        public NavigationService NavigationService { get; set; }

        public RelayCommand NavigateToToursOverviewCommand { get; set; }

        public RelayCommand NavigateToMyToursCommand { get; set; }
        public RelayCommand NavigateToMyTourRequestsCommand { get; set; }

        public RelayCommand LogOutCommand { get; set; }

        public RelayCommand SwitchToEnglishCommand { get; set; }

        public RelayCommand SwitchToSerbianCommand { get; set; }

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
            OpenPage = 1;
            this.NavigationService.Navigate(
                new Uri("WPF/Views/Guest2Windows/ToursOverviewWindow.xaml", UriKind.Relative));
            
        }

        private void Execute_NavigateToMyToursCommand(object obj)
        {
            OpenPage = 2;
            this.NavigationService.Navigate(
                new Uri("WPF/Views/Guest2Windows/MyToursWindow.xaml", UriKind.Relative));
        }

        private void Execute_NavigateToMyTourRequestsCommand(object obj)
        {
            OpenPage = 3;
            this.NavigationService.Navigate(
                new Uri("WPF/Views/Guest2Windows/MyTourRequestsWindow.xaml", UriKind.Relative));
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

        private void Execute_SwitchToEnglishCommand(object obj)
        {
            var app = (App)Application.Current;
            
            
            CurrentLanguage = "en-US";
            
            app.ChangeLanguage(CurrentLanguage);
        }

        private void Execute_SwitchToSerbianCommand(object obj)
        {
            var app = (App)Application.Current;


            CurrentLanguage = "sr-LATN";

            app.ChangeLanguage(CurrentLanguage);
        }

        #endregion

        #region Konstruktori
        public Guest2MainWindowViewModel(NavigationService navigationService)
        {
            OpenPage = 1;
            this.NavigationService = navigationService;
            this.NavigateToToursOverviewCommand = new RelayCommand(Execute_NavigateToToursOverviewCommand, CanExecute_NavigateCommand);
            this.NavigateToMyToursCommand = new RelayCommand(Execute_NavigateToMyToursCommand, CanExecute_NavigateCommand);
            this.NavigateToMyTourRequestsCommand = new RelayCommand(Execute_NavigateToMyTourRequestsCommand, CanExecute_NavigateCommand);
            this.LogOutCommand = new RelayCommand(Execute_LogOutCommand, CanExecute_NavigateCommand);
            // this.Checker = false;
            this.SwitchToEnglishCommand = new RelayCommand(Execute_SwitchToEnglishCommand);
            this.SwitchToSerbianCommand = new RelayCommand(Execute_SwitchToSerbianCommand);
            this.CurrentLanguage = "en-US";

            GuestFullName = SignInForm.LoggedUser.FirstName + " " + SignInForm.LoggedUser.LastName;
        }

        public Guest2MainWindowViewModel()
        {
        }
        #endregion

        private void UpdateTheme()
        {
            var app = (App)Application.Current;

            if (IsDarkTheme)
            {
                // Apply dark theme
                App.BackgroundColor = (Color)ColorConverter.ConvertFromString("#6f84d9");

            }
            else
            {
                // Apply light theme
                App.BackgroundColor = (Color)ColorConverter.ConvertFromString("#DFFDFF");
                
            }

            app.Resources["AppBackgroundBrush"] = new SolidColorBrush(App.BackgroundColor);
            
        }
    }
}
