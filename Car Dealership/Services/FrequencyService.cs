namespace Car_Dealership.Services
{
    public class FrequencyService : IFrequencyService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public FrequencyService(TenantContext tenantContext, IMapper mapper) 
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FrequencyGetDto?>> CreateFrequencyAsync(FrequencyCreateDto frequencyCreateDto)
        {
            var serviceResponse = new ServiceResponse<FrequencyGetDto?>();
            var frequency = _mapper.Map<Frequency>(frequencyCreateDto);
            var frequencyFound = _tenantContext.Frequencies.FirstOrDefaultAsync(f => frequency.Name == f.Name);
            if(frequencyFound == null)
            {
                _tenantContext.Frequencies.Add(frequency);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FrequencyGetDto>(frequency);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Frequency '{frequency.Name}' already exists";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<FrequencyGetDto>>> GetFrequenciesAsync() 
        {
            var serviceResponse = new ServiceResponse<IEnumerable<FrequencyGetDto>>();
            var frequencies = await _tenantContext.Frequencies.ToArrayAsync();
            serviceResponse.Data = frequencies.Select(f => _mapper.Map<FrequencyGetDto>(f)).ToList();
            serviceResponse.Success = true;
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<FrequencyGetDto?>> GetFrequencyAsync(int id)
        {
            var serviceResponse = new ServiceResponse<FrequencyGetDto?>();
            var frequency = await _tenantContext.Frequencies.FirstOrDefaultAsync(f => f.Id == id);
            if(frequency != null)
            {
                serviceResponse.Data = _mapper.Map<FrequencyGetDto>(frequency);
                serviceResponse.StatusCode= StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Frequency could not be found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FrequencyGetDto?>> UpdateFrequencyAsync(FrequencyEditDto frequencyEditDto)
        {
            var serviceResponse = new ServiceResponse<FrequencyGetDto?>();
            var frequency = _mapper.Map<Frequency>(frequencyEditDto);
            _tenantContext.Entry(frequency).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FrequencyGetDto>(frequency);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            } 
            catch (DbUpdateConcurrencyException)
            {
                if (!frequencyExists(frequency.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Success= false;
                    serviceResponse.Message = "Frequency Not Found.";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FrequencyGetDto?>> DeleteFrequencyAsync(int frequencyId)
        {
            var serviceResponse = new ServiceResponse<FrequencyGetDto?>();
            var frequency = await _tenantContext.Frequencies.FirstOrDefaultAsync(f => f.Id == frequencyId);
            if(frequency != null)
            {
                _tenantContext.Frequencies.Remove(frequency);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FrequencyGetDto>(frequency);
                serviceResponse.StatusCode= StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data= null;
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Frequency does not exist";
            }
            return serviceResponse;
        }

        public bool frequencyExists(int frequencyId)
        {
            return _tenantContext.Frequencies.Any(f => f.Id == frequencyId);
        }

       
    }
}
