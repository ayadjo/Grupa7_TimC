using InitialProject.Domain.Models;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IAccommodationOwnerReviewRepository
    {
        List<AccommodationOwnerReview> GetAll();
        AccommodationOwnerReview Get(int id);
        AccommodationOwnerReview Save(AccommodationOwnerReview accommodationOwnerReview);
        void Delete(AccommodationOwnerReview accommodationOwnerReview);
        AccommodationOwnerReview Update(AccommodationOwnerReview accommodationOwnerReview);

    }
}
