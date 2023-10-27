namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService) 
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarGetDto>>> GetCars()
        {
            return await _carService.GetCarsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarGetDto?>> GetCar(int id)
        {
            return await _carService.GetCarAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarGetDto?>> UpdateCar(CarEditDto carEditDto)
        {
            return await _carService.UpdateCarAsync(carEditDto);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarGetDto?>> AddCar(CarCreateDto carCreateDto)
        {
            return await _carService.CreateCarAsync(carCreateDto);
        }
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarGetDto?>> DeleteCar(int id)
        {
            return await _carService.DeleteCarAsync(id);
        }


    }
}
