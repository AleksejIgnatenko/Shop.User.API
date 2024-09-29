using Shop.User.API.Abstractions;
using Shop.User.API.Entities;

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
            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return userEntity.Id;
        }
    }
}
