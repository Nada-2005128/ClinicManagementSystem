namespace ClinicManagementSystem
{
    public class Appointment
    {
        public int Id { get; private set; }

        public DateTime Date { get; private set; }

        public int DoctorId { get; private set; }

        public int PatientId { get; private set; }

        public bool IsDeleted { get; private set; }

        public Doctor Doctor { get; private set; }

        public Patient Patient { get; private set; }

        private Appointment(){}

        private Appointment(DateTime date,int doctorId,int patientId)
        {
            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            IsDeleted = false;
        }

        public static Appointment Create(DateTime date,int doctorId,int patientId)
        {
            Validate(date, doctorId, patientId);

            return new Appointment(date, doctorId, patientId);
        }

        public void Update(DateTime date,int doctorId,int patientId)
        {
            if (IsDeleted)
                throw new InvalidOperationException("Can't update a deleted appointment");

            Validate(date, doctorId, patientId);

            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Appointment is already deleted");

            IsDeleted = true;
        }

        private static void Validate(DateTime date,int doctorId,int patientId)
        {
            if (date == default)
                throw new ArgumentException("Appointment date is required");

            if (doctorId <= 0)
                throw new ArgumentException("Doctor must be selected");

            if (patientId <= 0)
                throw new ArgumentException("Patient must be selected");
        }
    }
}