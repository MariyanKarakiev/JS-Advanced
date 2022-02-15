

using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

public class Startup
{
    private const string HtmlForm = @"<form action = '/HTML' method='POST'>
Name: <input type='text' name='Name'/>
Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save'/>
</form>";
    private const string DownloadForm = @"<form action='/Content' method='POST'>
<input type='submit' value ='Download Sites Content' />
</form>";
    private const string FileName = "content.txt";
    private const string LoginForm = @"<form action='/Login' method='POST'>
Username: <input type='text' name='Username'/>
Password: <input type='text' name='Password'/>
<input type='submit' value='Log In' />
</form>";
    private const string Username = "user";
    private const string Password = "password";
    public static async Task Main()
    {
        await DownloadSitesAsTextFile(Startup.FileName, new string[]
        { "https://www.facebook.com/", "https://softuni.bg" });

        var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/HTML", new HtmlResponse(Startup.HtmlForm))
            .MapPost("/HTML", new TextResponse("", Startup.AddFormDataAction))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.bg/"))
            .MapGet("/Content", new HtmlResponse(Startup.DownloadForm))
            .MapPost("/Content", new TextFileResponse(Startup.FileName))
            .MapGet("/Cookies", new HtmlResponse("", Startup.AddCookiesAction))
            .MapGet("/Session", new TextResponse("", Startup.DisplaySessionInfoAction))
            .MapGet("/Login", new HtmlResponse(Startup.LoginForm))
            .MapPost("/Login", new HtmlResponse("", Startup.LoginAction))
            .MapGet("/Logout", new HtmlResponse("", Startup.LogoutAction))
            .MapGet("/UserProfile", new HtmlResponse("", Startup.GetUserDataAction)));

        await server.Start();
    }

    private static void GetUserDataAction(Request request, Response response)
    {
        if (request.Session.ContainsKey(Session.SessionUserKey))
        {
            response.Body = "";
            response.Body += $"<h3>Currently logged-in user is with username {Username}</h3>";
        }
        else
        {
            response.Body = "";
            response.Body += $"<h3>You must login first! - <a href='/Login'>Login</a></h3>";
        }
    }

    private static void LogoutAction(Request request, Response response)
    {
        request.Session.Clear();

        response.Body = "";
        response.Body = "<h3>Logged out successfully!</h3>";
    }

    private static void DisplaySessionInfoAction(Request request, Response response)
    {
        var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

        var bodyText = "";

        if (sessionExists)
        {
            var currentDate = request.Session[Session.SessionCurrentDateKey];
            bodyText = $"Stored date: {currentDate}";
        }
        else
        {
            bodyText = "Current date stored!";
        }

        response.Body = "";
        response.Body += bodyText;
    }

    private static void LoginAction(Request request, Response response)
    {
        request.Session.Clear();

        var bodyText = "";

        var usernameMathces = request.Form["Username"] == Startup.Username;
        var passwordMathces = request.Form["Password"] == Startup.Password;

        if (usernameMathces && passwordMathces)
        {
            request.Session[Session.SessionUserKey] = "MyUserId";
            response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

            bodyText = "<h3>Logged successfully!</h3>";
        }
        else
        {
            bodyText = Startup.LoginForm;
        }

        response.Body = "";
        response.Body += bodyText;
    }

    private static void AddCookiesAction(Request request, Response response)
    {
        var requestHasCookie = request.Cookies.Any(c => c.Name != Session.SessionCookieName);
        var bodyText = "";

        if (requestHasCookie)
        {
            var cookieText = new StringBuilder();
            cookieText.AppendLine("<h1>Cookies</h1>");

            cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

            foreach (var cookie in request.Cookies)
            {

                cookieText.Append("<tr>");
                cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                cookieText.Append("</tr>");
            }
            cookieText.AppendLine("</table>");

            bodyText = cookieText.ToString();
        }
        else
        {
            bodyText = "<h1>Cookies set!</h1>";
            response.Cookies.Add("My-Cookie", "My-Value");
            response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
        }

        response.Body = bodyText;
    }
    public static void AddFormDataAction(Request request, Response response)
    {
        response.Body = "";

        foreach (var (key, value) in request.Form)
        {
            response.Body += $"{key} - {value}";
            response.Body += Environment.NewLine;
        }
    }
    private static async Task<string> DownloadWebSiteContent(string url)
    {
        var httpClient = new HttpClient();
        using (httpClient)
        {
            var response = await httpClient.GetAsync(url);

            var html = await response.Content.ReadAsStringAsync();

            return html.Substring(0, 2000);
        }
    }
    private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
    {
        var downloads = new List<Task<string>>();

        foreach (var url in urls)
        {
            downloads.Add(DownloadWebSiteContent(url));
        }

        var responses = Task.WhenAll(downloads).Result;

        var responsesString = string
            .Join(Environment.NewLine + new string('-', 100), responses);

        await File.WriteAllTextAsync(fileName, responsesString);
    }
}