using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views.Guest2Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{
    public class MyTourRequestsViewModel : ViewModelBase
    {
        public NavigationService navigationService { get; set; }
        public ObservableCollection<TourRequest> Requests { get; set; }

        public TourRequestController _tourRequestController;

        public RelayCommand CreateRequestCommand { get; set; }

        public RelayCommand StatisticsCommand { get; set; }

        public MyTourRequestsViewModel(NavigationService service)
        {
            this.navigationService = service;
            this.CreateRequestCommand = new RelayCommand(Executed_CreateRequestCommand, CanExecute_CreateRequestCommand);
            this.StatisticsCommand = new RelayCommand(Executed_StatisticsCommand, CanExecute_StatisticsCommand);

            _tourRequestController = new TourRequestController();

            Requests = new ObservableCollection<TourRequest>(_tourRequestController.GetAll());
        }

        public void Executed_CreateRequestCommand(object obj)
        {
            CreateTourRequestWindow createTourRequestWindow = new CreateTourRequestWindow();
            createTourRequestWindow.ShowDialog();
        }

        public bool CanExecute_CreateRequestCommand(object obj)
        {
            return true;
        }

        public void Executed_StatisticsCommand(object obj)
        {
            
        }

        public bool CanExecute_StatisticsCommand(object obj)
        {
            return true;
        }
    }
}
