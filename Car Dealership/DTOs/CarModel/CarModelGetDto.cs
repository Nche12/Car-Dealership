namespace Car_Dealership.DTOs.CarModel
{
    public class CarModelGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CarMakeId { get; set; }
        public CarMakeGetDto? CarMake { get; set; }
    }
}
