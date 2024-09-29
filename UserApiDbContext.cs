using Microsoft.EntityFrameworkCore;
using Shop.User.API.Entities;

namespace Shop.User.API
{
    public class UserApiDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public UserApiDbContext(DbContextOptions<UserApiDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
