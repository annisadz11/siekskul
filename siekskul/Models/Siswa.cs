using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{
    public class Siswa
    {
        [Key]
        public int SiswaId { get; set; }
        public int? NIS { get; set; }
        public string? Kelas { get; set; }
        public string? JenisKelamin { get; set; }
        public string? Agama { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? Alamat { get; set; }
        public string? NamaAyah { get; set; }
        public string? NamaIbu { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
