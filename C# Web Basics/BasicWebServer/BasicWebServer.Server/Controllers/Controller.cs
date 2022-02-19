using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Cookies;
using BasicWebServer.Server.Responses;
using System.Runtime.CompilerServices;

namespace BasicWebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Request Request { get; set; }

        protected Controller(Request request)
        {
            Request = request;
        }

        private string GetControllerName()
            => GetType().Name.Replace(nameof(Controller), string.Empty);

        protected Response Text(string text) => new TextResponse(text);
        protected Response Html(string text) => new HtmlResponse(text);
        protected static Response Html(string html, CookieCollection cookieCollection = null)
        {
            var response = new HtmlResponse(html);

            if (cookieCollection != null)
            {
                foreach (var cookie in cookieCollection)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }
        protected Response BadRequest() => new BadRequestResponse();
        protected Response Unauthorized() => new UnauthorizedResponse();
        protected Response NotFound() => new NotFoundResponse();
        protected Response Redirect(string location) => new RedirectResponse(location);
        protected Response File(string fileName) => new FileResponse(fileName);
        protected Response View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName());
        protected Response View(object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName(), model);


    }
}
