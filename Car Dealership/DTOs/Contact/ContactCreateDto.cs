namespace Car_Dealership.DTOs.Contact
{
    public class ContactCreateDto
    {
        public string? Forenames { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? residentialAddress { get; set; } = string.Empty;
        public string? postalAddress { get; set; } = string.Empty;
        public string? IdNumber { get; set; } = string.Empty;
        public string TelMobile { get; set; } = string.Empty;
        public string? TelWork { get; set; } = string.Empty;
        public string? TelHome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsCompany { get; set; } = false;
        public string? Company { get; set; } = string.Empty;
        public string? CompanyRegNum { get; set; } = string.Empty;
        public string? CompanyVatNum { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? ImageFilename { get; set; } = string.Empty;
        public string? Comments { get; set; } = string.Empty;
        public string? Website { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
