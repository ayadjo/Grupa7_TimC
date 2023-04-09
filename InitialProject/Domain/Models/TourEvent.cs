﻿using InitialProject.Enumerations;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace InitialProject.Domain.Models
{
    public class TourEvent : ISerializable
    {

        public int Id { get; set; } 
        public Tour Tour { get; set; }
        public DateTime StartTime { get; set; }

        public TourEventStatus Status { get; set; }

        //public GuideReview Review { get; set; }

        public TourEvent() { }

        public TourEvent(int id, Tour tour, DateTime startTime, TourEventStatus status)
        {
            Id = id;    
            Tour = tour;
            StartTime = startTime;
            Status = status;  
            //Review = review;
        }

        public string[] ToCSV()
        {


            string[] csvValues =
           {
               Id.ToString(),
               Tour.Id.ToString(),
               StartTime.ToString(),
               Status.ToString(),
               //Review.Id.ToString()
           };

            return csvValues;

        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Tour = new Tour() { Id = Convert.ToInt32(values[1]) };
            StartTime = DateTime.Parse(values[2]);
            Status = (TourEventStatus)Enum.Parse(typeof(TourEventStatus), values[3]);
           // Review = (GuideReview)Enum.Parse(typeof(GuideReview), values[4]);
        }

    }
}
