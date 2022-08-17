using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Cookies;

namespace BasicWebServer.Server.Controllers
{
    public class UserController : Controller
    {
        private const string Username = "user";
        private const string Password = "password";
        public UserController(Request request) : base(request)
        {
        }

        public Response Login() => View();
        public Response LogInUser()
        {
            Request.Session.Clear();

            var usernameMathces = Request.Form["Username"] == UserController.Username;
            var passwordMathces = Request.Form["Password"] == UserController.Password;

            if (usernameMathces && passwordMathces)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();

                    cookies.Add(Session.SessionCookieName, Request.Session.Id);

                    return Html("<h3>Logged successfully!</h3>", cookies);
                }
                return Html("<h3>Logged successfully!</h3>");
            }
            return Redirect("/Login");
        }
        public Response Logout()
        {
            Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }
        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is with username {Username}</h3>");

            }

            return Redirect("/Login");
            //  return Html($"<h3>You must login first! - <a href='/Login'>Login</a></h3>");
        }
    }
}

