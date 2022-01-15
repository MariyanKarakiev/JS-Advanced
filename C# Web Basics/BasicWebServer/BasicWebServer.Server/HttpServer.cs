using BasicWebServer.Server.HTTP;
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

        public HttpServer(string _ipAddress, int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
            serverListener = new TcpListener(ipAddress, port);
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

                var request = new Request();

                request = request.Parse(ReadRequest(networkStream));
                
                Console.WriteLine(ReadRequest(networkStream));
                Console.WriteLine(request.Method);
              

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

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesToRead = networkStream.Read(buffer, 0, bufferLength);

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