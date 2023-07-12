namespace Car_Dealership.Services
{
    public class CarColourService : ICarColourService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarColourService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CarColourGetDto?>> CreateColourAsync(CarColourCreateDto carColourCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarColourGetDto?>();
            var colour = _mapper.Map<CarColour>(carColourCreateDto);
            var colourFound = await _tenantContext.CarColours.FirstOrDefaultAsync(c => c.Name == carColourCreateDto.Name);
            if (colourFound == null)
            {
                _tenantContext.CarColours.Add(colour);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarColourGetDto>(colour);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Car Colour '{colour.Name}' already exists.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarColourGetDto?>> DeleteColourAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarColourGetDto?>();
            var colour = await _tenantContext.CarColours.FirstOrDefaultAsync(c => c.Id == id);
            if (colour != null)
            {
                _tenantContext.CarColours.Remove(colour);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarColourGetDto>(colour);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Colour not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarColourGetDto?>> GetColourAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarColourGetDto?>();
            var colour = await _tenantContext.CarColours.FirstOrDefaultAsync(c => c.Id == id);
            if (colour != null)
            {
                serviceResponse.Data = _mapper.Map<CarColourGetDto>(colour);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Colour not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarColourGetDto>>> GetColoursAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarColourGetDto>>();
            var colours = await _tenantContext.CarColours.ToArrayAsync();
            serviceResponse.Data = colours.Select(c => _mapper.Map<CarColourGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarColourGetDto?>> UpdateColourAsync(CarColourEditDto carColourEditDto)
        {
            var serviceResponse = new ServiceResponse<CarColourGetDto?>();
            var colour = _mapper.Map<CarColour>(carColourEditDto);
            _tenantContext.Entry(colour).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarColourGetDto>(colour);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarColourExists(colour.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Car Colour not found.";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool CarColourExists(int id)
        {
            return _tenantContext.CarColours.Any(c => c.Id == id);
        }
    }
}
