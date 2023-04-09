
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using InitialProject.Repositories;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AccommodationRepository.GetInstance();
            LocationRepository.GetInstance();
            TourRepository.GetInstance();
            TourEventRepository.GetInstance();
            TourPointRepository.GetInstance(); 
            ImageRepository.GetInstance();
            TourReservationRepository.GetInstance();
            VoucherRepository.GetInstance();
            
            AccommodationReservationRepository.GetInstance();
            GuestReviewRepository.GetInstance();
            AccommodationOwnerReviewRepository.GetInstance();

            AccommodationRepository.GetInstance().BindAccomodationLocation();
            AccommodationReservationRepository.GetInstance().BindAccomodationReservationAccommodation();
            AccommodationReservationRepository.GetInstance().BindAccomodationReservationGuest();

            TourRepository.GetInstance().BindTourLocation();
            TourPointRepository.GetInstance().BindTourPointTour();
            TourEventRepository.GetInstance().BindTourEventTour();
            ImageRepository.GetInstance().BindImageResource();
            

            TourReservationRepository.GetInstance().BindTourReservationTourPoint();
            TourReservationRepository.GetInstance().BindTourReservationTourEvent();
            TourReservationRepository.GetInstance().BindTourReservationUser();  
            

            GuestReviewRepository.GetInstance().BindGuestReviewWithAccommodationReservation();
            AccommodationOwnerReviewRepository.GetInstance().BindAccommodationOwnerReviewWithAccommodationReservation();
            VoucherRepository.GetInstance().BindVoucherUser();
        }
    }
}
