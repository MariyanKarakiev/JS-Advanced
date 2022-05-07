using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        private const string template =@"<log>
   <date>{0}</date>
   <level>{1}</level>
   <message>{2}</message>
</log>";

        public string Template => template;
    }
}
