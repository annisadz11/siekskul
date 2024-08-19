using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{

    public class PendaftaranEkstrakurikuler
    {
        [Key]
        public int PendaftaranId { get; set; }
        public int SiswaId { get; set; }
        public virtual Siswa Siswa { get; set; }
        public int EkstrakurikulerId { get; set; }
        public virtual Ekstrakurikuler Ekstrakurikuler { get; set; }
        public DateTime TanggalPendaftaran { get; set; }
        public StatusPendaftaran Status { get; set; }
    }

    public enum StatusPendaftaran
    {
        Menunggu,
        Diterima,
        Ditolak
    }
}