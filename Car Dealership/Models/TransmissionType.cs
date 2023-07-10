namespace Car_Dealership.Models
{
    public class TransmissionType : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
