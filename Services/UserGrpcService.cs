using Grpc.Core;
using Shop.User.API.Abstractions;
using Shop.User.API.Entities;
using Shop.User.API.Enums;
using Shop.UserRegistrationService;

namespace Shop.User.API.Services
{
    public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        private readonly IUserRepository _userRepository;
        public UserGrpcService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UserReply> CreateUser(UserRequest request, ServerCallContext context)
        {
            var userEntity = new UserEntity
            {
                Id = Guid.Parse(request.Id),
                UserName = request.UserName,
                Email = request.Email,
                Telephone = request.Telephone,
                Password = request.Password,
                Role = (UserRole)Enum.Parse(typeof(UserRole), request.Role, true)
            };

            var userId = await _userRepository.CreateUserAsync(userEntity);

            return await Task.FromResult(new UserReply
            {
                Id = request.Id,
            });
        }
    }
}
