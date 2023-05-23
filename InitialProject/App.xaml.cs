using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Injector;
using InitialProject.Localization;
using InitialProject.Repositories;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ChangeLanguage(string currLang)
        {
            if (currLang.Equals("en-US"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }
        }

        public App()
        {
            AccommodationRepository.GetInstance();
            LocationRepository.GetInstance();
            TourRepository.GetInstance();
            TourEventRepository.GetInstance();
            TourPointRepository.GetInstance();
            ImageRepository.GetInstance();
            TourReservationRepository.GetInstance();



            AccommodationReservationRepository.GetInstance();
            GuestReviewRepository.GetInstance();

            //AccommodationOwnerReviewRepository.GetInstance();

            GuideReviewRepository.GetInstance();
            //UserRepository.GetInstance();


            AccommodationRepository.GetInstance().BindAccomodationLocation();
            AccommodationReservationRepository.GetInstance().BindAccomodationReservationAccommodation();
            AccommodationReservationRepository.GetInstance().BindAccomodationReservationGuest();

            TourRepository.GetInstance().BindTourLocation();
            TourRepository.GetInstance().BindTourGuide();
            TourPointRepository.GetInstance().BindTourPointTour();
            TourEventRepository.GetInstance().BindTourEventTour();
            ImageRepository.GetInstance().BindImageResource();


            TourReservationRepository.GetInstance().BindTourReservationTourPoint();
            TourReservationRepository.GetInstance().BindTourReservationTourEvent();
            TourReservationRepository.GetInstance().BindTourReservationUser();


            GuestReviewRepository.GetInstance().BindGuestReviewWithAccommodationReservation();

            //AccommodationOwnerReviewRepository.GetInstance().BindAccommodationOwnerReviewWithAccommodationReservation();

            GuideReviewRepository.GetInstance().BindGuideReviewWithTourReservation();


            Injector.Injector.BindComponents();


            //VoucherRepository.GetInstance().BindVoucherUser();
            TourReservationRepository.GetInstance().BindTourReservationVoucher();
        }
    }
}
