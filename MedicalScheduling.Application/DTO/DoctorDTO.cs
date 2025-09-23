using System.ComponentModel.DataAnnotations;

namespace MedicalScheduling.Application.DTO
{
    public class DoctorDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Specialty { get; set; }
    }
    public record DoctorCreateDto(string Name, string Specialty);
    public record DoctorUpdateDto(string Name, string Specialty);
}
