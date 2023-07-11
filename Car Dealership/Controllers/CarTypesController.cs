namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarTypesController : ControllerBase
    {
        private readonly ICarTypeService _carTypeService;
        public CarTypesController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarTypeGetDto>>> GetCarTypes()
        {
            return await _carTypeService.GetCarTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarTypeGetDto?>> GetCarType(int id)
        {
            return await _carTypeService.GetCarTypeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarTypeGetDto?>> CreateCarType(CarTypeCreateDto CarTypeCreateDto)
        {
            return await _carTypeService.CreateCarTypeAsync(CarTypeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarTypeGetDto?>> UpdateCarType(CarTypeEditDto CarTypeEditDto)
        {
            return await _carTypeService.UpdateCarTypeAsync(CarTypeEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarTypeGetDto?>> DeleteCarType(int id)
        {
            return await _carTypeService.DeleteCarTypeAsync(id);
        }
    }
}
