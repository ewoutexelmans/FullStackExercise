using FullStackExercise.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStackExercise.Data.Access
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
