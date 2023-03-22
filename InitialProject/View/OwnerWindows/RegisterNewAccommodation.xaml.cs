using InitialProject.Controller;
using InitialProject.Enumerations;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.View.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
using System.Xml.Linq;
using Image = InitialProject.Model.Image;

namespace InitialProject.View.OwnerView
{
    /// <summary>
    /// Interaction logic for RegisterNewAccommodation.xaml
    /// </summary>
    public partial class RegisterNewAccommodation : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public ObservableCollection<AccommodationType> AccommodationTypes { get; set; }
        
        public LocationController _locationController;
        public AccommodationController _accommodationController;

        public List<Image> AllImages { get; set; }

        #region NotifyProperties
        private string _name;
        public string Naame
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Naame");
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

        private AccommodationType _selectedType;
        public AccommodationType SelectedType
        {
            get => _selectedType;
            set
            {
                if (value != _selectedType)
                {
                    _selectedType = value;
                    OnPropertyChanged("SelectedType");
                }
            }
        }
        

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

            _locationController = new LocationController();
            _accommodationController = new AccommodationController();

            Countries = new ObservableCollection<string>(_locationController.GetAllCountries()); 
            Cities = new ObservableCollection<string>();
            AccommodationTypes = new ObservableCollection<AccommodationType>();
            AccommodationTypes.Add(AccommodationType.apartment);
            AccommodationTypes.Add(AccommodationType.house);
            AccommodationTypes.Add(AccommodationType.cottage);

            AllImages = new List<Image>();

            
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = _locationController.FindLocationByCountryCity(SelectedCountry, SelectedCity);
            User user = new User() { Id = 1 };

            Accommodation accommodation = new Accommodation() { Name=Naame, Location = location, 
            Type = SelectedType, MaxGuests = MaxGuests, MinDaysForReservation = MinDaysForReservation,
            CancelationPeriod = CancelationPeriod, Owner = user, Images = AllImages};
            _accommodationController.SaveImages(accommodation);
            Close();
        }
        //treba da sacuva listu slika i potom kad pravim smestaj hocu da mu ucitam tu listu
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
        private void CountryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            List<string> cities = _locationController.GetCitiesByCountry(SelectedCountry);
            Cities.Clear();
            foreach(string city in cities)
            {
                Cities.Add(city);
            }
        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            AddNewImageWindow NewImage = new AddNewImageWindow(ImageResource.accommodation, AllImages);
            NewImage.Show();
        }

       
    }
}
