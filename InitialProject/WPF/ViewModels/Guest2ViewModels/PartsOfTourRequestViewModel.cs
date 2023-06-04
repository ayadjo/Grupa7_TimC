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
    public class PartsOfTourRequestViewModel : ViewModelBase
    {
        public NavigationService navigationService { get; set; }
        public ComplexTourRequest SelectedComplexTourRequest { get; set; }
        public ObservableCollection<TourRequest> PartsOfTourRequest { get; set; }

        public ComplexTourRequestController _complexTourRequestController { get; set; }
        public PartsOfTourRequestViewModel(NavigationService service, ComplexTourRequest complexTourRequest) 
        {
            this.navigationService = service;

            _complexTourRequestController = new ComplexTourRequestController();
            SelectedComplexTourRequest = complexTourRequest;

            PartsOfTourRequest = new ObservableCollection<TourRequest>(_complexTourRequestController.GetSimpleTourRequestsForComplexRequest(complexTourRequest.Id));
        }
    }
}
