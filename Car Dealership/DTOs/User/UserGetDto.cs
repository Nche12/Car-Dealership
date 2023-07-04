namespace Car_Dealership.DTOs.User
{
    public class UserGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty.ToString();

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int UserRoleId { get; set; }

        public UserRole? UserRole { get; set; }
    }
}
