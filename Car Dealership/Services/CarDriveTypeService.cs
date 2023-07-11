namespace Car_Dealership.Services
{
    public class CarDriveTypeService : ICarDriveTypeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarDriveTypeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CarDriveTypeGetDto?>> CreateCarDriveTypeAsync(CarDriveTypeCreateDto carDriveTypeCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarDriveTypeGetDto?>();
            var driveType = _mapper.Map<CarDriveType>(carDriveTypeCreateDto);
            var driveTypeFound = await _tenantContext.CarDriveTypes.FirstOrDefaultAsync(c => c.Name == driveType.Name);
            if (driveTypeFound != null)
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Car drive Type '{driveType.Name}' already exists.";
            }
            else
            {
                _tenantContext.CarDriveTypes.Add(driveType);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarDriveTypeGetDto>(driveType);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarDriveTypeGetDto?>> DeleteCarDriveTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarDriveTypeGetDto?>();
            var driveType = await _tenantContext.CarDriveTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (driveType != null)
            {
                _tenantContext.CarDriveTypes.Remove(driveType);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarDriveTypeGetDto>(driveType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car drive Type not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarDriveTypeGetDto?>> GetCarDriveTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarDriveTypeGetDto?>();
            var driveType = await _tenantContext.CarDriveTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (driveType != null)
            {
                serviceResponse.Data = _mapper.Map<CarDriveTypeGetDto>(driveType);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car drive Type not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarDriveTypeGetDto>>> GetCarDriveTypesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarDriveTypeGetDto>>();
            var driveTypes = await _tenantContext.CarDriveTypes.ToArrayAsync();
            serviceResponse.Data = driveTypes.Select(d => _mapper.Map<CarDriveTypeGetDto>(d)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarDriveTypeGetDto?>> UpdateCarDriveTypeAsync(CarDriveTypeEditDto carDriveTypeEditDto)
        {
            var serviceResponse = new ServiceResponse<CarDriveTypeGetDto?>();
            var drivetype = _mapper.Map<CarDriveTypeGetDto>(carDriveTypeEditDto);
            _tenantContext.Entry(drivetype).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarDriveTypeGetDto>(drivetype);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            } 
            catch (DbUpdateConcurrencyException)
            {
                if (!DriveTypeExists(drivetype.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Car drive Type not found";
                } 
                else
                {
                    throw;
                }
            }

            return serviceResponse;
        }

        public bool DriveTypeExists(int id)
        {
            return _tenantContext.CarDriveTypes.Any(d => d.Id == id);
        }
    }
}
