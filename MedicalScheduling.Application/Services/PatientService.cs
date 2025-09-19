using MedicalScheduling.Domain.Entities;

namespace MedicalScheduling.Application.Services
{
    public class PatientService
    {
        private readonly List<Patient> _patients = new()
        {
            new Patient{Id = 1, Name = "Alex", Email = "alex@gmail.com" },
            new Patient{Id = 2, Name = "Maria", Email = "maria@outlook.com" }
        };
        public IEnumerable<Patient> GetAll() => _patients;
    }

}
