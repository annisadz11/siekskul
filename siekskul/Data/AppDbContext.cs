using Microsoft.EntityFrameworkCore;
using siekskul.Models;

namespace siekskul.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Siswa> Siswas { get; set; }
        public DbSet<Guru> Gurus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
