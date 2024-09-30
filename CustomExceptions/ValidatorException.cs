namespace Shop.User.API.CustomExceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException(string mess) : base(mess) { }
    }
}
