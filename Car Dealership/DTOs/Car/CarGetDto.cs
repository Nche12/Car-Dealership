namespace Car_Dealership.DTOs.Car
{
    public class CarGetDto
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public string? CarMakeName { get; set; }
        public CarMakeGetDto? CarMake { get; set; }
        public int CarModelId { get; set; }
        public CarModelGetDto? CarModel { get; set; }
        public int SeatTypeId { get; set; }
        public SeatTypeGetDto? SeatType { get; set; }
        public int NumberOfDoors { get; set; }
        public int CarTypeId { get; set; }
        public CarTypeGetDto? CarType { get; set; }
        public int TransmissionTypeId { get; set; }
        public TransmissionTypeGetDto? TransmissionType { get; set; }
        public int FuelTypeId { get; set; }
        public FuelTypeGetDto? FuelType { get; set; }
        public int CarDriveTypeId { get; set; }
        public CarDriveType? CarDriveType { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int ColourId { get; set; }
        public CarColourGetDto? CarColour { get; set; }
    }
}
