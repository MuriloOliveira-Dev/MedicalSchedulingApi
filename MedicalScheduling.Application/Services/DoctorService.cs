using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Domain.Repositories;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicalScheduling.Application.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }
        public Task<List<Doctor>> GetAll() => _repo.GetAll();
        public Task<Doctor?> GetById(int id) => _repo.GetById(id);
        public Task<Doctor> Add(Doctor doctor) => _repo.Add(doctor);
        public Task<bool> Update(Doctor doctor, int id)
        {
            doctor.Id = id;
            return _repo.Update(doctor);
        }
        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
