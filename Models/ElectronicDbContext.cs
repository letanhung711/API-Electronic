using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Models
{
    public class ElectronicDbContext : DbContext
    {
        public ElectronicDbContext(DbContextOptions<ElectronicDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
