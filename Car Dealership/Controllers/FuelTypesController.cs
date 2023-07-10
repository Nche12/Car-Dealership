namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuelTypesController : ControllerBase
    {
        private readonly IFuelTypeService _fuelTypeService;
        public FuelTypesController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<FuelTypeGetDto>>> GetFuelTypes()
        {
            return await _fuelTypeService.GetFuelTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<FuelTypeGetDto?>> GetFuelType(int id)
        {
            return await _fuelTypeService.GetFuelTypeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<FuelTypeGetDto?>> CreateFuelType(FuelTypeCreateDto fuelTypeCreateDto)
        {
            return await _fuelTypeService.CreateFuelTypeAsync(fuelTypeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<FuelTypeGetDto?>> UpdateFuelType(FuelTypeEditDto fuelTypeEditDto)
        {
            return await _fuelTypeService.UpdateFuelTypeAsync(fuelTypeEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<FuelTypeGetDto?>> UpdateFuelType(int id)
        {
            return await _fuelTypeService.DeleteFuelTypeAsync(id);
        }
    }
}
