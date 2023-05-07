using InitialProject.WPF.Views.Guest2Window;
using System;
using System.Collections.Generic;
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
using InitialProject.Domain.Models;
using System.ComponentModel;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for Guest2MainWindow.xaml
    /// </summary>
    public partial class Guest2MainWindow : Window, INotifyPropertyChanged
    {
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

        public Guest2MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            GuestFullName = SignInForm.LoggedUser.FirstName +" " + SignInForm.LoggedUser.LastName;
        }

        private void goToToursOverview_Click(object sender, RoutedEventArgs e)
        {
            this.content.Content = new ToursOverviewWindow();
        }

        private void goToMyTours_Click(object sender, RoutedEventArgs e)
        {
            this.content.Content = new MyToursWindow();
        }

        private void goToMyRequests_Click(object sender, RoutedEventArgs e)
        {
            //this.content.Content = new MyRequestsWindow();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            this.Close();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
