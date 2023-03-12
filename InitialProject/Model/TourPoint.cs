using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace InitialProject.Model
{
    internal class TourPoint
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        public Tour Tour { get; set; }
        public int Order { get; set; }
        public Boolean Active { get; set; }

        public TourPoint() { }

        public TourPoint(String name, Tour tour, int order, Boolean active)
        {
            Name = name;
            Tour = tour;
            Order = order;
            Active = active;
        }

        public string[] ToCSV()
        {


            string[] csvValues =
           {
               Id.ToString(),
               Name,
               Tour.Id.ToString(),
               Order.ToString(),
               Active.ToString(),   

           };

            return csvValues;

        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Tour = new Tour() { Id = Convert.ToInt32(values[2]) };
            Order = Convert.ToInt32(values[3]);
            Active = Boolean.Parse(values[4]); //?

        }


    }

    
}
