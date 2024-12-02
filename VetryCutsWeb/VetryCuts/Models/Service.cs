namespace VetryCuts.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<BarberService> Barbers { get; set; } = new List<BarberService>();
    }

}
