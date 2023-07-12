namespace Car_Dealership.Interfaces
{
    public interface ICarColourService
    {
        Task<ServiceResponse<IEnumerable<CarColourGetDto>>> GetColoursAsync();
        Task<ServiceResponse<CarColourGetDto?>> GetColourAsync(int id);
        Task<ServiceResponse<CarColourGetDto?>> CreateColourAsync(CarColourCreateDto carColourCreateDto);
        Task<ServiceResponse<CarColourGetDto?>> UpdateColourAsync(CarColourEditDto carColourEditDto);
        Task<ServiceResponse<CarColourGetDto?>> DeleteColourAsync(int id);
    }
}
