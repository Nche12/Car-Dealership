namespace Car_Dealership.Interfaces
{
    public interface IOwnerService
    {
        Task<ServiceResponse<IEnumerable<OwnerGetDto>>> GetOwnersAsync();
        Task<ServiceResponse<OwnerGetDto?>> GetOwnerAsync(int id);
        Task<ServiceResponse<OwnerGetDto?>> CreateOwnerAsync(OwnerCreateDto ownerCreateDto);
        Task<ServiceResponse<OwnerGetDto?>> UpdateOwnerAsync(OwnerEditDto ownerEditDto);
        Task<ServiceResponse<OwnerGetDto?>> DeleteOwnerAsync(int id);
    }
}
