using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalScheduling.Domain.Entities;

namespace MedicalScheduling.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor?> GetById(int id);
        Task<Doctor> Add(Doctor doctor);
        Task<bool> Update(Doctor doctor);
        Task<bool> Delete(int id);
    }
}
