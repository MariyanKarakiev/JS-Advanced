using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAddress, int _port, Action<IRoutingTable> routingTableConfig)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
            serverListener = new TcpListener(ipAddress, port);
            routingTableConfig(routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8082, routingTable)
        {
        }

        public async Task Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                TcpClient connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {

                    NetworkStream networkStream = connection.GetStream();

                    string requestText = await ReadRequest(networkStream);

                    Console.WriteLine(requestText);

                    var request = Request.Parse(requestText);

                    var response = routingTable.MatchRequest(request);

                    if (response.PreRenderAction != null)
                    {
                        response.PreRenderAction(request, response);
                    }

                    AddSession(request, response);

                    await WriteResponse(networkStream, response);

                    connection.Close();
                });
            }
        }

        private void AddSession(Request request, Response response)
        {
            var sessionExist = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExist)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();

                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }
        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            if (response.FileContent != null)
            {
                responseBytes = responseBytes
                    .Concat(response.FileContent)
                    .ToArray();
            }
            await networkStream.WriteAsync(responseBytes);

        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesToRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesToRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesToRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();

        }
    }
}