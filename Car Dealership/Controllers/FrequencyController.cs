namespace Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        private readonly IFrequencyService _frequencyService;
        public FrequencyController(IFrequencyService frequencyService)
        {
            _frequencyService = frequencyService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<FrequencyGetDto>>> GetFrequencies()
        {
            return await _frequencyService.GetFrequenciesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<FrequencyGetDto?>> GetFrequency(int frequencyId)
        {
            return await _frequencyService.GetFrequencyAsync(frequencyId);
        }

        [HttpPost]
        public async Task<ServiceResponse<FrequencyGetDto?>> CreateFrequency(FrequencyCreateDto frequencyCreateDto)
        {
            return await _frequencyService.CreateFrequencyAsync(frequencyCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<FrequencyGetDto?>> UpdateFrequency(FrequencyEditDto frequencyEditDto)
        {
            return await _frequencyService.UpdateFrequencyAsync(frequencyEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<FrequencyGetDto?>> DeleteFrequency(int frequencyId)
        {
            return await _frequencyService.DeleteFrequencyAsync(frequencyId);
        }
    }
}
