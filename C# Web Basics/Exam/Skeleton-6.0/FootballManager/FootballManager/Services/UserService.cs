using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public static string PasswordHash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        public User GetUserByName(UserWithName model)
        {
            return repo.All<User>().FirstOrDefault(u => u.Username == model.Username);
        }
        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = GetUserByName(model) != null;

            if (userExists)
            {
                throw new ArgumentException("Registration failed - User already exists");
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = PasswordHash(model.Password)
            };


            repo.Add<User>(user);
            repo.SaveChanges();
        }
        public (bool isValid, string userid) ValidateLogin(LoginViewModel model)
        {
            var isValid = true;
            string userId = string.Empty;

            var user = GetUserByName(model);

            if (user != null)
            {
                isValid = user.Password == PasswordHash(model.Password);
            }

            if (isValid)
            {
                userId = user.Id;
            }

            return (isValid, userId);
        }
        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            var isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is required and must be between 5 and 20 characters long."));
            }

            if (model.Email == null ||
                model.Email.Length < 10 ||
                model.Email.Length > 60)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required and must be between 10 and 60 characters long."));
            }

            if (model.Password == null ||
                model.Password.Length < 5 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is required and must be between 5 and 20 characters long."));
            }

            return (isValid, errors);
        }
    }
}

