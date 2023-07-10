
namespace Car_Dealership.Interfaces
{
    public interface ITransmissionTypeService
    {
        Task<ServiceResponse<IEnumerable<TransmissionTypeGetDto>>> GetTransmissionTypesAsync();
        Task<ServiceResponse<TransmissionTypeGetDto?>> GetTransmissionTypeAsync(int id);
        Task<ServiceResponse<TransmissionTypeGetDto?>> AddTransmissionTypeAsync(TransmissionTypeCreateDto transmissionTypeCreateDto);
        Task<ServiceResponse<TransmissionTypeGetDto?>> UpdateTransmissionTypeAsync(TransmissionTypeEditDto transmissionTypeEditDto);
        Task<ServiceResponse<TransmissionTypeGetDto?>> DeleteTransmissionTypeAsync(int id);
    }
}
