using Shop.User.API.Enums;
using Shop.User.API.Models;

namespace Shop.User.API.Abstractions
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(Guid id, string userName, string email, string telephone, string password, UserRole role);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<Guid> UpdateUserAsync(Guid id, string userName, string telephone);
    }
}