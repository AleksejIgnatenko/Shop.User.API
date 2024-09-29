using Shop.User.API.Entities;

namespace Shop.User.API.Abstractions
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(UserEntity userEntity);
    }
}