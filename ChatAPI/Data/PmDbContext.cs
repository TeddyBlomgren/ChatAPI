using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Data
{
    public class PmDbContext : DbContext
    {
        public PmDbContext(DbContextOptions<PmDbContext> options) : base(options) { }

        public DbSet<PM> PrivateMessages { get; set; }
    }
}

