using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{
    public class CreateComplexTourRequestViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }
        public NavigationService NavigationService { get; set; }
        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }

        public LocationController _locationController;

        public TourRequestController _tourRequestController;


        public RelayCommand AddRequestCommand { get; set; }
        
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

        }

        public bool CanExecute_CreateRequestCommand(object obj)
        {
            return true;
        }

        public void Executed_AddRequestCommand(object obj)
        {

        }

        public bool CanExecute_AddRequestCommand(object obj)
        {
            return true;
        }

        public CreateComplexTourRequestViewModel(NavigationService navigationService)
        {
            this.CreateRequestCommand = new RelayCommand(Executed_CreateRequestCommand, CanExecute_CreateRequestCommand);
            this.AddRequestCommand = new RelayCommand(Executed_AddRequestCommand, CanExecute_AddRequestCommand);
            this.NavigationService = navigationService;

            _locationController = new LocationController();
            _tourRequestController = new TourRequestController();

            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();

            //TourRequest tourRequest = new TourRequest();

            SelectedStartDate = DateTime.Now;
            SelectedEndDate = DateTime.Now;
        }

    }
}
