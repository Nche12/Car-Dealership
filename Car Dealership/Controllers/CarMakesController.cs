namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarMakesController : ControllerBase
    {
        private readonly CarMakeService _carMakeService;
        public CarMakesController(CarMakeService carMakeService)
        {
            _carMakeService = carMakeService;
        }
        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarMakeGetDto>>> GetCarMakes()
        {
            return await _carMakeService.GetCarMakesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarMakeGetDto?>> GetCarMake(int id)
        {
            return await _carMakeService.GetCarMakeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarMakeGetDto?>> CreateCarMake(CarMakeCreateDto carMakeCreateDto)
        {
            return await _carMakeService.AddCarMakeAsync(carMakeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarMakeGetDto?>> UpdateCarMake(CarMakeEditDto carMakeEditDto)
        {
            return await _carMakeService.UpdateCarMakeAsync(carMakeEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarMakeGetDto?>> DeleteCarMake(int id)
        {
            return await _carMakeService.DeleteCarMakeAsync(id);
        }
    }
}
