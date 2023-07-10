namespace Car_Dealership.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;

        public FuelTypeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FuelTypeGetDto?>> CreateFuelTypeAsync(FuelTypeCreateDto fuelTypeCreateDto)
        {
            var serviceResponse = new ServiceResponse<FuelTypeGetDto?>();
            var fuelType = _mapper.Map<FuelType>(fuelTypeCreateDto);
            _tenantContext.FuelTypes.Add(fuelType);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FuelTypeGetDto>(fuelType);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            } 
            catch (DbUpdateException ex)
            {
                if(ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.FuelTypes' with unique index 'IX_FuelTypes_Name'. The duplicate key value is ({fuelType.Name})."))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Fuel Type '{fuelType.Name}' already exists";
                    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                }
                else
                {
                    throw;
                }
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuelTypeGetDto?>> DeleteFuelTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<FuelTypeGetDto?>();
            var fuelType = await  _tenantContext.FuelTypes.FirstOrDefaultAsync(f => f.Id == id);
            if (fuelType == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Fuel Type not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                _tenantContext.FuelTypes.Remove(fuelType);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FuelTypeGetDto>(fuelType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuelTypeGetDto?>> GetFuelTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<FuelTypeGetDto?>();
            var fuelType = await _tenantContext.FuelTypes.FirstOrDefaultAsync(f => f.Id == id);
            if (fuelType == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Fuel Type not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound; 
            }
            else
            {
                serviceResponse.Data = _mapper.Map<FuelTypeGetDto>(fuelType);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<FuelTypeGetDto>>> GetFuelTypesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<FuelTypeGetDto>>();
            var fuelTypes = await _tenantContext.FuelTypes.ToArrayAsync();
            serviceResponse.Data = fuelTypes.Select(x => _mapper.Map<FuelTypeGetDto>(x)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuelTypeGetDto?>> UpdateFuelTypeAsync(FuelTypeEditDto fuelTypeEditDto)
        {
            var serviceResponse = new ServiceResponse<FuelTypeGetDto?>();
            var fuelType = _mapper.Map<FuelType>(fuelTypeEditDto);
            _tenantContext.Entry(fuelType).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<FuelTypeGetDto>(fuelType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelTypeExists(fuelType.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Fuel Type not found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    throw;
                }
            }

            return serviceResponse;
        }

        private bool FuelTypeExists(int id)
        {
            return _tenantContext.FuelTypes.Any(x => x.Id == id);
        }
    }
}
