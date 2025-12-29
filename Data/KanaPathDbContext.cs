using Microsoft.EntityFrameworkCore;
using KanaPath.Api.Models;

namespace KanaPath.Api.Data
{
    public class KanaPathDbContext : DbContext
    {
        public KanaPathDbContext(DbContextOptions<KanaPathDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
