using InitialProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IImageRepository
    {
        public List<Image> GetAll();
        public Image Get(int id);
        public Image Save(Image image);
        public void Delete(Image image);
        public Image Update(Image image);
        public int NextId();
    }
}
