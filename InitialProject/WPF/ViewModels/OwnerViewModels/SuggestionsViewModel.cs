using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.WPF.ViewModels.OwnerViewModels
{
    public class SuggestionsViewModel: ViewModelBase
    {
        private string _loggedUser;
        public string LoggedUser
        {
            get => _loggedUser;
            set
            {
                if (value != _loggedUser)
                {
                    _loggedUser = value;
                    OnPropertyChanged();
                }
            }
        }
        public AccommodationReservationController _accommodationReservationController;

        public ObservableCollection<Location> MostPopularLocations { get; set; }
        public ObservableCollection<Accommodation> LeastPopularAccommodations { get; set; }
        public SuggestionsViewModel()
        {
            LoggedUser = SignInForm.LoggedUser.FirstName;
            _accommodationReservationController = new AccommodationReservationController();
            MostPopularLocations = new ObservableCollection<Location>(_accommodationReservationController.GetMostPopularLocations());
            LeastPopularAccommodations = new ObservableCollection<Accommodation>(_accommodationReservationController.FindAccommodationsOnLeastPopularLocations());
        }
    }
}
