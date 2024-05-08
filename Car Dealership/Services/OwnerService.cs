
namespace Car_Dealership.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;

        public OwnerService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<OwnerGetDto?>> CreateOwnerAsync(OwnerCreateDto ownerCreateDto)
        {
            var serviceResponse = new ServiceResponse<OwnerGetDto?>();
            var owner = _mapper.Map<Owner>(ownerCreateDto);
            var ownerFound = await _tenantContext.Owners.FirstOrDefaultAsync(c => c.Email == ownerCreateDto.Email);
            if (ownerFound == null)
            {
                _tenantContext.Owners.Add(owner);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<OwnerGetDto>(owner);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Owner Email '{owner.Email}' already exists.";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<OwnerGetDto?>> DeleteOwnerAsync(int id)
        {
            var serviceResponse = new ServiceResponse<OwnerGetDto?>();
            var owner = await _tenantContext.Owners.FirstOrDefaultAsync(o => o.Id == id);
            if (owner != null)
            {
                _tenantContext.Owners.Remove(owner);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<OwnerGetDto>(owner);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Owner not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<OwnerGetDto>>> GetOwnersAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<OwnerGetDto>>();
            var owners = await _tenantContext.Owners.ToArrayAsync();
            serviceResponse.Data = owners.Select(o => _mapper.Map<OwnerGetDto>(o)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<OwnerGetDto?>> GetOwnerAsync(int id)
        {
            var serviceResponse = new ServiceResponse<OwnerGetDto?>();
            var owner = await _tenantContext.Owners.FirstOrDefaultAsync(o => o.Id == id);
            if (owner != null)
            {
                serviceResponse.Data = _mapper.Map<OwnerGetDto>(owner);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Owner not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<OwnerGetDto?>> UpdateOwnerAsync(OwnerEditDto ownerEditDto)
        {
            var serviceResponse = new ServiceResponse<OwnerGetDto?>();
            var owner = _mapper.Map<Owner>(ownerEditDto);
            _tenantContext.Entry(owner).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<OwnerGetDto>(owner);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(owner.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Owner not found.";
                }
            }

            return serviceResponse;
        }

        public bool OwnerExists(int id)
        {
            return _tenantContext.Owners.Any(o => o.Id == id);
        }
    }
}
