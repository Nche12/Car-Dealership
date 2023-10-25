using Car_Dealership.DTOs.AdvertisingPlatform;
using Car_Dealership.Models;

namespace Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertPlatformController : ControllerBase
    {
        private readonly IAdvertPlatformService _advertPlatformService;

        public AdvertPlatformController(IAdvertPlatformService advertPlatformService)
        {
            _advertPlatformService = advertPlatformService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>> GetAdvertPlatforms()
        {
            return await _advertPlatformService.GetAdvertPlatformsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> GetAdvertPlatform(int id)
        {
            return await _advertPlatformService.GetAdvertPlatformAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> CreateAdvertPlatform(AdvertisingPlatformCreateDto advertisingPlatformCreateDto)
        {
            return await _advertPlatformService.CreateAdvertPlatformAsync(advertisingPlatformCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> UpdateAdvertPlatform(AdvertisingPlatformEditDto advertisingPlatformEditDto)
        {
            return await _advertPlatformService.UpdateAdvertPlatformAsync(advertisingPlatformEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> DeleteAdvertPlatform(int id)
        {
            return await _advertPlatformService.DeleteAdvertPlatformAsync(id);
        }
    }
}
