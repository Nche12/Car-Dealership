namespace Car_Dealership.Interfaces
{
    public interface ICarMakeService
    {
        Task<ServiceResponse<IEnumerable<CarMakeGetDto>>> GetCarMakesAsync();
        Task<ServiceResponse<CarMakeGetDto?>> GetCarMakeAsync(int id);
        Task<ServiceResponse<CarMakeGetDto?>> AddCarMakeAsync(CarMakeCreateDto carMakeCreateDto);
        Task<ServiceResponse<CarMakeGetDto?>> UpdateCarMakeAsync(CarMakeEditDto carMakeEditDto);
        Task<ServiceResponse<CarMakeGetDto?>> DeleteCarMakeAsync(int id);
    }
}
