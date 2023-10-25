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

        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> DeleteAdvertPlatformAsync(int id)
        {
            var serviceResponse = new ServiceResponse<AdvertisingPlatformGetDto?>();
            var adPlatform = await _tenantContext.AdvertisingPlatforms.FirstOrDefaultAsync(ap =>ap.Id == id);
            if(adPlatform != null)
            {
                _tenantContext.AdvertisingPlatforms.Remove(adPlatform);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<AdvertisingPlatformGetDto>(adPlatform);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data= null;
                serviceResponse.Success= false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Advertising Platform not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> GetAdvertPlatformAsync(int id)
        {
            var serviceResponse = new ServiceResponse<AdvertisingPlatformGetDto?>();
            var adPlatform = await _tenantContext.AdvertisingPlatforms.FirstOrDefaultAsync(ap => ap.Id == id);
            if(adPlatform != null)
            {
                serviceResponse.Data = _mapper.Map<AdvertisingPlatformGetDto>(adPlatform) ;
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data= null;
                serviceResponse.Success= false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Advertising Platform not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>> GetAdvertPlatformsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<AdvertisingPlatformGetDto>>();
            var adPlatforms = await _tenantContext.AdvertisingPlatforms.ToArrayAsync();
            serviceResponse.Data = adPlatforms.Select(ap => _mapper.Map<AdvertisingPlatformGetDto>(ap)).ToList();
            serviceResponse.StatusCode= StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AdvertisingPlatformGetDto?>> UpdateAdvertPlatformAsync(AdvertisingPlatformEditDto advertPlatformuEditDto)
        {
            var serviceResponse = new ServiceResponse<AdvertisingPlatformGetDto?>(); 
            var adPlatform = _mapper.Map<AdvertisingPlatform>(advertPlatformuEditDto);
            _tenantContext.AdvertisingPlatforms.Entry(adPlatform).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<AdvertisingPlatformGetDto>(adPlatform);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adPlatformExists(adPlatform.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = "Advertising Platform not found.";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool adPlatformExists(int  id)
        {
            return _tenantContext.AdvertisingPlatforms.Any(ap => ap.Id == id);
        }
    }
}
