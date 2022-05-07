
using LoggerApp.Interfaces;
using LoggerApp.Models;
using LoggerApp.Models.Appenders;
using LoggerApp.Models.Layouts;
using LoggerApp.Models.Loggers;
using System;

namespace SOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
