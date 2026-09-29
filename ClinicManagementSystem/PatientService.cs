using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem
{
    public class PatientService
    {
        public List<Patient> GetAll()
        {
            using var context = new AppDbContext();
            return context.Patients.Where(p => !p.IsDeleted).ToList();
        }

        public Patient? GetById(int id)
        {
            using var context = new AppDbContext();
            return context.Patients.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Add(string name, string phone, string address, int age, string gender)
        {
            using var context = new AppDbContext();
            var patient = Patient.Create(name, phone, address, age, gender);

            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void Update(int id, string name, string phone, string address, int age, string gender)
        {
            using var context = new AppDbContext();
            var patient = context.Patients.FirstOrDefault(p => p.Id == id && !p.IsDeleted);

            if (patient == null)
                throw new InvalidOperationException("Patient is not found");

            patient.Update(name, phone, address, age, gender);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new AppDbContext();
            var patient = context.Patients.FirstOrDefault(p => p.Id == id && !p.IsDeleted);

            if (patient == null)
                throw new InvalidOperationException("Patient is not found");

            patient.Delete();
            context.SaveChanges();
        }
    }
}