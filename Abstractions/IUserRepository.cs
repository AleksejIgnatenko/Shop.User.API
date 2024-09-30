using Shop.User.API.Entities;
using Shop.User.API.Models;

namespace Shop.User.API.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(UserEntity userEntity);
        Task<Guid> UpdateUserAsync(UserModel user);
    }
}