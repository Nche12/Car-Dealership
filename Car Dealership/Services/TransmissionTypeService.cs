namespace Car_Dealership.Services
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public TransmissionTypeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<TransmissionTypeGetDto?>> AddTransmissionTypeAsync(TransmissionTypeCreateDto transmissionTypeCreateDto)
        {
            var serviceResponse = new ServiceResponse<TransmissionTypeGetDto?>();
            var transmissionType = _mapper.Map<TransmissionType>(transmissionTypeCreateDto);
            _tenantContext.TransmissionTypes.Add(transmissionType);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<TransmissionTypeGetDto>(transmissionType);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = $"{transmissionType?.Name} was not found";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TransmissionTypeGetDto?>> DeleteTransmissionTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<TransmissionTypeGetDto?>();
            var transmissionType = await _tenantContext.TransmissionTypes.FirstOrDefaultAsync(t => t.Id == id);
            if (transmissionType == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = $"{transmissionType?.Name} was not found";
            }
            else
            {
                _tenantContext.TransmissionTypes.Remove(transmissionType);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<TransmissionTypeGetDto>(transmissionType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TransmissionTypeGetDto?>> GetTransmissionTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<TransmissionTypeGetDto?>();
            var transmissionType = await _tenantContext.TransmissionTypes.FirstOrDefaultAsync(t => t.Id == id);
            if (transmissionType != null)
            {
                serviceResponse.Data = _mapper.Map<TransmissionTypeGetDto>(transmissionType);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Transmission Type not found";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<TransmissionTypeGetDto>>> GetTransmissionTypesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TransmissionTypeGetDto>>();
            var transmissionTypes = await _tenantContext.TransmissionTypes.ToArrayAsync();
            serviceResponse.Data = transmissionTypes.Select(t => _mapper.Map<TransmissionTypeGetDto>(t)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;

        }

        public async Task<ServiceResponse<TransmissionTypeGetDto?>> UpdateTransmissionTypeAsync(TransmissionTypeEditDto transmissionTypeEditDto)
        {
            var serviceResponse = new ServiceResponse<TransmissionTypeGetDto?>();
            var transmissionType = _mapper.Map<TransmissionType>(transmissionTypeEditDto);
            _tenantContext.Entry(transmissionType).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<TransmissionTypeGetDto>(transmissionType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch(DbUpdateConcurrencyException)
            { 
                if(!TransmissionTypeExists(transmissionType.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = $"Transmission Type '{transmissionType.Name}' not found";
                    serviceResponse.Success = false;
                } 
                else
                {
                    throw;
                }
            }

            return serviceResponse;

        }

        public bool TransmissionTypeExists(int id)
        {
            return _tenantContext.TransmissionTypes.Any(t => t.Id == id);
        }
    }
}
