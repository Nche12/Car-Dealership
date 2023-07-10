namespace Car_Dealership.Interfaces
{
    public interface IFuelTypeService
    {
        Task<ServiceResponse<IEnumerable<FuelTypeGetDto>>> GetFuelTypesAsync();
        Task<ServiceResponse<FuelTypeGetDto?>> GetFuelTypeAsync(int id);
        Task<ServiceResponse<FuelTypeGetDto?>> CreateFuelTypeAsync(FuelTypeCreateDto fuelTypeCreateDto);
        Task<ServiceResponse<FuelTypeGetDto?>> UpdateFuelTypeAsync(FuelTypeEditDto fuelTypeEditDto);
        Task<ServiceResponse<FuelTypeGetDto?>> DeleteFuelTypeAsync(int id);
    }
}
