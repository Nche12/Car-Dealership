
namespace Car_Dealership.Interfaces
{
    public interface IAdvertPlatformService
    {
        Task<ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>> GetAdvertPlatformsAsync();
        Task<ServiceResponse<AdvertisingPlatformEditDto?>> GetAdvertPlatformAsync(int id);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> CreateAdvertPlatformAsync(AdvertisingPlatformCreateDto AdvertPlatformcreateDto);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> UpdateAdvertPlatformAsync(AdvertisingPlatformEditDto AdvertPlatformuEditDto);
        Task<ServiceResponse<AdvertisingPlatformGetDto?>> DeleteAdvertPlatformAsync(int id);
    }
}
