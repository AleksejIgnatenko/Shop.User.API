namespace Shop.User.API.Abstractions
{
    public interface IUserService
    {
        Task<Guid> UpdateUserAsync(Guid id, string userName, string telephone);
    }
}