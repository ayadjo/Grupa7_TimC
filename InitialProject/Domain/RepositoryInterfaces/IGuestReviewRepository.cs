using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IGuestReviewRepository
    {
        public List<GuestReview> GetAll();
        public GuestReview Get(int id);
        public GuestReview Save(GuestReview guestReview);
        public void Delete(GuestReview guestReview);
        public GuestReview Update(GuestReview guestReview);
       // public int NextId();
    }
}
