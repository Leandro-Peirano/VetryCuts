namespace VetryCuts.Models
{
    public class BarberService
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public User Barber { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
