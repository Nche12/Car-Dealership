namespace Car_Dealership.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CarMakeId { get; set; }
        public CarMake? CarMake { get; set; }
    }
}
