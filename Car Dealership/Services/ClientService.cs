namespace Car_Dealership.Services
{
    public class ClientService : IClientService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;

        public ClientService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ClientGetDto?>> CreateClientAsync(ClientCreateDto clientCreateDto)
        {
            var serviceResponse = new ServiceResponse<ClientGetDto?>();
            var client = _mapper.Map<Client>(clientCreateDto);
            var clientFound = await _tenantContext.Clients.FirstOrDefaultAsync(c => c.Email == clientCreateDto.Email);
            if (clientFound == null)
            {
                _tenantContext.Clients.Add(client);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ClientGetDto>(client);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Success = false;
                serviceResponse.Message = $"Client Email '{client.Email}' already exists.";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ClientGetDto?>> DeleteClientAsync(int id)
        {
            var serviceResponse = new ServiceResponse<ClientGetDto?>();
            var client = await _tenantContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                _tenantContext.Clients.Remove(client);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ClientGetDto>(client);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Client not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ClientGetDto>>> GetClientsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ClientGetDto>>();
            var clients = await _tenantContext.Clients.ToArrayAsync();
            serviceResponse.Data = clients.Select(c => _mapper.Map<ClientGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ClientGetDto?>> GetClientAsync(int id)
        {
            var serviceResponse = new ServiceResponse<ClientGetDto?>();
            var client = await _tenantContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                serviceResponse.Data = _mapper.Map<ClientGetDto>(client);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Success = false;
                serviceResponse.Message = "Client not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ClientGetDto?>> UpdateClientAsync(ClientEditDto clientEditDto)
        {
            var serviceResponse = new ServiceResponse<ClientGetDto?>();
            var client = _mapper.Map<Client>(clientEditDto);
            _tenantContext.Entry(client).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ClientGetDto>(client);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ClientExists(client.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found.";
                }
            }

            return serviceResponse;
        }

        public bool ClientExists(int id)
        {
            return _tenantContext.Clients.Any(c => c.Id == id);
        }
    }
}
