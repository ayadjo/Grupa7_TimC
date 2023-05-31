using InitialProject.Domain.Models;
using InitialProject.WPF.ViewModels.GuideViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for CreateTourBasedOnStatistics.xaml
    /// </summary>
    public partial class CreateTourBasedOnStatistics : Page
    {
        public NavigationService navigationService;
        public CreateTourBasedOnStatistics()
        {
            InitializeComponent();
            TourRequestStatisticsViewModel tourRequestStatistics = new TourRequestStatisticsViewModel(navigationService);
            this.DataContext = tourRequestStatistics;
        }

        private void CountryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CityComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void LanguageComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTourPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MaxGuestsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
