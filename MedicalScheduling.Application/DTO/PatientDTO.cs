
namespace MedicalScheduling.Application.DTO
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
    public record PatientCreateDto(string Name, string Email);
    public record PatientUpdateDto(string Name, string Email);
}
