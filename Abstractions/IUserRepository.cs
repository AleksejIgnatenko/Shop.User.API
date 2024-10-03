using Shop.User.API.Entities;
using Shop.User.API.Models;

namespace Shop.User.API.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(UserModel userModel);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<Guid> UpdateUserAsync(UserModel user);
    }
}