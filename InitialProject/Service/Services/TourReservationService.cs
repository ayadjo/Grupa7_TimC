using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    internal class TourReservationService
    {
        private TourReservationRepository _tourReservationRepository;
        private IVoucherRepository _voucherRepository;

        public TourReservationService()
        {
            _tourReservationRepository = TourReservationRepository.GetInstance();
            _voucherRepository = Injector.Injector.CreateInstance<IVoucherRepository>();
        }


        public List<TourReservation> GetAll()
        {
            return _tourReservationRepository.GetAll();
        }

        public TourReservation Get(int id)
        {
            return _tourReservationRepository.Get(id);
        }

        public TourReservation Save(TourReservation tourReservation)
        {
            return _tourReservationRepository.Save(tourReservation);
        }


        public void Delete(TourReservation tourReservation)
        {
            _tourReservationRepository.Delete(tourReservation);
        }

        public TourReservation Update(TourReservation tourReservation)
        {
            return _tourReservationRepository.Update(tourReservation);
        }

        public List<User> FindGuestsThatDidntComeYet(TourEvent tourEvent)
        {
            List<User> users = new List<User>();

            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.TourPointWhenGuestCame.Id == -1 && tourReservation.TourEvent.Id == tourEvent.Id)
                {
                    users.Add(tourReservation.Guest);

                }

            }

            return users;
        }

        public TourReservation FindTourReservationForUserAndTourEvent(User user, TourEvent tourEvent)
        {
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.Guest.Id == user.Id && tourReservation.TourEvent.Id == tourEvent.Id)
                {
                    return tourReservation;

                }
            }
            return null;
        }


        public List<TourEvent> UsersTourEvents(int userId)
        {
            List<TourEvent> tourEvents = new List<TourEvent>();
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.Guest.Id == userId)
                {
                    tourEvents.Add(tourReservation.TourEvent);
                }
            }
            return tourEvents;
        }

        public TourReservation GetTourReservationForTourEventAndUser(int tourEventId, int userId)
        {
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.Guest.Id == userId && tourReservation.TourEvent.Id == tourEventId)
                {
                    return tourReservation;
                }
            }
            return null;
        }

        public void CancelTourReservation(TourReservation tourReservation)
        {
            DateTime date = new DateTime();  ///??
            String name = new String("bskdd"); //??
            Voucher voucher = new Voucher(-1, name, tourReservation.Guest, false, 365, date);
            _voucherRepository.Save(voucher);

            _tourReservationRepository.Delete(tourReservation);
        }

        public void CancelAllTourReservationsForTourEvent(int tourEventId)
        {
            foreach (TourReservation tourReservation in _tourReservationRepository.GetAll())
            {
                if (tourReservation.TourEvent.Id == tourEventId)
                {
                    CancelTourReservation(tourReservation);

                }
            }

        }

        

    }
}
