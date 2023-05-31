using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Dto
{
    public class TourRequestsByMonthDto
    {
        public int Month { get; set; }
        public int RequestsNum { get; set; }
        public TourRequestsByMonthDto(int month, int requeststNum) {
        
            Month = month;
            RequestsNum = requeststNum;
        }
    }
}
