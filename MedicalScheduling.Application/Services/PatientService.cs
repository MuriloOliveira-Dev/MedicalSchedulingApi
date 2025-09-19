using MedicalScheduling.Domain.Entities;

namespace MedicalScheduling.Application.Services
{
    public class PatientService
    {
        private readonly List<Patient> _patients = new()
        {
            new Patient{Id = 1, Name = "Alex", Email = "alex@gmail.com" },
        };
        private int _nextId = 3;
        public IEnumerable<Patient> GetAll() => _patients;
        public Patient? GetById(int id) => _patients.FirstOrDefault(p => p.Id == id);

        public Patient AddPatient(Patient patient)
        {
            patient.Id = _nextId++;
            _patients.Add(patient);
            return patient;
        }
        public bool UpdatePatient(int id, Patient patient)
        {
            var patientExist = _patients.FirstOrDefault(p => p.Id == id);
            if (patientExist == null)
                return false;

            patientExist.Name = patient.Name;
            patientExist.Email = patient.Email;
            return true;
        }
        public bool DeletePatient(int id)
        {
            var patientExist = _patients.FirstOrDefault(p => p.Id == id);
            if (patientExist == null)
                return false;
            _patients.Remove(patientExist);
            return true;
        }
    }

}
