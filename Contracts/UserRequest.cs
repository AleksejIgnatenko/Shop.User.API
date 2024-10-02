using Shop.User.API.Enums;

namespace Shop.User.API.Contracts
{
    public record UserRequest(
        Guid Id,
        string UserName,
        string Email,
        string Telephone,
        string Password,
        UserRole Role
        );
}
