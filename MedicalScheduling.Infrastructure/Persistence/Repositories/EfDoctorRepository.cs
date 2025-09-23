using MedicalScheduling.Domain.Entities;
using MedicalScheduling.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalScheduling.Infrastructure.Persistence.Repositories
{
    public class EfDoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public EfDoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAll() => await _context.Doctors.ToListAsync();
        public async Task<Doctor?> GetById(int id) => await _context.Doctors.FindAsync(id);
        public async Task<Doctor> Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task<bool> Update(Doctor doctor)
        {
            var doctorExist = await _context.Doctors.FindAsync(doctor.Id);
            if (doctorExist is null) return false;

            doctorExist.Name = doctor.Name;
            doctorExist.Specialty = doctor.Specialty;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var doctorExist = await _context.Doctors.FindAsync(id);
            if(doctorExist is null) return false;

            _context.Doctors.Remove(doctorExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
