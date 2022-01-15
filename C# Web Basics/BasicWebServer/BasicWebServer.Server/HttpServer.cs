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

        public HttpServer(string _ipAddress,int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
            serverListener = new TcpListener(ipAddress,port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                NetworkStream networkStream = connection.GetStream();

                WriteResponse(networkStream);

                connection.Close();
            }
        }

        private static void WriteResponse(NetworkStream networkStream)
        {
            var content = "Hello from the server!";
            int contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);
        }

    }
}