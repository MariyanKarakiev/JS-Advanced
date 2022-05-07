using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        public void AppendMessage(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(string.Format(_layout.Template,dateTime,reportLevel,message));
        }
}
}
