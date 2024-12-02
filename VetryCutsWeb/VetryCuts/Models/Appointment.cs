namespace VetryCuts.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public int BarberId { get; set; }
        public User Barber { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }

}
