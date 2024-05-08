namespace Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountsController(IBankAccountService banKAccoutsService) 
        {
            _bankAccountService = banKAccoutsService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<BankAccountGetDto>>> GetBankAccountsAsync()
        {
            return await _bankAccountService.GetBankAccountsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<BankAccountGetDto?>> GetBankAccountAsync(int id)
        {
            return await _bankAccountService.GetBankAccountAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<BankAccountGetDto?>> CreateBankAccountAsync(BankAccountCreateDto bankAccountCreateDto)
        {
            return await _bankAccountService.CreateBankAccountAsync(bankAccountCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<BankAccountGetDto?>> UpdateBankAccountAsync(BankAccountEditDto bankAccountEditDto)
        {
            return await _bankAccountService.UpdateBankAccountAsync(bankAccountEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<BankAccountGetDto?>> DeleteBankAccount(int id)
        {
            return await _bankAccountService.DeleteBankAccountAsync(id);
        }
        
    }
}
