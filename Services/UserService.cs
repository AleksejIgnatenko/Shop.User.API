using Shop.User.API.Abstractions;
using Shop.User.API.CustomExceptions;
using Shop.User.API.Enums;
using Shop.User.API.Models;

namespace Shop.User.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUserAsync(Guid id, string userName, string email, string telephone, string password, UserRole role)
        {
            var (error, user) = UserModel.Create(id, userName, email, telephone, password, role);
            if (string.IsNullOrEmpty(error))
            {
                await _userRepository.CreateUserAsync(user);
                return user.Id;
            }

            throw new ValidatorException(error);
        }

        public async Task<Guid> UpdateUserAsync(Guid id, string userName, string telephone)
        {
            var (error, user) = UserModel.Create(id, userName, telephone);
            if (string.IsNullOrEmpty(error))
            {
                await _userRepository.UpdateUserAsync(user);
                return user.Id;
            }

            throw new ValidatorException(error);
        }
    }
}
