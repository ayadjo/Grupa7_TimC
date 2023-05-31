using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Dto
{
    public class TourRequestsByYearDto
    {
        public int Year { get; set; }
        public int TourRequestsNum { get; set; }

        public TourRequestsByYearDto(int year, int tourRequestsNum)
        {
            Year = year;    
            TourRequestsNum = tourRequestsNum;
        }
    }
}
