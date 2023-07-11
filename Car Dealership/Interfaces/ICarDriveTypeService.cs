namespace Car_Dealership.Interfaces
{
    public interface ICarDriveTypeService
    {
        Task<ServiceResponse<IEnumerable<CarDriveTypeGetDto>>> GetCarDriveTypesAsync();
        Task<ServiceResponse<CarDriveTypeGetDto?>> GetCarDriveTypeAsync(int id);
        Task<ServiceResponse<CarDriveTypeGetDto?>> CreateCarDriveTypeAsync(CarDriveTypeCreateDto carDriveTypeCreateDto);
        Task<ServiceResponse<CarDriveTypeGetDto?>> UpdateCarDriveTypeAsync(CarDriveTypeEditDto carDriveTypeEditDto);
        Task<ServiceResponse<CarDriveTypeGetDto?>> DeleteCarDriveTypeAsync(int id);
    }
}
