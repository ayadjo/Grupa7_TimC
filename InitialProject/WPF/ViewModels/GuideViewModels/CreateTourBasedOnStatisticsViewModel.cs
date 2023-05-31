using InitialProject.Controller;
using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.GuideViewModels
{
    public class CreateTourBasedOnStatisticsViewModel
    {
        public NavigationService navigationService { get; set; }
        string Language { get; set; }   
        public CreateTourBasedOnStatisticsViewModel(NavigationService service, string language, Location location) {
            this.navigationService = service;
            Language = language;

        }

    }

 
}
