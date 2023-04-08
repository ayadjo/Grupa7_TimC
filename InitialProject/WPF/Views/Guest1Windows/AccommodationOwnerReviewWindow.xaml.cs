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

namespace InitialProject.WPF.Views.Guest1Windows
{
    /// <summary>
    /// Interaction logic for AccommodationOwnerReviewWindow.xaml
    /// </summary>
    public partial class AccommodationOwnerReviewWindow : Window
    {
        public AccommodationOwnerReviewWindow()
        {
            InitializeComponent();
        }

        private void ImagesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
