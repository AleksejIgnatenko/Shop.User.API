namespace Shop.User.API.CustomExceptions
{
    public class UserException : Exception
    {
        public UserException(string mess) : base(mess) { }
    }
}
