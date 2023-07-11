namespace Car_Dealership.Interfaces
{
    public interface ICarTypeService
    {
        Task<ServiceResponse<IEnumerable<CarTypeGetDto>>> GetCarTypesAsync();
        Task<ServiceResponse<CarTypeGetDto?>> GetCarTypeAsync(int id);
        Task<ServiceResponse<CarTypeGetDto?>> CreateCarTypeAsync(CarTypeCreateDto carTypeCreateDto);
        Task<ServiceResponse<CarTypeGetDto?>> UpdateCarTypeAsync(CarTypeEditDto carTypeEditDto);
        Task<ServiceResponse<CarTypeGetDto?>> DeleteCarTypeAsync(int id);
    }
}
