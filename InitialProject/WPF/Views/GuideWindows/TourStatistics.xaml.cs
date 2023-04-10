using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
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

namespace InitialProject.WPF.Views.GuideWindows
{
    /// <summary>
    /// Interaction logic for TourStatistics.xaml
    /// </summary>
    public partial class TourStatistics : Window, INotifyPropertyChanged
    {

        public ObservableCollection<int> Years { get; set; }
        public int SelectedYear { get; set; }
        public TourEventController _tourEventController;
        public TourReservationController _tourReservationController;
        public TourController _tourController;
        public ObservableCollection<TourEvent> TourEvents { get; set; }
        public TourEvent SelectedTourEvent { get; set; }
        
       



        #region NotifyProperties
        private TourEvent _bestTourEvent;
        public TourEvent BestTourEvent
        {
            get => _bestTourEvent;
            set
            {
                if (value != _bestTourEvent)
                {
                    _bestTourEvent = value;
                    OnPropertyChanged("BestTourEvent");
                }
            }
        }

        private TourAgeGroupStatistic _tourAge;
        public TourAgeGroupStatistic TourAge
        {
            get => _tourAge;
            set
            {
                if (value != _tourAge)
                {
                    _tourAge = value;
                    OnPropertyChanged("TourAge");
                }
            }
        }

        private TourPercentageOfGuestsVouchers _tourPercentageOfGuestsVouchers;
        public TourPercentageOfGuestsVouchers TourPercentageOfGuestsVouchers
        {
            get => _tourPercentageOfGuestsVouchers;
            set
            {
                if (value != _tourPercentageOfGuestsVouchers)
                {
                    _tourPercentageOfGuestsVouchers = value;
                    OnPropertyChanged("TourPercentageOfGuestsVouchers");
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

        public TourStatistics()
        {
            InitializeComponent();
            this.DataContext = this;
            _tourEventController = new TourEventController();
            _tourReservationController = new TourReservationController();
            Years = new ObservableCollection<int>(_tourEventController.YearsOfTourEvents(SignInForm.LoggedUser.Id));
            BestTourEvent = _tourEventController.MostVisitedTourEvent();
            SelectedYear = -1;
            _tourController = new TourController();
            TourEvents = new ObservableCollection<TourEvent>(_tourEventController.GetAllTourEvents(SignInForm.LoggedUser.Id));

            
        }

        private void ViewMostVisitedTourInGeneral_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedYear == -1)
            {
                return;
            }
            BestTourEvent = _tourEventController.MostVisitedTourEvent(SelectedYear);
        }

        private void YearComboBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ToursDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateTourEventsList()
        {

            foreach (var tourEvent in _tourEventController.GetAllTourEvents(SignInForm.LoggedUser.Id))
            {
                TourEvents.Add(tourEvent);
            }
        }

        public void Update()
        {
            UpdateTourEventsList();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedTourEvent == null)
            {
                return;
            }
            TourAge = _tourReservationController.GetAgeStatisticsForTourEvent(SelectedTourEvent.Id);
            TourPercentageOfGuestsVouchers = _tourReservationController.GetPercentageOfGuestsWithVouchersForTourEvent(SelectedTourEvent.Id);
            
        }
    }
}
