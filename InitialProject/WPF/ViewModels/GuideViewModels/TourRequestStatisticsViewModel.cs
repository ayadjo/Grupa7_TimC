using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.GuideWindows;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.GuideViewModels
{
    public enum LastStatistic
    {
        Language, Location
    }
    public class TourRequestStatisticsViewModel : ViewModelBase 
    {
        public RelayCommand ShowLocationCommand { get; set; }
        public RelayCommand ShowLanguageCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand ShowForMonthsCommand { get; set; }

        public NavigationService navigationService { get; set; }

      
        public Location location { get; set; }  

        #region NotifyProperties
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

        private string _selectedLocation;
        public string SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (value != _selectedLocation)
                {
                    _selectedLocation = value;
                    OnPropertyChanged("SelectedLocation");
                }
            }
        }

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (value != _selectedLanguage)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged("SelectedLanguage");
                }
            }
        }


        #endregion

        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public ObservableCollection<string> Languages { get; set; }

        LocationController _locationController;
        TourRequestController _tourRequestController;
        public RelayCommand FillCitiesCommand { get; set; }

        public int BestYear { get; set; }
        public TourRequestsByYearDto SelectedTourRequestsYearDto { get; set; }



        public ObservableCollection<TourRequestsByYearDto> Statistics { get; set; }
        private LastStatistic _lastStatistic;

           

        //public string Language { get; set; }    
        public TourRequestStatisticsViewModel(NavigationService service) {

            this.navigationService = service;
            

          
            ShowLocationCommand = new RelayCommand(Executed_ShowLocationCommand, CanExecute_ShowLocationCommand);
            ShowLanguageCommand = new RelayCommand(Executed_ShowLanguageCommand, CanExecute_ShowLanguageCommand);
            CreateCommand = new RelayCommand(Executed_CreateCommand, CanExecute_CreateCommand);
            ShowForMonthsCommand = new RelayCommand(Executed_ShowForMonthsCommand, CanExecute_ShowForMonthsCommand);

            _locationController = new LocationController();
            _tourRequestController = new TourRequestController();
            Countries = new ObservableCollection<string>(_locationController.GetAllCountries());
            Cities = new ObservableCollection<string>();

            
            
            Languages = new ObservableCollection<string>();
            Languages.Add("srpski");
            Languages.Add("engleski");
            Languages.Add("italijanski");
            Languages.Add("korejski");
            Languages.Add("japanski");

           

            Statistics = new ObservableCollection<TourRequestsByYearDto>();

        }

        public bool CanExecute_ShowLocationCommand(object obj)
        {
            return SelectedCountry != null && SelectedCity != null;
        }

        public void Executed_ShowLocationCommand(object obj)
        {


            var statistics = _tourRequestController.GetStatisticsForLocation(SelectedCountry, SelectedCity);
            RefreshView(statistics);
            _lastStatistic = LastStatistic.Location;
        }

        private void RefreshView(List<TourRequestsByYearDto> statistics)
        {
            Statistics.Clear();
            statistics.ForEach(s => Statistics.Add(s));
        }

        public bool CanExecute_ShowLanguageCommand(object obj)
        {
            return SelectedLanguage != "";
        }

        public void Executed_ShowLanguageCommand(object obj)
        {

            var statistics = _tourRequestController.GetStatisticsForLanguage(SelectedLanguage);
            RefreshView(statistics);
            _lastStatistic = LastStatistic.Language;

        }

        public bool CanExecute_CreateCommand(object obj)
        {
            return true;
        }

        
        public void Executed_CreateCommand(object obj)
        {
            CreateTourBasedOnStatistics tourBasedOnStatistics = new CreateTourBasedOnStatistics();
            this.navigationService.Navigate(tourBasedOnStatistics);
        }

        public bool CanExecute_ShowForMonthsCommand(object obj)
        {
            return SelectedTourRequestsYearDto != null;
        }

        public void Executed_ShowForMonthsCommand(object obj)
        {
            int year = SelectedTourRequestsYearDto.Year;
            StatisticForMonthsWindow statisticForMonthsWindow = new StatisticForMonthsWindow(year, _lastStatistic, SelectedLanguage, SelectedCity, SelectedCountry);
            this.navigationService.Navigate(statisticForMonthsWindow);
            
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
