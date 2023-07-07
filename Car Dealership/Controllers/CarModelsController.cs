namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarModelsController : ControllerBase
    {
        private readonly ICarModelService _modelService;
        public CarModelsController(ICarModelService carModelService) 
        {
            _modelService = carModelService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarModelGetDto>>> GetCarModels()
        {
            return await _modelService.GetCarModelsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarModelGetDto?>> GetCarModel(int id)
        {
            return await _modelService.GetCarModelAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarModelGetDto?>> CreateCarModel(CarModelCreateDto carModelCreateDto)
        {
            return await _modelService.AddCarModelAsync(carModelCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarModelGetDto?>> UpdateCarModel(CarModelEditDto carModelEditDto)
        {
            return await _modelService.UpdateCarModelAsync(carModelEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarModelGetDto?>> DeleteCarModel(int id)
        {
            return await _modelService.DeleteCarModelAsync(id);
        }
    }
}
