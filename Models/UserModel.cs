using FluentValidation.Results;
using Shop.User.API.Enums;
using Shop.User.API.Validations;

namespace Shop.User.API.Models
{
    public class UserModel
    {
        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Telephone { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public UserRole Role { get; }

        public UserModel(Guid id, string userName, string telephone)
        {
            Id = id;
            UserName = userName;
            Telephone = telephone;
        }

        public UserModel(Guid id, string userName, string email, string telephone, string password, UserRole role)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Telephone = telephone;
            Password = password;
            Role = role;
        }

        public static(string error, UserModel user) Create(Guid id, string userName, string telephone)
        {
            string error = string.Empty;
            UserModel user = new UserModel(id, userName, telephone);
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(user);
            if(!result.IsValid)
            {
                foreach(var failure in result.Errors)
                {
                    error += failure + "\n";
                }
            }
            return (error, user);
        }

        public static (string error, UserModel user) Create(Guid id, string userName, string email, string telephone, string password, UserRole role)
        {
            string error = string.Empty;
            UserModel user = new UserModel(id, userName, email, telephone, password, role);
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(user);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    error += failure + "\n";
                }
            }
            return (error, user);
        }
    }
}
