namespace Car_Dealership.Services
{
    public class CarService : ICarService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarService(TenantContext tenantContext, IMapper mapper) 
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CarGetDto?>> CreateCarAsync(CarCreateDto carCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarGetDto?>();
            var car = _mapper.Map<Car>(carCreateDto);
            _tenantContext.Cars.Add(car);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarGetDto>(car);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            catch (Exception)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "An Error occured.";
                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarGetDto?>> DeleteCarAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarGetDto?>();
            var car = await _tenantContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                _tenantContext.Cars.Remove(car);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarGetDto>(car);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Car not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarGetDto?>> GetCarAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarGetDto?>();
            var car = await _tenantContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                serviceResponse.Data = _mapper.Map<CarGetDto>(car);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Car not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarGetDto>>> GetCarsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarGetDto>>();
            var cars = await _tenantContext.Cars
                            .Include(c => c.CarModel)
                            .Include(c => c.CarColour)
                            .Include(c => c.AdvertisingPlatform)
                            .Include(c => c.User)
                            .ToArrayAsync();
            serviceResponse.Data = cars.Select(c => _mapper.Map<CarGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK; 
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarGetDto?>> UpdateCarAsync(CarEditDto carEditDto)
        {
            var serviceResponse = new ServiceResponse<CarGetDto?>();
            var car = _mapper.Map<Car>(carEditDto);
            _tenantContext.Cars.Entry(car).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarGetDto>(car);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CarExists(car.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = "Car not found.";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool CarExists(int id)
        {
            return _tenantContext.Cars.Any(c => c.Id == id);
        }
    }
}
