using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        public void RegisterUser(RegisterViewModel model);
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
        (string userId, bool IsCorrect) IsLoginCorrect(LoginViewModel model);

    }
}
