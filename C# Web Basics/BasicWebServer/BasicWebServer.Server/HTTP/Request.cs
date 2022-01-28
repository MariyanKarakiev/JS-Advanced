﻿using BasicWebServer.Server.HTTP.Enums;
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
        public HeaderCollection Headers { get; private set; }
        public string Body { get; private set; }


        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");

            var firstLine = lines.First().Split(' ');

            var method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2);

            string body = string.Join("\r\n", bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
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

                var parts = line.Split(':', 2);

                if (parts.Length != 2)
                {
                    throw new InvalidOperationException("Request headers is not valid");
                }
                headers.Add(parts[0], parts[1].Trim());
            }
            return headers;
        }

        public static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
