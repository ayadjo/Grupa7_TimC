using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Domain.Models;
using InitialProject.Enumerations;
using InitialProject.Service.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace InitialProject.WPF.ViewModels.GuideViewModels
{
    public class AddingDateViewModel
    {
        public NavigationService navigationService { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public TourController _tourController { get; set; }
        
        public TourRequest SelectedTourRequest { get; set; }
        public DateTime SelectedDate { get; set; }
        public AddingDateViewModel(NavigationService service, TourRequest tourRequest)
        {
            this.navigationService = service;
            SubmitCommand = new RelayCommand(Executed_SubmitCommand, CanExecute_SubmitCommand);
            SelectedTourRequest = tourRequest;
            _tourController = new TourController();
        }

        public bool CanExecute_SubmitCommand(object obj)
        {
            return true;
        }

        public void Executed_SubmitCommand(object obj)
        {
            if (SelectedDate < SelectedTourRequest.Start && SelectedDate > SelectedTourRequest.End)
            {
                MessageBox.Show("Niste izabrali ispavan datum, pokusajte ponovo.");
            }
            if (SelectedTourRequest.Status == RequestStatusType.Approved)
            {
                MessageBox.Show("Ovaj zahtev je odobren");
            }
            _tourController.CreateTourBasedOnTourRequest(SelectedTourRequest, SelectedDate);
            
        }

    }
}
