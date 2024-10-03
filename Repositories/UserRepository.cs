using Microsoft.EntityFrameworkCore;
using Shop.User.API.Abstractions;
using Shop.User.API.CustomExceptions;
using Shop.User.API.Entities;
using Shop.User.API.Models;

namespace Shop.User.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserApiDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserApiDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreateUserAsync(UserModel userModel)
        {
            var userEntity = new UserEntity
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email,
                Telephone = userModel.Telephone,
                Password = userModel.Password,
                Role = userModel.Role,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var userEntities = await _context.Users.ToListAsync();
            if (userEntities.Any())
            {
                var users = userEntities.Select(u => UserModel.Create(
                    u.Id, 
                    u.UserName, 
                    u.Email, 
                    u.Telephone, 
                    u.Password, 
                    u.Role).user).ToList();
                return users;
            }

            _logger.LogError("Failed to get users");
            throw new UserException("Failed to get users");
        }

        public async Task<Guid> UpdateUserAsync(UserModel user)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userEntity != null)
            {
                userEntity.UserName = user.UserName;
                userEntity.Telephone = user.Telephone;
                
                await _context.SaveChangesAsync();
                return userEntity.Id;
            }

            _logger.LogError("There were problems changing...");
            throw new UserException("There were problems changing...");
        }
    }
}
