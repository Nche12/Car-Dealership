namespace Car_Dealership.DTOs.BankAccount
{
    public class BankAccountGetDto
    {
        public int Id { get; set; }
        public int? BankId { get; set; }
        public int? ContactId { get; set; }
        public string? BankName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? BankType { get; set; } = string.Empty;
        public string? BankBranchName { get; set; } = string.Empty;
        public string? BankBranchCode { get; set; } = string.Empty;
        public string BankAccountNum { get; set; } = string.Empty;
        public string BankAccountHolder { get; set; } = string.Empty;
        public int? BankAccountTypeId { get; set; }
        public string? BankAccountType { get; set; } = string.Empty;
        public string? BankNotificationEmailAddress { get; set; } = string.Empty;
        public string? BankNotificationEmailSubject { get; set; } = string.Empty;
        public string? BankNotificationSmsCode { get; set; } = string.Empty;
        public string? BankNotificationSmsNumber { get; set; } = string.Empty;
        public string? BankNotificationFaxCode { get; set; } = string.Empty;
        public string? BankNotificationFaxNumber { get; set; } = string.Empty;
        public string PaymentReference { get; set; } = string.Empty;
        public string? EntityNumber { get; set; } = string.Empty;
        public string? Iban { get; set; } = string.Empty;
        public string? SwiftBic { get; set; } = string.Empty;
        public bool? IsPrimary { get; set; } = false;
        public bool? IsSelected { get; set; } = false;
    }
}
