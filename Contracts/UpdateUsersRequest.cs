namespace Shop.User.API.Contracts
{
    public record UpdateUsersRequest(
        string UserName,
        string Telephone
        );
}