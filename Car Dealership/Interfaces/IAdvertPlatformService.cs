
namespace Car_Dealership.Interfaces
{
    public interface IAdvertPlatformService
    {
        Task<ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>> GetAdvertPlatformsAsync();
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> GetAdvertPlatformAsync(int id);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> CreateAdvertPlatformAsync(AdvertisingPlatformCreateDto AdvertPlatformCreateDto);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> UpdateAdvertPlatformAsync(AdvertisingPlatformEditDto AdvertPlatformuEditDto);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> DeleteAdvertPlatformAsync(int id);
    }
}
