namespace Car_Dealership.Interfaces
{
    public interface IClientService
    {
        Task<ServiceResponse<IEnumerable<ClientGetDto>>> GetClientsAsync();
        Task<ServiceResponse<ClientGetDto?>> GetClientAsync(int id);
        Task<ServiceResponse<ClientGetDto?>> CreateClientAsync(ClientCreateDto clientCreateDto);
        Task<ServiceResponse<ClientGetDto?>> UpdateClientAsync(ClientEditDto ClientEditDto);
        Task<ServiceResponse<ClientGetDto?>> DeleteClientAsync(int id);
    }
}
