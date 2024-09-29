using Shop.User.API.Enums;

namespace Shop.User.API.Models
{
    public class UserModel
    {
        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Telephone { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public UserRole Role { get; }
    }
}
