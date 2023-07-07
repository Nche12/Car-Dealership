namespace Car_Dealership.Models
{
    public class UserRole : Auditable
    {
        public int Id { get; set; }

        public string? Role { get; set; }
    }
}
