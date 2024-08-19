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
        public DbSet<Ekstrakurikuler> Ekstrakurikuler { get; set; }
        public DbSet<JadwalEkstrakurikuler> JadwalEkstrakurikuler { get; set; }
        public DbSet<PendaftaranEkstrakurikuler> PendaftaranEkstrakurikuler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ekstrakurikuler>()
                .HasOne(e => e.Guru)
                .WithMany(g => g.Ekstrakurikuler)
                .HasForeignKey(e => e.GuruId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JadwalEkstrakurikuler>()
                .HasOne(j => j.Ekstrakurikuler)
                .WithMany(e => e.Jadwal)
                .HasForeignKey(j => j.EkstrakurikulerId);

            modelBuilder.Entity<PendaftaranEkstrakurikuler>()
                .HasOne(p => p.Siswa)
                .WithMany(s => s.PendaftaranEkstrakurikuler)
                .HasForeignKey(p => p.SiswaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PendaftaranEkstrakurikuler>()
                .HasOne(p => p.Ekstrakurikuler)
                .WithMany(e => e.Pendaftaran)
                .HasForeignKey(p => p.EkstrakurikulerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Siswa>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Siswa>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guru>()
                .HasOne(g => g.User)
                .WithOne()
                .HasForeignKey<Guru>(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}