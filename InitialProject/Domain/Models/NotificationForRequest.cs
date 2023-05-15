using System;
using System.Collections.Generic;
using System.Linq;
using InitialProject.Serializer;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Models
{
    public class NotificationForRequest //: ISerializable
    {/*
        public int Id { get; set; }
        public TourRequest TourRequest { get; set; }
        public bool IsDelivered { get; set; }

        public NotificationForRequest() { }

        public NotificationForRequest(int id, TourRequest tourRequest, bool isDelivered)
        {
            Id = id;
            TourRequest = tourRequest;
            IsDelivered = isDelivered;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                TourRequest.Id.ToString(),
                IsDelivered.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            TourRequest = new TourRequest() { Id = Convert.ToInt32(values[1]) };
            IsDelivered = Boolean.Parse(values[2]);
        }*/
    }
}
