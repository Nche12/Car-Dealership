using Microsoft.EntityFrameworkCore;

namespace Car_Dealership.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public CarModelService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CarModelGetDto?>> AddCarModelAsync(CarModelCreateDto carModelCreateDto)
        {
            var serviceResponse = new ServiceResponse<CarModelGetDto?>();
            var model = _mapper.Map<CarModel>(carModelCreateDto);
            _tenantContext.CarModels.Add(model);

            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarModelGetDto>(model);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.CarModels' with unique index 'IX_CarModels_Name'. The duplicate key value is ({model.Name})."))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"{model.Name} already exists";
                    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                } 
                else
                {
                    throw;
                }

            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarModelGetDto?>> DeleteCarModelAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarModelGetDto?>();
            var model = await _tenantContext.CarModels.FirstOrDefaultAsync(m => m.Id == id);
            if (model != null)
            {
                _tenantContext.CarModels.Remove(model);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarModelGetDto>(model);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Model Not Found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarModelGetDto?>> GetCarModelAsync(int id)
        {
            var serviceResponse = new ServiceResponse<CarModelGetDto?>();
            var model = await _tenantContext.CarModels
                .Include(c => c.CarMake)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model != null)
            {
                serviceResponse.Data = _mapper.Map<CarModelGetDto>(model);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Car Model Not Found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarModelGetDto>>> GetCarModelsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<CarModelGetDto>>();
            var models = await _tenantContext.CarModels
                .Include(c => c.CarMake)
                .ToArrayAsync();
            serviceResponse.Data = models.Select(c => _mapper.Map<CarModelGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarModelGetDto?>> UpdateCarModelAsync(CarModelEditDto carModelEditDto)
        {
            var serviceResponse = new ServiceResponse<CarModelGetDto?>();
            var model = _mapper.Map<CarModel>(carModelEditDto);
            _tenantContext.CarModels.Entry(model).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CarModelGetDto>(model);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(model.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Car Model Not Found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool CarModelExists(int id)
        {
            return _tenantContext.CarModels.Any(c => c.Id == id);
        }
    }
}
