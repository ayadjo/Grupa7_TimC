using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface ILocationRepository
    {
        public List<Location> GetAll();
        public Location Get(int id);
        public Location Save(Location location);
        public void Delete(Location location);
        public Location Update(Location location);
        //public int NextId();
    }
}
