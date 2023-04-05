using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.Models
{
    public class GuideReview : ISerializable
    {
        public int Id { get; set; }
        public TourReservation Reservation { get; set; }
        public int Knowledge { get; set; }
        public int Language { get; set; }
        public int Interesting { get; set; }
        public string Comment { get; set; }
        public List<Image> Images { get; set; }

        public GuideReview()
        {
            Images = new List<Image>();
        }
        public GuideReview(int id, TourReservation reservation, int knowledge, int language, int interesting, string comment)
        {
            Id = id;
            Reservation = reservation;
            Knowledge = knowledge;
            Language = language;
            Interesting = interesting;
            Comment = comment;
            Images = new List<Image>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Reservation.Id.ToString(),
                Knowledge.ToString(),
                Language.ToString(),
                Interesting.ToString(),
                Comment
            };
            return csvValues;

        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Reservation = new TourReservation() { Id = Convert.ToInt32(values[1]) };
            Knowledge = Convert.ToInt32(values[2]);
            Knowledge = Convert.ToInt32(values[3]);
            Interesting = Convert.ToInt32(values[4]);
            Comment = values[5];
        }
    }
}
