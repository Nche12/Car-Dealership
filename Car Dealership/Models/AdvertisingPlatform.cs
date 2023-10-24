﻿namespace Car_Dealership.Models
{
    public class AdvertisingPlatform : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double PaymentAmount { get; set; }
        public int FrequencyId { get; set; }
        public Frequency? Frequency { get; set; }

    }
}
