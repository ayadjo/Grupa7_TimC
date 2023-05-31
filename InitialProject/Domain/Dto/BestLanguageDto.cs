using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Dto
{
    public class BestLanguageDto
    {
        public BestLanguageDto(string language, int numberOfRequests)
        {
            Language = language;
            NumberOfRequests = numberOfRequests;
        }

        public BestLanguageDto()
        {
           
        }

        public string Language { get; set; }    
        public int NumberOfRequests { get; set; }


    }

       
}
