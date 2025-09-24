
using System.ComponentModel.DataAnnotations;

namespace MedicalScheduling.Application.DTO
{
    public class PatientDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public DateOnly Birthdate { get; set; }

    }
    public record PatientCreateDto(string Name, string Email, DateOnly Birthdate);
    public record PatientUpdateDto(string Name, string Email, DateOnly Birthdate);
}
