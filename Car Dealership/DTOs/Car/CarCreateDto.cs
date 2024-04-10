namespace Car_Dealership.DTOs.Car
{
    public class CarCreateDto
    {
        //public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public string Colour { get; set; } = string.Empty;
        public double Mileage { get; set; }
        public string Comments { get; set; } = String.Empty;
        public int? AdvertisingPlatformId { get; set; }
        public DateTime? BroughtDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime? TransferedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime? ResoldDate { get; set; }
        public double? SoldAmount { get; set; }
        public int ClientId { get; set; }
        public double? ClientAmount { get; set; }
        public double? CommissionAmount { get; set; }
        public int? UserId { get; set; } // capture person who sold the car
        public bool? IsSold { get; set; }
    }
}
