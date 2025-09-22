using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicalScheduling.Application.Services
{
    public class PatientService
    {
        private readonly ApplicationDbContext _context;
        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task<Patient> Add(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<bool> Update(int id, Patient patient)
        {
            var patientExist = await _context.Patients.FindAsync(id);
            if (patientExist == null) return false;
            patientExist.Name = patient.Name;
            patientExist.Email = patient.Email;
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var patientExist = await _context.Patients.FindAsync(id);
            if (patientExist == null) return false;
            _context.Patients.Remove(patientExist);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
