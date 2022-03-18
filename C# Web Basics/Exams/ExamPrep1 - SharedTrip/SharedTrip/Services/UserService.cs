using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }
        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = GetUserByUserName(model.UserName) != null;

            if (userExists)
            {
                throw new ArgumentException("Registration failed");
            }

            User user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = PasswordHash(model.Password)
            };

            repo.Add<User>(user);
            repo.SaveChanges();
        }
        private object GetUserByUserName(string userName)
        {
            return repo.All<User>().FirstOrDefault(u => u.UserName == userName);
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
        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;

            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.UserName == null ||
                model.UserName.Length < 5 ||
                model.UserName.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is required and must be between 5 and 20 chars."));
            }

            if (model.Email == null)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                    model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is required and must be between 6 and 20 chars."));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Passwords does not match"));
            }

            return (isValid, errors);
        }
        public (string userId, bool IsCorrect) IsLoginCorrect(LoginViewModel model)
        {

            bool isCorrect = false;
            string userId = string.Empty;

            var user = repo.All<User>()
                .FirstOrDefault(u => u.UserName == model.Username);

            if (user != null)
            {
                isCorrect = user.Password == PasswordHash(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }
    }
}
