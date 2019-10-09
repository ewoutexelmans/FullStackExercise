using System.Reflection;
using FullStackExercise.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStackExercise.Data.Access
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
