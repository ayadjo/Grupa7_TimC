using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace InitialProject.Domain.Models
{
    public class Voucher : ISerializable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public bool Used { get; set; }
        public int Duration { get; set; }



        public Voucher()
        {


        }

        public Voucher(int id, User userr, bool used, int duration)
        {

            Id = id;
            User = userr;
            Used = used;
            Duration = duration;


        }

        public string[] ToCSV()
        {


            string[] csvValues =
            {
               Id.ToString(),
               User.Id.ToString(),
               Used.ToString(),
               Duration.ToString()


            };

            return csvValues;

        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);

            User = new User() { Id = Convert.ToInt32(values[1]) };
            Used = bool.Parse(values[2]);
            Duration = Convert.ToInt32(values[3]);



        }
    }
}
