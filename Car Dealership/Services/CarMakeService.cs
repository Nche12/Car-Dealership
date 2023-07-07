namespace Car_Dealership.Services
{
    public class CarMakeService : ICarMakeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarMakeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<CarMakeGetDto>>> GetCarMakesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarMakeGetDto>>();
            var carMakes = await _tenantContext.CarMakes.ToArrayAsync();
            serviceResponse.Data = carMakes.Select(c => _mapper.Map<CarMakeGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarMakeGetDto?>> GetCarMakeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarMakeGetDto?>();
            var carMake = await _tenantContext.CarMakes.FirstOrDefaultAsync(c => c.Id == id);
            if (carMake is null)
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Make not found";
            }
            else
            {
                serviceResponse.Data = _mapper.Map<CarMakeGetDto>(carMake);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<CarMakeGetDto?>> AddCarMakeAsync(CarMakeCreateDto carMakeCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarMakeGetDto?>();
            var carMake = _mapper.Map<CarMake>(carMakeCreateDto);
            _tenantContext.CarMakes.Add(carMake);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarMakeGetDto>(carMake);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            } 
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.CarMakes' with unique index 'IX_CarMakes_Name'. The duplicate key value is ({carMake.Name})."))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"{carMake.Name} already esists";
                    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                }
                else
                {
                    throw;
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CarMakeGetDto?>> UpdateCarMakeAsync(CarMakeEditDto carMakeEditDto)
        {
            var serviceResponse = new ServiceResponse<CarMakeGetDto?>();
            var carMake = _mapper.Map<CarMake>(carMakeEditDto);
            _tenantContext.CarMakes.Entry(carMake).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarMakeGetDto>(carMake);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakeExists(carMake.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Car Make not found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarMakeGetDto?>> DeleteCarMakeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarMakeGetDto?>();
            var carMake = await _tenantContext.CarMakes.FirstOrDefaultAsync(c => c.Id == id);
            if (carMake is null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Make was not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                _tenantContext.CarMakes.Remove(carMake);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarMakeGetDto>(carMake);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            return serviceResponse;
        }

        public bool CarMakeExists(int id)
        {
            return _tenantContext.CarMakes.Any(c => c.Id == id);
        }
    }
}
