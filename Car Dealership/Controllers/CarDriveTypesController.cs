namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarDriveTypesController : ControllerBase
    {
        private readonly ICarDriveTypeService _carDriveTypeService;
        public CarDriveTypesController(ICarDriveTypeService carDriveTypeService)
        {

            _carDriveTypeService = carDriveTypeService;

        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CarDriveTypeGetDto>>> GetCarDriveTypes()
        {
            return await _carDriveTypeService.GetCarDriveTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CarDriveTypeGetDto?>> GetCarDriveTypes(int id)
        {
            return await _carDriveTypeService.GetCarDriveTypeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CarDriveTypeGetDto?>> CreateCarDriveTypes(CarDriveTypeCreateDto carDriveTypeCreateDto)
        {
            return await _carDriveTypeService.CreateCarDriveTypeAsync(carDriveTypeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<CarDriveTypeGetDto?>> UpdateCarDriveTypes(CarDriveTypeEditDto carDriveTypeEditDto)
        {
            return await _carDriveTypeService.UpdateCarDriveTypeAsync(carDriveTypeEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CarDriveTypeGetDto?>> DeleteCarDriveTypes(int id)
        {
            return await _carDriveTypeService.DeleteCarDriveTypeAsync(id);
        }
    }
}
