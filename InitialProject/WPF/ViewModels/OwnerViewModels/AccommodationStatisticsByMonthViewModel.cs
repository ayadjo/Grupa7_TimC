using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.OwnerWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class AccommodationStatisticsByMonthViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }

        public AccommodationReservationController _accommodationReservationController;

        public ObservableCollection<AccommodationByMonthStatisticDto> AccommodationStatisticsByMonth { get; set; }
        public RelayCommand CloseStatisticsByMonthCommand { get; set; }

        public Accommodation Accommodation { get; set; }
        public AccommodationByYearStatisticDto SelectedStatisticByYear { get; set; }
        public AccommodationStatisticsByMonthViewModel(AccommodationByYearStatisticDto statisticByYear, Accommodation accommodation)
        {
            _accommodationReservationController = new AccommodationReservationController();
            CloseStatisticsByMonthCommand = new RelayCommand(Execute_CloseStatisticsByMonthCommand);
            SelectedStatisticByYear = statisticByYear;
            Accommodation = accommodation;
            AccommodationStatisticsByMonth = new ObservableCollection<AccommodationByMonthStatisticDto>(_accommodationReservationController.GetMonthStatisticForAccommodation(statisticByYear.Year, Accommodation.Id));
        }

        public void Execute_CloseStatisticsByMonthCommand(object param)
        {
            Close();
        }



    }
}
