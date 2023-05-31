using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views;
using InitialProject.WPF.Views.GuideWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.GuideViewModels
{
    public class AcceptingTourRequestsViewModel : ViewModelBase 
    {
        public RelayCommand FilterCommand { get; set; }
        public RelayCommand AcceptCommand { get; set; }
        public RelayCommand FillCitiesCommand { get; set; }


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

        private DateTime _start;
        public DateTime Start
        {
            get => _start;
            set
            {
                if (value != _start)
                {
                    _start = value;
                    OnPropertyChanged("Start");
                }
            }
        }

        private DateTime _end;
        public DateTime End
        {
            get => _end;
            set
            {
                if (value != _end)
                {
                    _end = value;
                    OnPropertyChanged("End");
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

        #endregion

        public ObservableCollection<TourRequest> TourRequests { get; set; }
        public TourRequestController _tourRequestController;
        public TourRequest SelectedTourRequest { get; set; }
        public NavigationService navigationService { get; set; }


        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        LocationController _locationController;




        public AcceptingTourRequestsViewModel(NavigationService service)

        {
            this.navigationService = service;
            _locationController = new LocationController();
            _tourRequestController = new TourRequestController();

            TourRequests = new ObservableCollection<TourRequest>(_tourRequestController.GetAllTourRequests());

            FilterCommand = new RelayCommand(Executed_FilterCommand, CanExecute_FilterCommand);
            AcceptCommand = new RelayCommand(Executed_AcceptCommand, CanExecute_AcceptCommand);

            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();


            Language = "";
            Start = DateTime.Now;
            End = DateTime.Now;
            MaxGuestss = -1;
        }
        public bool CanExecute_FilterCommand(object obj)
        {
            return true;
        }

        public void Executed_FilterCommand(object obj)
        {
            List<TourRequest> searchedTourRequests = _tourRequestController.SearchTourRequests(SelectedCountry, SelectedCity, Language, MaxGuestss, Start,End);
            RefreshTourRequests(searchedTourRequests);
        }

        public bool CanExecute_AcceptCommand(object obj)
        {
            return SelectedTourRequest!=null;
        }

        public void Executed_AcceptCommand(object obj)
        {
            AddingDateWindow addingDate = new AddingDateWindow(SelectedTourRequest);
            this.navigationService.Navigate(addingDate);
        }

        private void RefreshTourRequests(List<TourRequest> tourRequests)
        {
            TourRequests.Clear();
            foreach (TourRequest tourRequest in tourRequests)
            {
                TourRequests.Add(tourRequest);
            }
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






    }
}
