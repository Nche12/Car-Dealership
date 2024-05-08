namespace Car_Dealership.Models
{
    public class Owner : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
        public AdvertisingPlatform? AdvertisingPlatform { get; set; }
        public int AdvertisingPlatformId { get; set; }
    }
}
