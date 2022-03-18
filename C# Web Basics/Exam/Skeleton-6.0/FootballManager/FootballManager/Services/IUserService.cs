using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IUserService
    {
        User GetUserByName(UserWithName model);
        void RegisterUser(RegisterViewModel model);
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
        (bool isValid, string userid) ValidateLogin(LoginViewModel model);
    }
}
