using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Domain.Repositories;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicalScheduling.Infrastructure.Persistence.Repositories
{
    public class EfPatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public EfPatientRepository(ApplicationDbContext db)
        {
            _context = db;
        }
        public async Task<List<Patient>> GetAll() => await _context.Patients.ToListAsync();
        public async Task<Patient?> GetById(int id) => await _context.Patients.FindAsync(id);
        public async Task<Patient> Add(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<bool> Update(Patient patient)
        {
            var patientExist = await _context.Patients.FindAsync(patient.Id);
            if (patientExist is null) return false;

            patientExist.Name = patient.Name;
            patientExist.Email = patient.Email;
            patientExist.Birthdate = patient.Birthdate;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var patientExist = await _context.Patients.FindAsync(id);
            if (patientExist is null) return false;

            _context.Patients.Remove(patientExist);
            await _context.SaveChangesAsync();
            return true;
        }
       
    }
}
