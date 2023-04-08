using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.Enumerations;
using InitialProject.View.GuideWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Image = InitialProject.Domain.Models.Image;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for CreateTour.xaml
    /// </summary>
    public partial class CreateTour : Window, INotifyPropertyChanged
    {

        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }



        LocationController _locationController;

        TourController _tourController;
        TourEventController _tourEventController;
        public List<Image> AllImages { get; set; }
        public List<TourPoint> AllTourPoints { get; set; }

        public CreateTour()
        {
            InitializeComponent();
            this.DataContext = this;
            Tour Tour = new Tour();

            _locationController = new LocationController();
            _tourController = new TourController();
            _tourEventController = new TourEventController();


            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();

            AllImages = new List<Image>();
            AllTourPoints = new List<TourPoint>();

            SelectedDate = DateTime.Now;
        }

        #region NotifyProperties
        private string _name;
        public string Namee
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Namee");
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
        
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private string _languages;
        public string Languages
        {
            get => _languages;
            set
            {
                if (value != _languages)
                {
                    _languages = value;
                    OnPropertyChanged("Languages");
                }
            }
        }

        private int _maxGuests;
        public int MaxGuestss
        {
            get => _maxGuests;
            set
            {
                if (value != _maxGuests)
                {
                    _maxGuests = value;
                    OnPropertyChanged("MaxGuestss");
                }
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (value != _selectedDate)
                {
                    _selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }


        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
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



        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Location location = _locationController.FindLocationByCountryCity(SelectedCountry, SelectedCity);
            User user = new User() { Id = 1 };

            Tour tour = new Tour()
            {
                Name = Namee,
                Location = location,
                Description = Description,
                Languages = Languages,
                MaxGuests = MaxGuestss,
                Duration = Duration,
                Guide = user,
                Images = AllImages,
                TourPoints = AllTourPoints
            };
           
            _tourController.SaveImagesTourPoints(tour);  

            TourEvent tourEvent = new TourEvent(-1, tour, SelectedDate, false);
            _tourEventController.Save(tourEvent);

            

            Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CountryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

            List<string> cities = _locationController.GetCitiesByCountry(SelectedCountry);
            Cities.Clear();
            foreach (string city in cities)
            {
                Cities.Add(city);
            }

        }

        private void CityComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            AddTourImages TourImage = new AddTourImages(ImageResource.tour, AllImages);
            TourImage.Show();

        }

        private void LanguageComboBox_LostFocus(object sender, RoutedEventArgs e) 
        {
            if (LanguageComboBox.SelectedIndex == 0)
            {
                Languages = "srpski";
            }
            else if (LanguageComboBox.SelectedIndex == 1) {

                Languages = "engleski";

            }
            else if(LanguageComboBox.SelectedIndex == 2)
            {

                Languages = "italijanski";

            }
            else if (LanguageComboBox.SelectedIndex == 3)
            {
                Languages = "korejski";
            }
            else if(LanguageComboBox.SelectedIndex == 4)
            {
                Languages = "japanski";
            }
            
        
        }

       

        private void AddTourPoint_Click(object sender, RoutedEventArgs e)
        {
            AddTourPoints TourPoint = new AddTourPoints(AllTourPoints);
            TourPoint.Show();

        }

       

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
