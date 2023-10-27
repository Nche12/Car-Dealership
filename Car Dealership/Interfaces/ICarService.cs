namespace Car_Dealership.Interfaces
{
    public interface ICarService
    {
        Task<ServiceResponse<IEnumerable<CarGetDto>>> GetCarsAsync();
        Task<ServiceResponse<CarGetDto?>> GetCarAsync(int id);
        Task<ServiceResponse<CarGetDto?>> CreateCarAsync(CarCreateDto carCreateDto);
        Task<ServiceResponse<CarGetDto?>> UpdateCarAsync(CarEditDto carEditDto);
        Task<ServiceResponse<CarGetDto?>> DeleteCarAsync(int id);

    }
}
