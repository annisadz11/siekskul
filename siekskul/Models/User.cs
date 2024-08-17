using System.ComponentModel.DataAnnotations;

namespace siekskul.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Siswa,
        Guru
    }
}
