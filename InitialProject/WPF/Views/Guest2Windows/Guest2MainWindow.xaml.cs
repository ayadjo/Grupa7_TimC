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

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for Guest2MainWindow.xaml
    /// </summary>
    public partial class Guest2MainWindow : Window
    {
        public Guest2MainWindow()
        {
            InitializeComponent();
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
    }
}
