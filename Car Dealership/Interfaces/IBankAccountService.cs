namespace Car_Dealership.Interfaces
{
    public interface IBankAccountService
    {
        Task<ServiceResponse<IEnumerable<BankAccountGetDto>>> GetBankAccountsAsync();
        Task<ServiceResponse<BankAccountGetDto?>> GetBankAccountAsync(int id);
        Task<ServiceResponse<BankAccountGetDto?>> CreateBankAccountAsync(BankAccountCreateDto bankAccountCreateDto);
        Task<ServiceResponse<BankAccountGetDto?>> UpdateBankAccountAsync(BankAccountEditDto BankAccountEditDto);
        Task<ServiceResponse<BankAccountGetDto?>> DeleteBankAccountAsync(int id);
    }
}
