
namespace Car_Dealership.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IMapper _mapper;
        private readonly TenantContext _tenantContext;
        public BankAccountService(IMapper mapper, TenantContext tenantContext) 
        {
            _mapper = mapper;
            _tenantContext = tenantContext;
        }
        public async Task<ServiceResponse<BankAccountGetDto?>> CreateBankAccountAsync(BankAccountCreateDto bankAccountCreateDto)
        {
            var serviceResponse = new ServiceResponse<BankAccountGetDto?>();
            var bankAccount = _mapper.Map<BankAccount>(bankAccountCreateDto);  
            var bankAccountFound = await _tenantContext.BankAccounts.FirstOrDefaultAsync(ba => ba.BankAccountNum == bankAccountCreateDto.BankAccountNum);
            if (bankAccountFound == null)
            {
                _tenantContext.BankAccounts.Add(bankAccount);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<BankAccountGetDto>(bankAccount);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Bank Account Number '{bankAccount.BankAccountNum}', already exists";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<BankAccountGetDto?>> DeleteBankAccountAsync(int id)
        {
            var serviceResponse = new ServiceResponse<BankAccountGetDto?>();
            var bankAccountFound = await _tenantContext.BankAccounts.FirstOrDefaultAsync(ba => ba.Id  == id);
            if (bankAccountFound != null)
            {
                _tenantContext.BankAccounts.Remove(bankAccountFound);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<BankAccountGetDto>(bankAccountFound);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data= null;
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Bank Account was not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<BankAccountGetDto?>> GetBankAccountAsync(int id)
        {
            var serviceResponse = new ServiceResponse<BankAccountGetDto?>();
            var bankAccount = await _tenantContext.BankAccounts.FirstOrDefaultAsync(ba => ba.Id == id);
            if (bankAccount != null)
            {
                serviceResponse.Data = _mapper.Map<BankAccountGetDto>(bankAccount);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;    
                serviceResponse.Success = false;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Bank Account was not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<BankAccountGetDto>>> GetBankAccountsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<BankAccountGetDto>>();
            var bankAccounts = await _tenantContext.BankAccounts.ToArrayAsync();
            serviceResponse.Data = bankAccounts.Select(ba => _mapper.Map<BankAccountGetDto>(ba)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<BankAccountGetDto?>> UpdateBankAccountAsync(BankAccountEditDto bankAccountEditDto)
        {
            var serviceResponse = new ServiceResponse<BankAccountGetDto?>();
            var bankAccount = _mapper.Map<BankAccount>(bankAccountEditDto);
            _tenantContext.BankAccounts.Entry(bankAccount).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<BankAccountGetDto>(bankAccount);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bankAccountExists(bankAccount.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = "Bank Account not found.";
                }
            }
            return serviceResponse;
        }

        public bool bankAccountExists(int bankAccountId)
        {
            return _tenantContext.BankAccounts.Any(ba => ba.Id == bankAccountId);
        }
    }
}
