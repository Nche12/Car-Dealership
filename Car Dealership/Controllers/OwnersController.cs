namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<OwnerGetDto>>> GetOwners()
        {
            return await _ownerService.GetOwnersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<OwnerGetDto?>> GetOwner(int id)
        {
            return await _ownerService.GetOwnerAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<OwnerGetDto?>> CreateOwner(OwnerCreateDto ownerCreateDto)
        {
            return await _ownerService.CreateOwnerAsync(ownerCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<OwnerGetDto?>> UpdateOwner(OwnerEditDto ownerEditDto)
        {
            return await _ownerService.UpdateOwnerAsync(ownerEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<OwnerGetDto?>> DeleteOwner(int id)
        {
            return await _ownerService.DeleteOwnerAsync(id);
        }
    }
}
