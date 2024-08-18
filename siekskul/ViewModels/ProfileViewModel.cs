using siekskul.Models;
using System.ComponentModel.DataAnnotations;

namespace siekskul.ViewModels
{
    public class ProfileViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public UserRole Role { get; set; }

        // Fields untuk Siswa
        public int? SiswaId { get; set; }
        public int? NIS { get; set; }
        public string? Kelas { get; set; }
        [Required(ErrorMessage = "Mohon pilih jenis kelamin")]
        public string? JenisKelamin { get; set; }
        [Required(ErrorMessage = "Mohon pilih agama")]
        public string? Agama { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? Alamat { get; set; }
        public string? NamaAyah { get; set; }
        public string? NamaIbu { get; set; }

        // Fields untuk Guru
        public int? GuruId { get; set; }
        public int? NIP { get; set; }
        public string? BidangEkstrakurikuler { get; set; }
    }
}