namespace Car_Dealership.DTOs.AdvertisingPlatform
{
    public class AdvertisingPlatformCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public double PaymentAmount { get; set; }
        public int FrequencyId { get; set; }
    }
}
