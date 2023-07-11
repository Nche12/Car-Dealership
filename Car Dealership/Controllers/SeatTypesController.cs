namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatTypesController : ControllerBase
    {
        private readonly ISeatTypeService _seatTypeService;
        public SeatTypesController(ISeatTypeService seatTypeService)
        {
            _seatTypeService = seatTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<SeatTypeGetDto>>> GetSeatTypes()
        {
            return await _seatTypeService.GetSeatTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<SeatTypeGetDto?>> GetSeatType(int id)
        {
            return await _seatTypeService.GetSeatTypeAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<SeatTypeGetDto?>> CreateSeatType(SeatTypeCreateDto SeatTypeCreateDto)
        {
            return await _seatTypeService.CreateSeatTypeAsync(SeatTypeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<SeatTypeGetDto?>> UpdateSeatType(SeatTypeEditDto SeatTypeEditDto)
        {
            return await _seatTypeService.UpdateSeatTypeAsync(SeatTypeEditDto);
        }

        [HttpDelete("{id}")]//if deleted, can not be created again because the Name fiesld is unique??
        public async Task<ServiceResponse<SeatTypeGetDto?>> DeleteSeatType(int id)
        {
            return await _seatTypeService.DeleteSeatTypeAsync(id);
        }
    }
}
