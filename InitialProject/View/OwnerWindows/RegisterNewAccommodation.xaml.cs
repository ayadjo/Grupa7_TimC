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

namespace InitialProject.View.OwnerView
{
    /// <summary>
    /// Interaction logic for RegisterNewAccommodation.xaml
    /// </summary>
    public partial class RegisterNewAccommodation : Window
    {
        public RegisterNewAccommodation()
        {
            InitializeComponent();
            MaxGuestTxt.Text = "0";
            MinDaysForReservationTxt.Text = "0";
            CancelationPeriodTxt.Text = "0";
        }


        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(MaxGuestTxt.Text);
            value++;
            MaxGuestTxt.Text = value.ToString();
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(MaxGuestTxt.Text);
            value--;
            MaxGuestTxt.Text = value.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
