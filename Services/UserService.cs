using Shop.User.API.Abstractions;
using Shop.User.API.CustomExceptions;
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
