using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{

    public class CreateTourRequestViewModel : ViewModelBase, IClose, IDataErrorInfo
    {
        public Action Close { get; set; }
        //public NavigationService NavigationService { get; set; }

        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }

        public LocationController _locationController;

        public TourRequestController _tourRequestController;

        public TourController _tourController;  

        public RelayCommand CreateRequestCommand { get; set; }

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
                    CountryComboBox_LostFocus();
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

        private string _language;
        public string Language
        {
            get => _language;
            set
            {
                if (value != _language)
                {
                    _language = value;
                    OnPropertyChanged("Language");
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

        private DateTime _selectedStartDate;
        public DateTime SelectedStartDate
        {
            get => _selectedStartDate;
            set
            {
                if (value != _selectedStartDate)
                {
                    _selectedStartDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        private DateTime _selectedEndDate;
        public DateTime SelectedEndDate
        {
            get => _selectedEndDate;
            set
            {
                if (value != _selectedEndDate)
                {
                    _selectedEndDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }
        public void Executed_CreateRequestCommand(object obj)
        {
            IsSubmitClicked = true;
            if (IsValid)
            {
                Location location = _locationController.FindLocationByCountryCity(SelectedCountry, SelectedCity);
                User user = SignInForm.LoggedUser;

                // MaxGuests = 0;

                TourRequest tourRequest = new TourRequest()
                {
                    Location = location,
                    Language = Language,
                    MaxGuests = MaxGuests,
                    Description = Description,
                    Start = SelectedStartDate,
                    End = SelectedEndDate,
                    Guest = user,
                    Status = Enumerations.RequestStatusType.Standby,
                    ComplexTourRequestId = -1,
                    AcceptedRequestGuide = new AcceptedRequestGuide()
                    {
                        Id = -1,
                        Guide = null,
                        Appointment = null
                    }
                };


                _tourRequestController.Save(tourRequest);
                IsSubmitClicked = false;
                MessageBox.Show("You have successfully created a request!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                //NavigationService.Navigate(new Uri("WPF/Views/Guest2Windows/MyTourRequests.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Incorrectly entered data!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public bool CanExecute_CreateRequestCommand(object obj)
        {
            return true;
        }

        public CreateTourRequestViewModel()
        {
            this.CreateRequestCommand = new RelayCommand(Executed_CreateRequestCommand, CanExecute_CreateRequestCommand);
            //this.NavigationService = navigationService;

            _locationController = new LocationController();
            _tourRequestController = new TourRequestController();

            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();

            TourRequest tourRequest = new TourRequest();

            SelectedStartDate = DateTime.Now;
            SelectedEndDate = DateTime.Now;

            

        }


        private void CountryComboBox_LostFocus()
        {
            List<string> cities = _locationController.GetCitiesByCountry(SelectedCountry);
            Cities.Clear();
            foreach (string city in cities)
            {
                Cities.Add(city);
            }
        }

        //Validacija
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                if (IsSubmitClicked)
                {
                    if (columnName == "SelectedCountry")
                    {
                        if (string.IsNullOrEmpty(SelectedCountry))
                        {
                            return "Please choose a country.";
                        }
                    }

                    if (columnName == "SelectedCity")
                    {
                        if (string.IsNullOrEmpty(SelectedCity))
                        {
                            return "Please choose a location.";
                        }
                    }

                    if (columnName == "MaxGuests")
                    {
                        if (string.IsNullOrEmpty(MaxGuests.ToString()) || MaxGuests.ToString() == "0")
                        {
                            return "Please choose the number of people.";
                        }
                        else if (!int.TryParse(MaxGuests.ToString(), out int maxGuests) || maxGuests <= 0)
                        {
                            return "Please enter a positive integer.";
                        }
                    }

                    if (columnName == "Language")
                    {
                        if (string.IsNullOrEmpty(Language))
                        {
                            return "Please enter a language.";
                        }
                        else if (!Regex.IsMatch(Language.TrimEnd(), "^[a-zA-Z]+(\\s)*$"))
                        {
                            return "Language must contain only letters.";
                        }
                    }

                    if (columnName == "Description")
                    {
                        if (string.IsNullOrEmpty(Description))
                        {
                            return "Please write a description.";
                        }
                    }

                    if (columnName == "SelectedStartDate")
                    {
                        if (SelectedStartDate <= DateTime.Today)
                        {
                            return "Please select a future date.";
                        }
                        else if (SelectedStartDate > DateTime.Today.AddYears(5))
                        {
                            return "Please select a date within the next 5 years.";
                        }
                    }

                    if (columnName == "SelectedEndDate")
                    {
                        if (SelectedEndDate <= SelectedStartDate)
                        {
                            return "Please select a future date.";
                        }
                        else if (SelectedEndDate > SelectedStartDate.AddDays(15))
                        {
                            return "Please select an end date within 15 days from the start date.";
                        }
                    }
                }

                return null;
            }
        }


        private bool _isSubmitClicked = false;

        public bool IsSubmitClicked
        {
            get { return _isSubmitClicked; }
            set
            {
                if (_isSubmitClicked != value)
                {
                    _isSubmitClicked = value;
                    OnPropertyChanged("IsSubmitClicked");
                    OnPropertyChanged("SelectedCountry");
                    OnPropertyChanged("SelectedCity");
                    OnPropertyChanged("MaxGuests");
                    OnPropertyChanged("Language");
                    OnPropertyChanged("Description");
                    OnPropertyChanged("SelectedStartDate");
                    OnPropertyChanged("SelectedEndDate");
                }
            }
        }


        private readonly string[] _validatedProperties = { "SelectedCountry", "SelectedCity", "MaxGuests", "Language", "Description", "SelectedStartDate", "SelectedEndDate" };

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
