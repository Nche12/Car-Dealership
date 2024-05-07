namespace Car_Dealership.Models
{
    public class Car : Auditable
    {
        public int Id { get; set; }
        //public int CarMakeId { get; set; }
        //public CarMake? CarMake { get; set; }
        public int CarModelId { get; set; }
        public CarModel? CarModel { get; set; }
        public int CarColourId { get; set; }
        public CarColour? CarColour { get; set; }
        public double Mileage { get; set; }
        public string Comments { get; set; } = String.Empty;
        public int? AdvertisingPlatformId { get; set; }
        public AdvertisingPlatform? AdvertisingPlatform { get; set; }
        public DateTime? BroughtDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime? TransferedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime? ResoldDate { get; set; }
        public double? SoldAmount { get; set; }
        public int ClientId {  get; set; }
        public Client? Client { get; set; }
        public double? ClientAmount { get;set; }
        public double? CommissionAmount { get; set;}
        public int? UserId { get; set; } // capture person who sold the car
        public User? User { get; set; }
        public bool? IsSold { get; set; }
        public int Year { get; set; }
        public double? SellingPrice { get; set; }
        public string VinNumber { get; set; } = String.Empty;
    }
}
