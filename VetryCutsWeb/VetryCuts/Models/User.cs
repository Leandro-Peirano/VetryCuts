namespace VetryCuts.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "customer", "barber", "admin"

        public ICollection<BarberService> AssignedServices { get; set; } = new List<BarberService>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

}
