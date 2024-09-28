using Grpc.Core;
using Shop.UserRegistrationService;

namespace Shop.User.API.Services
{
    public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        public override Task<UserReply> CreateUser(UserRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.Id);
            Console.WriteLine(request.UserName);
            return Task.FromResult(new UserReply
            {
                Id = request.Id,
            });
        }
    }
}
