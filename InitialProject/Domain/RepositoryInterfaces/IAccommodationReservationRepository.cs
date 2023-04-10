using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IAccommodationReservationRepository
    {
        public List<AccommodationReservation> GetAll();
        public AccommodationReservation Get(int id);
        public AccommodationReservation Save(AccommodationReservation accommodationReservation);
        public void Delete(AccommodationReservation accommodationReservation);
        public AccommodationReservation Update(AccommodationReservation accommodationReservation);
     //   public int NextId();
    }
}
