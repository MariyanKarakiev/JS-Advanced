

using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.Routing;

public class Startup
{

    public static async Task Main()
    {
        await new HttpServer(routes => routes
        .MapControllers())
            .Start();
    }
}