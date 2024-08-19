using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{

    public class Ekstrakurikuler
    {
        [Key]
        public int EkstrakurikulerId { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public int GuruId { get; set; }
        public virtual Guru Guru { get; set; }
        public virtual ICollection<JadwalEkstrakurikuler> Jadwal { get; set; }
        public virtual ICollection<PendaftaranEkstrakurikuler> Pendaftaran { get; set; }
    }
}