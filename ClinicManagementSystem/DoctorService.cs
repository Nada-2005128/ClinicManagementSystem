using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem
{
    public class DoctorService
    {
        public List<Doctor> GetAll()
        {
            using var context = new AppDbContext();
            return context.Doctors.Where(d => !d.IsDeleted).ToList();
        }

        public Doctor? GetById(int id)
        {
            using var context = new AppDbContext();
            return context.Doctors.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
        }

        public void Add(string name, string specialty, string phone)
        {
            using var context = new AppDbContext();
            var doctor = Doctor.Create(name, specialty, phone);

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        public void Update(int id, string name, string specialty, string phone)
        {
            using var context = new AppDbContext();
            var doctor = context.Doctors.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            if (doctor == null)
                throw new InvalidOperationException("Doctor is not found");

            doctor.Update(name, specialty, phone);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new AppDbContext();
            var doctor = context.Doctors.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            if (doctor == null)
                throw new InvalidOperationException("Doctor is not found");

            doctor.Delete();
            context.SaveChanges();
        }
    }
}