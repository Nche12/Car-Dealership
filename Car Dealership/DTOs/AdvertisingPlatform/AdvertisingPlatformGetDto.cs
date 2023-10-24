namespace Car_Dealership.DTOs.AdvertisingPlatform
{
    public class AdvertisingPlatformGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double PaymentAmount { get; set; }
        public int FrequencyId { get; set; }
        public FrequencyGetDto? Frequency { get; set; }
    }
}
