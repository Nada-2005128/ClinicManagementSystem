namespace ClinicManagementSystem
{
    public class Doctor
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Specialty { get; private set; }

        public string Phone { get; private set; }

        public bool IsDeleted { get; private set; }

        public readonly List<Appointment> appointments = [];

        private Doctor() {}

        private Doctor(string name,string specialty,string phone)
        {
            Name = name;
            Specialty = specialty;
            Phone = phone;
            IsDeleted = false;
        }

        public static Doctor Create(string name,string specialty,string phone)
        {
            Validate(name, specialty, phone);

            return new Doctor(name, specialty, phone);
        }

        public void Update(string name,string specialty,string phone)
        {
            if (IsDeleted)
                throw new InvalidOperationException("Can't update a deleted doctor");

            Validate(name, specialty, phone);

            Name = name;
            Specialty = specialty;
            Phone = phone;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Doctor is already deleted");

            IsDeleted = true;
        }

        private static void Validate(string name,string specialty,string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(specialty))
                throw new ArgumentException("Specialty is required");

            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11)
                throw new ArgumentException("Invalid phone number");

        }
    }
}