namespace ClinicManagementSystem
{
    public class Patient
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Phone { get; private set; }

        public string Address { get; private set; }

        public int Age { get; private set; }

        public string Gender { get; private set; }

        public bool IsDeleted { get; private set; }

        public readonly List<Appointment> appointments = [];

        private Patient() {}

        private Patient(string name,string phone,string address,int age,string gender)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Age = age;
            Gender = gender;
            IsDeleted = false;
        }

        public static Patient Create(string name,string phone,string address,int age,string gender)
        {
            Validate(name, phone, age, gender);

            return new Patient(name, phone, address, age, gender);
        }

        public void Update(string name,string phone,string address,int age,string gender)
        {
            if (IsDeleted)
                throw new InvalidOperationException("Can't update a deleted patient");

            Validate(name, phone, age, gender);

            Name = name;
            Phone = phone;
            Address = address;
            Age = age;
            Gender = gender;
        }

        public void Delete()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Patient is already deleted");

            IsDeleted = true;
        }

        private static void Validate(string name,string phone,int age,string gender)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11)
                throw new ArgumentException("Invalid phone number");

            if (age <= 0 || age > 100)
                throw new ArgumentException("Age is invalid");

            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender is required");
        }
    }
}