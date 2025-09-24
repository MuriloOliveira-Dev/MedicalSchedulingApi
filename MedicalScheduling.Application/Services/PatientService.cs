using MedicalScheduling.Application.DTO;
using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Domain.Repositories;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicalScheduling.Application.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repo;
        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Patient>> GetAll() => _repo.GetAll();
        public Task<Patient?> GetById(int id) => _repo.GetById(id);
        public Task<Patient> Add(PatientCreateDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Email = patientDto.Email,
                Birthdate = patientDto.Birthdate,
            };
            return _repo.Add(patient);
        }
        public Task<bool> Update(Patient patient, int id)
        {
            patient.Id = id;
            return _repo.Update(patient);
        }
        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

    }

}
