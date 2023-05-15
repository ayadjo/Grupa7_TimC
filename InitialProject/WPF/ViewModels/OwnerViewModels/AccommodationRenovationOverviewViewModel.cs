using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class AccommodationRenovationOverviewViewModel : ViewModelBase, IClose
    {
        public Action Close { get; set; }

        private ObservableCollection<AccommodationRenovation> accommodationRenovations;
        public ObservableCollection<AccommodationRenovation> AccommodationRenovations
        {
            get { return accommodationRenovations; }
            set
            {
                accommodationRenovations = value;
                OnPropertyChanged();
            }
        }

        public AccommodationRenovationController _accommodationRenovationController;

        public AccommodationRenovation SelectedAccommodationRenovation { get; set; }

        public RelayCommand CloseCommand { get; set; }
        public AccommodationRenovationOverviewViewModel(Accommodation accommodation)
        {
            _accommodationRenovationController = new AccommodationRenovationController();

            AccommodationRenovations = new ObservableCollection<AccommodationRenovation>(_accommodationRenovationController.GetAllValidRenovations(accommodation));
            CloseCommand = new RelayCommand(Execute_CloseCommand);
        }

        public void Execute_CloseCommand(object param)
        {
            Close();
        }
    }
}
