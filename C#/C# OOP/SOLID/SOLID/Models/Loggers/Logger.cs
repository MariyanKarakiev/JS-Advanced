using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] _appenders;

        public Logger(params IAppender[] appenders)
        {
            _appenders = appenders;
        }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in _appenders)
            {
                appender.AppendMessage(dateTime, "Critical", message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in _appenders)
            {
                appender.AppendMessage(dateTime, "Error", message);
            }
        }
        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in _appenders)
            {
                appender.AppendMessage(dateTime, "Fatal", message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in _appenders)
            {
                appender.AppendMessage(dateTime, "Info", message);
            }
        }
    }
}
