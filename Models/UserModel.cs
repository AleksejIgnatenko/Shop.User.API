using Shop.User.API.Enum;

namespace Shop.User.API.Models
{
    public class UserModel
    {
        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public UserRole Role { get; }
    }
}
