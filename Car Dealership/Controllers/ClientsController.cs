using Microsoft.AspNetCore.Mvc;

namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<ClientGetDto>>> GetClients()
        {
            return await _clientService.GetClientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<ClientGetDto?>> GetClient(int id)
        {
            return await _clientService.GetClientAsync(id);
        }
        
        [HttpPost]
        public async Task<ServiceResponse<ClientGetDto?>> CreateClient(ClientCreateDto clientCreateDto)
        {
            return await _clientService.CreateClientAsync(clientCreateDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ServiceResponse<ClientGetDto?>> UpdateClient(ClientEditDto clientEditDto)
        {
            return await _clientService.UpdateClientAsync(clientEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<ClientGetDto?>> DeleteClient(int id)
        {
            return await _clientService.DeleteClientAsync(id);
        }


    }
}
