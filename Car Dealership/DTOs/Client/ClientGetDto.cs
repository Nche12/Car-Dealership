namespace Car_Dealership.DTOs.Client
{
    public class ClientGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ContactId { get; set; }
        public ContactGetDto? Contact { get; set; }
        public int AdvertisingPlatformId { get; set; }
        public AdvertisingPlatformGetDto? AdvertisingPlatform { get; set; }
    }
}
