using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Dto;
using InitialProject.WPF.Views;
using InitialProject.WPF.Views.Guest2Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.Guest2ViewModels
{
    public class TourRequestStatisticsViewModel : ViewModelBase
    {
        public ObservableCollection<int> Years { get; set; }
        public int SelectedYear { get; set; }

        public TourRequestController _tourRequestController { get; set; }

        public RelayCommand InGeneralCommand { get; set; }

        public RelayCommand ViewCommand { get; set; }

        private TourRequestPercentageDto _tourRequestPercentage;
        public TourRequestPercentageDto TourRequestPercentageDto
        {
            get => _tourRequestPercentage;
            set
            {
                if (value != _tourRequestPercentage)
                {
                    _tourRequestPercentage = value;
                    OnPropertyChanged("TourRequestPercentageDto");
                }
            }
        }

        public TourRequestStatisticsViewModel()
        {

            this.ViewCommand = new RelayCommand(Executed_ViewCommand, CanExecute_ViewCommand);
            this.InGeneralCommand = new RelayCommand(Executed_InGeneralCommand, CanExecute_InGeneralCommand);

            _tourRequestController = new TourRequestController();

            TourRequestPercentageDto = _tourRequestController.GetPercentageOfTourRequest(SignInForm.LoggedUser.Id);

            Years = new ObservableCollection<int>(_tourRequestController.YearsOfTourRequests(SignInForm.LoggedUser.Id));
            SelectedYear = -1;
        }

        public void Executed_ViewCommand(object obj)
        {
            if (SelectedYear == -1)
            {
                return;
            }
            TourRequestPercentageDto = _tourRequestController.GetPercentageOfTourRequest(SignInForm.LoggedUser.Id, SelectedYear);
        }

        public bool CanExecute_ViewCommand(object obj)
        {
            return true;
        }

        public void Executed_InGeneralCommand(object obj)
        {
            
        }

        public bool CanExecute_InGeneralCommand(object obj)
        {
            return true;
        }

    }
}
