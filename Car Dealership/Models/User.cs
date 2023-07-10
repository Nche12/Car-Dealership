namespace Car_Dealership.Models
{
    public class User : Auditable
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty.ToString();

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int UserRoleId { get; set; } 

        public UserRole? UserRole { get; set; } 

        public ICollection<User>? UsersAdded { get; set; }
        public ICollection<User>? UsersDeleted { get; set; }

        public ICollection<UserRole>? UserRolesAdded { get; set; }
        public ICollection<UserRole>? UserRolesDeleted { get; set; }
    }
}
