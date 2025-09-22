namespace MedicalScheduling.Application.DTO
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
    }
    public record DoctorCreateDto(string Name, string Specialty);
    public record DoctorUpdateDto(string Name, string Specialty);
}
