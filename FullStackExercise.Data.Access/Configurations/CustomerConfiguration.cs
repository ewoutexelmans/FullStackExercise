using FullStackExercise.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackExercise.Data.Access.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Sales")
                .HasKey(c => c.CustomerId);
            builder.HasOne(d => d.Person)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.PersonId);
        }
    }
}
