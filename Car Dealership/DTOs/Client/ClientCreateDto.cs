namespace Car_Dealership.DTOs.Client
{
    public class ClientCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string PnoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AdvertisingPlatformId { get; set; }
    }
}
