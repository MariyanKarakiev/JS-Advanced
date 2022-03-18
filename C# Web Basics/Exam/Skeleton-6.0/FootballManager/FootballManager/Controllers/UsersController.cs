using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Services;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        public IUserService userService;
        public UsersController(
            Request request,
            IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Login() => View();
        public Response Register() => View();

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            (bool isValid, string userId) = userService.ValidateLogin(model);

            if (isValid)
            {
                SignIn(userId);
                CookieCollection cookies = new CookieCollection();

                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/Players/All");
            }

            return View(new List<ErrorViewModel>() { new ErrorViewModel("Login information is incorrect") }, "/Error");
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool IsValid, IEnumerable<ErrorViewModel> errors) = userService.ValidateModel(model);

            if (!IsValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }

    }
}

