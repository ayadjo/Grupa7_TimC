using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.Service.Services;
using InitialProject.WPF.Views;
using InitialProject.WPF.Views.Guest2Windows;
using InitialProject.WPF.Views.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using InitialProject.WPF.Views.Guest2Windows;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{

    
    public class CreateComplexTourRequestViewModel : ViewModelBase, IClose, IDataErrorInfo
    {
        public Action Close { get; set; }
        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }

        NavigationService NavigationService { get; set; }

        public ObservableCollection<TourRequest> PartsOfTheRequest { get; set; }

        public LocationController _locationController;

        public ComplexTourRequestController _complexTourRequestController;

        public TourRequestController _tourRequestController;

        public MyTourRequestsViewModel MyRequestsViewModel { get; set; }

        public RelayCommand AddRequestCommand { get; set; }

        public RelayCommand CreateRequestCommand { get; set; }

        public int ComplexRequestId { get; set; }

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
            List<TourRequest> tourRequests = new List<TourRequest>(PartsOfTheRequest);
            ComplexTourRequest complexTourRequest = new ComplexTourRequest(ComplexRequestId, tourRequests, SignInForm.LoggedUser, Enumerations.RequestStatusType.Standby);

            _complexTourRequestController.Save(complexTourRequest);
            MessageBox.Show("You have successfully created a complex request!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            MyTourRequestsViewModel.Refresh();
            Close();
        }

        private void RefreshComplexTourRequest(List<ComplexTourRequest> complexRequest)
        {
            MyRequestsViewModel.ComplexRequests.Clear();
            foreach (ComplexTourRequest request in complexRequest)
            {
                MyRequestsViewModel.ComplexRequests.Add(request);
            }
        }

        public bool CanExecute_CreateRequestCommand(object obj)
        {
            return true;
        }

        private void Reset()
        {
            SelectedCountry = null;
            SelectedCity = null;
            Description = "";
            Language = null;
            MaxGuests = 0;
            SelectedStartDate = DateTime.Today.Date;
            SelectedEndDate = DateTime.Today.Date;
        }

        public void Executed_AddRequestCommand(object obj)
        {
            IsSubmitClicked = true;
            if (IsValid)
            {
                Location location = _locationController.FindLocationByCountryCity(SelectedCountry, SelectedCity);
                User user = SignInForm.LoggedUser;

                TourRequest simpleTourRequest = new TourRequest() { };
                simpleTourRequest.Id = _tourRequestController.NextId();
                simpleTourRequest.Location = location;
                simpleTourRequest.Language = Language;
                simpleTourRequest.MaxGuests = MaxGuests;
                simpleTourRequest.Description = Description;
                simpleTourRequest.Start = SelectedStartDate;
                simpleTourRequest.End = SelectedEndDate;
                simpleTourRequest.Guest = user;
                simpleTourRequest.Status = Enumerations.RequestStatusType.Standby;
                simpleTourRequest.ComplexTourRequestId = ComplexRequestId;

                PartsOfTheRequest.Add(simpleTourRequest);
                _tourRequestController.Save(simpleTourRequest);

                //brisanje unosa dodati
                MyTourRequestsViewModel.Refresh();

                Reset();
            }
            else
            {
                MessageBox.Show("Incorrectly entered data!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        public bool CanExecute_AddRequestCommand(object obj)
        {
            return true;
        }
        private MyTourRequestsViewModel MyTourRequestsViewModel { get; set; }
        public CreateComplexTourRequestViewModel(MyTourRequestsViewModel myTourRequestsViewModel)
        {
            MyTourRequestsViewModel = myTourRequestsViewModel;
            //this.NavigationService = service;
            this.CreateRequestCommand = new RelayCommand(Executed_CreateRequestCommand, CanExecute_CreateRequestCommand);
            this.AddRequestCommand = new RelayCommand(Executed_AddRequestCommand, CanExecute_AddRequestCommand);

            _locationController = new LocationController();
            _complexTourRequestController = new ComplexTourRequestController();
            _tourRequestController = new TourRequestController();

            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();
            PartsOfTheRequest = new ObservableCollection<TourRequest>();


            ComplexTourRequest complexTourRequest = new ComplexTourRequest();

            SelectedStartDate = DateTime.Now;
            SelectedEndDate = DateTime.Now;

            ComplexRequestId = _complexTourRequestController.NextId();

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
