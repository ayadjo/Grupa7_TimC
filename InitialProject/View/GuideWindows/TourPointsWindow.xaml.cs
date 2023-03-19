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

namespace InitialProject.View.GuideWindows
{
    /// <summary>
    /// Interaction logic for TourPointsWindow.xaml
    /// </summary>
    public partial class TourPointsWindow : Window
    {
        public TourPointsWindow()
        {
            InitializeComponent();
        }

        private void ActivateButton_Click(object sender, RoutedEventArgs e)
        {
            GuestsForTour guestsForTour = new GuestsForTour();
            guestsForTour.Show();
        }
    }
}
