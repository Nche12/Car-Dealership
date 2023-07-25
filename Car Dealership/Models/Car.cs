namespace Car_Dealership.Models
{
    public class Car : Auditable
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public CarMake? CarMake { get; set; }
        public int CarModelId { get; set; }
        public CarModel? CarModel { get; set; }
        public int SeatTypeId { get; set; }
        public SeatType? SeatType { get; set; }
        public int NumberOfDoors { get; set; }
        public int CarTypeId { get; set; }
        public CarType? CarType { get; set; }
        public int TransmissionTypeId { get; set; }
        public TransmissionType? TransmissionType { get; set; }
        public int FuelTypeId { get; set; }
        public FuelType? FuelType { get; set; }
        public int CarDriveTypeId { get; set; }
        public CarDriveType? CarDriveType { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int ColourId { get; set; }
        public CarColour? CarColour { get; set; }

    }
}
