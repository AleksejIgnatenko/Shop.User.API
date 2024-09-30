namespace Shop.User.API.CustomExceptions
{
    public class UpdateUserException : Exception
    {
        public UpdateUserException(string mess) : base(mess) { }
    }
}
