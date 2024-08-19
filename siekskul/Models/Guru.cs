using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{
    public class Guru
    {
        [Key]
        public int GuruId { get; set; }
        public int? NIP { get; set; }
        public string? JenisKelamin { get; set; }
        public string? Agama { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? BidangEkstrakurikuler { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Ekstrakurikuler> Ekstrakurikuler { get; set; }
    }
}
