
namespace Car_Dealership.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly TenantContext _tenantContext;
        public ContactService(IMapper mapper, TenantContext tenantContext)
        {
            _mapper = mapper;
            _tenantContext = tenantContext;
        }
        public async Task<ServiceResponse<ContactGetDto?>> CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            var serviceResponse = new ServiceResponse<ContactGetDto?>();
            var contact = _mapper.Map<Contact>(contactCreateDto);
            var contactFound = await _tenantContext.Contacts.FirstOrDefaultAsync(c => c.DisplayName == contact.DisplayName);
            if (contactFound == null)
            {
                _tenantContext.Contacts.Add(contact);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ContactGetDto>(contact);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                serviceResponse.Message = $"Contact '{contact.DisplayName}' already exists.";
                serviceResponse.Success = false; 
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactGetDto?>> DeleteContactAsync(int id)
        {
            var serviceResponse = new ServiceResponse<ContactGetDto?>();
            var contactFound = await _tenantContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if(contactFound != null)
            {
                _tenantContext.Contacts.Remove(contactFound); 
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ContactGetDto>(contactFound);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Contact not found.";
                serviceResponse.Success= false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactGetDto?>> GetContactAsync(int id)
        {
            var serviceResponse = new ServiceResponse<ContactGetDto?>();
            var contactFound = await _tenantContext.Contacts
                .Include(c => c.BankAccount)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(contactFound != null)
            {
                serviceResponse.Data = _mapper.Map<ContactGetDto>(contactFound);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            } 
            else
            {
                serviceResponse.Data = null;
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                serviceResponse.Message = "Contact not found.";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ContactGetDto>>> GetContactsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<ContactGetDto>>();
            var contacts = await _tenantContext.Contacts
                .Include(c => c.BankAccount)
                .ToArrayAsync();
            serviceResponse.Data = contacts.Select(c => _mapper.Map<ContactGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ContactGetDto?>> UpdateContactAsync(ContactEditDto contactEditDto)
        {
            var serviceResponse = new ServiceResponse<ContactGetDto?>();
            var contact = _mapper.Map<Contact>(contactEditDto);
            _tenantContext.Contacts.Entry(contact).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ContactGetDto>(contact);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!contactExists(contact.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                    serviceResponse.Message = "Contact was not found.";
                }
                else
                {
                    throw;
                }
            }
            return serviceResponse;
        }

        public bool contactExists(int id)
        {
            return _tenantContext.Contacts.Any(c => c.Id == id);
        }
    }
}
