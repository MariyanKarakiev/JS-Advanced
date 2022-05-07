using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models
{
    public class SimpleLayout : ILayout
    {
        private const string simpleLayout = "{0} - {1} - {2}";

        public string Template => simpleLayout;
    }
}
