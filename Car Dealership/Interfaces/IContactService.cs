namespace Car_Dealership.Interfaces
{
    public interface IContactService
    {
        Task<ServiceResponse<IEnumerable<ContactGetDto>>> GetContactsAsync();
        Task<ServiceResponse<ContactGetDto?>> GetContactAsync(int id);
        Task<ServiceResponse<ContactGetDto?>> CreateContactAsync(ContactCreateDto contactCreateDto);
        Task<ServiceResponse<ContactGetDto?>> UpdateContactAsync(ContactEditDto contactEditDto);
        Task<ServiceResponse<ContactGetDto?>> DeleteContactAsync(int id);
    }
}
