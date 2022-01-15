using BasicWebServer.Server.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }
        public string Url { get; private set; }
        public HeaderCollection Header { get; private set; }
        public string Body { get; set; }


        public Request Parse(string request)
        {
            var lines = request.Split("\r\n");

            var firstLine = lines.First().Split(' ');

            var method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            HeaderCollection header = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(header.Count+2);

            string body = string.Join("\r\n", bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Header = header,
                Body = body
            };
        }

        public static HeaderCollection ParseHeaders(IEnumerable<string> lines)
        {
            var headers = new HeaderCollection();

            foreach (var line in lines)
            {
                if (line == String.Empty)
                {
                    break;
                }

                var parts = line.Split(':');

                if (parts.Length != 2)
                {
                    throw new InvalidOperationException("Request headers is not valid");
                }
                headers.Add(parts[0], parts[1].Trim());
            }
            return headers;
        }

        public Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
