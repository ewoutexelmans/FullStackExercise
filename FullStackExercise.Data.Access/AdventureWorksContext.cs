using FullStackExercise.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStackExercise.Data.Access
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
