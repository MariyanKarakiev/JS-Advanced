using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerApp.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private readonly ILayout _layout;
        private readonly IFile _logFile;

        public FileAppender(ILayout layout, IFile logFile)
        {
            _layout = layout;
            _logFile = logFile;
        }

        public void AppendMessage(string dateTime, string reportLevel, string message)
        {
           _logFile.Write(string.Format(_layout.Template, dateTime, reportLevel,message));
        }
    }
}
