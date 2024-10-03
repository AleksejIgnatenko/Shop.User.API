using Shop.User.API.Abstractions;
using Shop.User.API.Controllers;
using Shop.User.API.CustomExceptions;
using Shop.User.API.Entities;
using Shop.User.API.Enums;
using Shop.User.API.Models;

namespace Shop.User.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Guid> CreateUserAsync(Guid id, string userName, string email, string telephone, string password, UserRole role)
        {
            var (error, user) = UserModel.Create(id, userName, email, telephone, password, role);
            Console.WriteLine(user.UserName);
            Console.WriteLine(error);
            if (string.IsNullOrEmpty(error))
            {
                await _userRepository.CreateUserAsync(user);
                return user.Id;
            }

            _logger.LogError(error);
            throw new ValidatorException(error);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Guid> UpdateUserAsync(Guid id, string userName, string telephone)
        {
            var (error, user) = UserModel.Create(id, userName, telephone);
            if (string.IsNullOrEmpty(error))
            {
                await _userRepository.UpdateUserAsync(user);
                return user.Id;
            }

            _logger.LogError(error);
            throw new ValidatorException(error);
        }
    }
}
