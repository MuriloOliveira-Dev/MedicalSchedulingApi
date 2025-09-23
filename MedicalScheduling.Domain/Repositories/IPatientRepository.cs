using System.Collections.Generic;
using MedicalScheduling.Domain.Entities;
using System.Threading.Tasks;

namespace MedicalScheduling.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAll();
        Task<Patient?> GetById(int id);
        Task<Patient> Add(Patient patient);
        Task<bool> Update(Patient patient);
        Task<bool> Delete(int id);
    }
}
