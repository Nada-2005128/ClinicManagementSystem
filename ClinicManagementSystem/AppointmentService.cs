using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem
{
    public class AppointmentService
    {
        public List<Appointment> GetAll()
        {
            using var context = new AppDbContext();
            return context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => !a.IsDeleted).ToList();
        }

        public Appointment? GetById(int id)
        {
            using var context = new AppDbContext();
            return context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefault(a => a.Id == id && !a.IsDeleted);
        }

        public void Add(DateTime date, int doctorId, int patientId)
        {
            using var context = new AppDbContext();

            var existingAppointment = context.Appointments.FirstOrDefault(
                a =>!a.IsDeleted && a.DoctorId == doctorId && a.PatientId == patientId && a.Date.Date == date.Date);

            if (existingAppointment != null)
            {
                existingAppointment.Delete();
            }

            var appointment = Appointment.Create(date, doctorId, patientId);

            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        public void Update(int id, DateTime date, int doctorId, int patientId)
        {
            using var context = new AppDbContext();

            var appointment = context.Appointments.FirstOrDefault(a => a.Id == id && !a.IsDeleted);

            if (appointment == null)
                throw new InvalidOperationException("Appointment is not found");

            var existingAppointment = context.Appointments.FirstOrDefault(a =>!a.IsDeleted &&
                    a.Id != id && a.DoctorId == doctorId && a.PatientId == patientId && a.Date.Date == date.Date);

            if (existingAppointment != null)
                throw new InvalidOperationException("This patient already has an appointment with this doctor on the same day");

            appointment.Update(date, doctorId, patientId);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new AppDbContext();
            var appointment = context.Appointments.FirstOrDefault(a => a.Id == id && !a.IsDeleted);

            if (appointment == null)
                throw new InvalidOperationException("Appointment is not found");

            appointment.Delete();
            context.SaveChanges();
        }
    }
}