using InitialProject.Controller;
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
using InitialProject.Enumerations;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.Guest2Windows;
using System.ComponentModel;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace InitialProject.WPF.Views.Guest2Window
{
    /// <summary>
    /// Interaction logic for ToursOverviewWindow.xaml
    /// </summary>
    public partial class ToursOverviewWindow : UserControl, IDataErrorInfo  
    {
        public ObservableCollection<Tour> Tours { get; set; }

        public TourController _tourController;

        public string Country { get; set; }

        public string City { get; set; }

        public string Languages { get; set; }

        public string Duration { get; set; }
        
        public string NumberOfPeople { get; set; }

        public Tour SelectedTour { get; set; }
        public ToursOverviewWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            _tourController = new TourController();

            Tours = new ObservableCollection<Tour>(_tourController.GetAll());
            Country = "";
            City = "";
            Languages = "";
            Duration = "";
            NumberOfPeople = "";
            
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
             if (SelectedTour != null)
             {
                 TourReservationWindow tourReservation = new TourReservationWindow(SelectedTour);
                 tourReservation.Show();
             }
             else
             {
                 MessageBox.Show("Morate odabrati turu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
             }
        }

        private void RefreshTours(List<Tour> tours)
        {
            Tours.Clear();
            foreach(Tour tour in tours)
            {
                Tours.Add(tour);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if(IsValid)
            {
                List<Tour> searchedTours = _tourController.SearchTours(Country, City, Languages, NumberOfPeople, Duration);
                RefreshTours(searchedTours);
            }
            else
            {
                MessageBox.Show(Error);
            }
        }

        //Validacija

        private Regex _StringRegex = new Regex("[A-Z]?[a-z]* || ^$");
        private Regex _IntRegex = new Regex("[1-9]* || ^$");

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Country")
                {
                    Match match = _StringRegex.Match(Country);
                    if (!match.Success)
                        return validationMessage.Text ="Pogrešan format";
                    else
                        validationMessage.Text = string.Empty;
                }
                else if (columnName == "City")
                {
                    
                }
                else if (columnName == "NumberOfPeople")
                {
                    
                }
                else if (columnName == "Language")
                {
                    
                }
                else if (columnName == "Duration")
                {

                }


                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Country", "City", "NumberOfPeople", "Language", "Duration" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

    }
}
