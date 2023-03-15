using InitialProject.Enumerations;
using InitialProject.Model;
using InitialProject.View.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class RegisterNewAccommodation : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public AccommodationOverviewWindow AccommodationOverviewWindow { get; set; }

        #region NotifyProperties
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (value != _selectedCountry)
                {
                    _selectedCountry = value;
                    OnPropertyChanged("SelectedCountry");
                }
            }
        }
        private string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (value != _selectedCity)
                {
                    _selectedCity = value;
                    OnPropertyChanged("SelectedCity");
                }
            }
        }
        //private AccommodationType _selectedType;
        private int _maxGuests;
        public int MaxGuests
        {
            get => _maxGuests;
            set
            {
                if (value != _maxGuests)
                {
                    _maxGuests = value;
                    OnPropertyChanged("MaxGuests");
                }
            }
        }
        private int _minDaysForReservation;
        public int MinDaysForReservation
        {
            get => _minDaysForReservation;
            set
            {
                if (value != _minDaysForReservation)
                {
                    _minDaysForReservation = value;
                    OnPropertyChanged("MinDaysForReservation");
                }
            }
        }
        private int _cancelationPeriod = 1;
        public int CancelationPeriod
        {
            get => _cancelationPeriod;
            set
            {
                if (value != _cancelationPeriod)
                {
                    _cancelationPeriod = value;
                    OnPropertyChanged("CancelationPeriod");
                }
            }
        }

        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public RegisterNewAccommodation()
        {
            InitializeComponent();
            this.DataContext = this;

            Accommodation Accommodation = new Accommodation(); 

        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CityComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            AddNewImageWindow NewImage = new AddNewImageWindow();
            NewImage.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender; // checked RadioButton

            // logic
            if (radioButton == ApartmentRadioButton)
            {

            }
            else if (radioButton == HouseRadioButton)
            {

            }
            else 
            { 
            
            
            }

                
        }

        
    }
}
