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

        public UserRepository(UserApiDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateUserAsync(UserEntity userEntity)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> UpdateUserAsync(UserModel user)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userEntity != null)
            {
                userEntity.UserName = user.UserName;
                userEntity.Telephone = user.Telephone;
                
                await _context.SaveChangesAsync();
            }

            throw new UpdateUserException("Возникли проблемы при изменении...");
        }
    }
}
