using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.GuideViewModels
{
    public class StatisticForMontsViewModel
    {
        public ObservableCollection<TourRequestsByMonthDto> Statistics { get; set; }
        public StatisticForMontsViewModel(int year, LastStatistic lastStatistic, string languge, string city, string country) {
            TourRequestController tourRequestController = new TourRequestController();
            if(lastStatistic == LastStatistic.Location)
            {
                Statistics = new ObservableCollection<TourRequestsByMonthDto>(tourRequestController.GetStatisticsForLocationMonts(country, city, year));
            }
            else
            {
                Statistics = new ObservableCollection<TourRequestsByMonthDto>(tourRequestController.GetStatisticsForLanguageMonts(languge, year));
            }
        }
    }
}
