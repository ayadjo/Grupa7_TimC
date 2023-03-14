using InitialProject.View.OwnerView;
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

namespace InitialProject.View.OwnerWindows
{
    /// <summary>
    /// Interaction logic for AccommodationOverviewWindow.xaml
    /// </summary>
    public partial class AccommodationOverviewWindow : Window
    {
        public AccommodationOverviewWindow()
        {
            InitializeComponent();
        }

        private void RegistenNewAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewAccommodation NewAccommodation = new RegisterNewAccommodation();
            NewAccommodation.Show();
        }
    }
}
