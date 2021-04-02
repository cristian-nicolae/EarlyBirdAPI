using EarlyBird.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EarlyBird.DataAccess
{
    public class EarlyBirdContext : DbContext
    {
        public EarlyBirdContext(DbContextOptions<EarlyBirdContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
