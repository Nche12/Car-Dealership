namespace Car_Dealership.Interfaces
{
    public interface ICarModelService
    {
        Task<ServiceResponse<IEnumerable<CarModelGetDto>>> GetCarModelsAsync();
        Task<ServiceResponse<CarModelGetDto?>> GetCarModelAsync(int id);
        Task<ServiceResponse<CarModelGetDto?>> AddCarModelAsync(CarModelCreateDto carModelCreateDto);
        Task<ServiceResponse<CarModelGetDto?>> UpdateCarModelAsync(CarModelEditDto carModelEditDto);
        Task<ServiceResponse<CarModelGetDto?>> DeleteCarModelAsync(int id);
    }
}
