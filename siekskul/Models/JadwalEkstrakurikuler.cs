using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{
    public class JadwalEkstrakurikuler
    {
        [Key]
        public int JadwalId { get; set; }
        public int EkstrakurikulerId { get; set; }
        public virtual Ekstrakurikuler Ekstrakurikuler { get; set; }
        public DayOfWeek Hari { get; set; }
        public TimeSpan WaktuMulai { get; set; }
        public TimeSpan WaktuSelesai { get; set; }
        public string Lokasi { get; set; }
    }
}