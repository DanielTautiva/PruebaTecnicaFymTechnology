using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaFymTechnology.Models
{
    // User.cs
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)] // Se debe almacenar la contraseña de forma segura (hash)
        public string? Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<UserRole>? UserRoles { get; set; }
    }

}
