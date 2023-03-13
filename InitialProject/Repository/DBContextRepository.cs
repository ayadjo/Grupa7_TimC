using InitialProject.Model.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class DBContextRepository : DbContext
    {
        public DBContextRepository(DbContextOptions options) : base(options) { }  
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
    }
}
