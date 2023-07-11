using Car_Dealership.Models;
using Microsoft.VisualBasic.FileIO;

namespace Car_Dealership.Services
{
    public class CarTypeService : ICarTypeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarTypeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CarTypeGetDto?>> CreateCarTypeAsync(CarTypeCreateDto carTypeCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarTypeGetDto?>();
            var carType = _mapper.Map<CarType>(carTypeCreateDto);
            _tenantContext.CarTypes.Add(carType);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarTypeGetDto>(carType);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.CarTypes' with unique index 'IX_CarTypes_Name'. The duplicate key value is ({carType.Name})."))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Car Type '{carType.Name}' already exists";
                    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                }
                else
                {
                    throw;
                }
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CarTypeGetDto?>> DeleteCarTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarTypeGetDto?>();
            var carType = await _tenantContext.CarTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (carType == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Type not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                _tenantContext.CarTypes.Remove(carType);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarTypeGetDto>(carType);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarTypeGetDto?>> GetCarTypeAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarTypeGetDto?>();
            var carType = await _tenantContext.CarTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (carType == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Type not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                serviceResponse.Data = _mapper.Map<CarTypeGetDto>(carType);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarTypeGetDto>>> GetCarTypesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarTypeGetDto>>();
            var carTypes = await _tenantContext.CarTypes.ToArrayAsync();
            serviceResponse.Data = carTypes.Select(c => _mapper.Map<CarTypeGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarTypeGetDto?>> UpdateCarTypeAsync(CarTypeEditDto carTypeEditDto)
        {
            var serviceResponse = new ServiceResponse<CarTypeGetDto?>();
            var carType = _mapper.Map<CarType>(carTypeEditDto);
            _tenantContext.Entry(carType).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarTypeGetDto>(carType);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CarTypeExists(carType.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Car Type not found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool CarTypeExists(int id)
        {
            return _tenantContext.CarTypes.Any(c => c.Id == id);
        }
    }
}
