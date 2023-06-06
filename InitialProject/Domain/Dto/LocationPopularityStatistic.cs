using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Dto
{
    public class LocationPopularityStatistic
    {
        public Location Location { get; set; }
        public int NumberOfReservation { get; set; }

        public LocationPopularityStatistic(Location location, int numberOfReservation)
        {
            Location = location;
            NumberOfReservation = numberOfReservation;
        }
    }
}
