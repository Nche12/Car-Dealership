namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransmissionTypesController : ControllerBase
    {
        private readonly ITransmissionTypeService _transmissionTypeService;
        public TransmissionTypesController(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<TransmissionTypeGetDto>>> GetTransmissionTypes()
        {
            return await _transmissionTypeService.GetTransmissionTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<TransmissionTypeGetDto?>> GetTransmissionType(int id)
        {
            return await _transmissionTypeService.GetTransmissionTypeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<TransmissionTypeGetDto?>> CreateTransmissionType(TransmissionTypeCreateDto transmissionTypeCreateDto)
        {
            return await _transmissionTypeService.AddTransmissionTypeAsync(transmissionTypeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<TransmissionTypeGetDto?>> UpdateTransmissionType(TransmissionTypeEditDto transmissionTypeEditDto)
        {
            return await _transmissionTypeService.UpdateTransmissionTypeAsync(transmissionTypeEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<TransmissionTypeGetDto?>> DeleteTransmissionType(int id)
        {
            return await _transmissionTypeService.DeleteTransmissionTypeAsync(id);
        }
    }
}
