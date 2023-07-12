namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarColoursController : ControllerBase
    {
        private readonly ICarColourService _carColourService;
        public CarColoursController(ICarColourService carColourService)
        {
            _carColourService = carColourService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarColourGetDto>>> GetCarColours()
        {
            return await _carColourService.GetColoursAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarColourGetDto?>> GetCarColour(int id)
        {
            return await _carColourService.GetColourAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarColourGetDto?>> CreateCarColour(CarColourCreateDto carColourCreateDto)
        {
            return await _carColourService.CreateColourAsync(carColourCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarColourGetDto?>> UpdateCarColour(CarColourEditDto carColourEditDto)
        {
            return await _carColourService.UpdateColourAsync(carColourEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarColourGetDto?>> DeleteCarColour(int id)
        {
            return await _carColourService.DeleteColourAsync(id);
        }
    }
}
