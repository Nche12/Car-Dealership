namespace Car_Dealership.Models
{
    public class SeatType : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
