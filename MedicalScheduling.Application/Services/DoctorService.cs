using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MedicalScheduling.Application.Services
{
    public class DoctorService
    {
        private readonly ApplicationDbContext _context;
        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }
        public async Task<Doctor?> GetById(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }
        public async Task<Doctor> Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task<bool> Update(int id, Doctor doctor)
        {
            var docExist = await _context.Doctors.FindAsync(id);
            if (docExist == null) return false;
            docExist.Name = doctor.Name;
            docExist.Specialty = doctor.Specialty;
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var docExist = await _context.Doctors.FindAsync(id);
            if (docExist == null) return false;
            _context.Doctors.Remove(docExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
