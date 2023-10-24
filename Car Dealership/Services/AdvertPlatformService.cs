namespace Car_Dealership.Services
{
    public class AdvertPlatformService : IAdvertPlatformService
    {
        private readonly IMapper _mapper;
        private readonly TenantContext _tenantContext;
        public AdvertPlatformService(IMapper mapper, TenantContext tenantContext) 
        {
            _mapper = mapper;
            _tenantContext = tenantContext;
        }
        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> CreateAdvertPlatformAsync(AdvertisingPlatformCreateDto advertPlatformcreateDto)
        {
            var serviceResponse = new ServiceResponse<AdvertisingPlatformGetDto?>();
            var adPlatform = _mapper.Map<AdvertisingPlatform>(advertPlatformcreateDto);
            var adPlatformFound = await _tenantContext.AdvertisingPlatforms.FirstOrDefaultAsync(ap => ap.Name == adPlatform.Name);
            if(adPlatformFound == null)
            {
                _tenantContext.AdvertisingPlatforms.Add(adPlatform);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<AdvertisingPlatformGetDto>(adPlatform);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            } 
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Message = $"Advertising platform '{adPlatform.Name}' already exists.";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<AdvertisingPlatformGetDto?>> DeleteAdvertPlatformAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AdvertisingPlatformEditDto?>> GetAdvertPlatformAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>> GetAdvertPlatformsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<AdvertisingPlatformGetDto?>> UpdateAdvertPlatformAsync(AdvertisingPlatformEditDto AdvertPlatformuEditDto)
        {
            throw new NotImplementedException();
        }
    }
}
