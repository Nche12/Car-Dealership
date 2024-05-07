namespace Car_Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService) 
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<ContactGetDto>>> GetContactsAsync()
        {
            return await _contactService.GetContactsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<ContactGetDto?>> GetContactAsync(int id)
        {
            return await _contactService.GetContactAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<ContactGetDto?>> CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            return await _contactService.CreateContactAsync(contactCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<ContactGetDto?>> UpdateContactAsync(ContactEditDto contactEditDto)
        {
            return await _contactService.UpdateContactAsync(contactEditDto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<ContactGetDto?>> DeleteContactAsync(int id)
        {
            return await _contactService.DeleteContactAsync(id);
        }

    }
}
