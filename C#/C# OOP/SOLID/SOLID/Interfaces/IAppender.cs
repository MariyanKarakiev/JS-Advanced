using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Interfaces
{
    public interface IAppender
    {
        void AppendMessage(string dateTime, string reportLevel, string message);
    }
}
