using MedicalScheduling.Domain.Entities;

namespace MedicalScheduling.Application.Services
{
    public class DoctorService
    {
        private readonly List<Doctor> _doctors = new()
        {
            new Doctor{Id = 1, Name = "Rogério", Specialty = "Cardiologista"}
        };
        private int nextId = 2;
        public IEnumerable<Doctor> GetAll() => _doctors;
        public Doctor? GetById(int id) => _doctors.FirstOrDefault(p => p.Id == id);
        public Doctor AddDoctor(Doctor doctor)
        {
            doctor.Id = nextId++;
            _doctors.Add(doctor);
            return doctor;
        }
        public bool UpdateDoctor(int id, Doctor doctor)
        {
            var doctorExist = _doctors.FirstOrDefault(p => p.Id == id);
            if (doctorExist == null)
                return false;
            return true;
        }
        public bool DeleteDoctor(int id)
        {
            var doctorExist = _doctors.FirstOrDefault(p => p.Id == id);
            if(doctorExist == null)
                return false;
            _doctors.Remove(doctorExist);
            return true;
        }
    }
}
