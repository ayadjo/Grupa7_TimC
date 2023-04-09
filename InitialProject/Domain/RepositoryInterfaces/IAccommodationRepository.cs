using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IAccommodationRepository
    {
        public List<Accommodation> GetAll();
        public Accommodation Get(int id);
        public Accommodation Save(Accommodation accommodation);
        public void Delete(Accommodation accommodation);
        public Accommodation Update(Accommodation accommodation);
        public int NextId();
    }
}
