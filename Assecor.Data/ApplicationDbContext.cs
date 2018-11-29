using Assecor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("AssecorDbConnectionString")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public ApplicationDbContext(string cnString) : base(cnString)
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}
