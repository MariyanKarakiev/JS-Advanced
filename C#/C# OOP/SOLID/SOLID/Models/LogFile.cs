using LoggerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerApp.Models
{
    public class LogFile : IFile
    {
        private StringBuilder messageToWrite;
        private const string FilePath = "../../../log.txt";

        public LogFile()
        {
            messageToWrite = new StringBuilder();
        }

        public string AllText => messageToWrite.ToString();
        public int Size => AllText.Where(char.IsLetter).Sum(c => c);

        public void Write(string error)
        {
            messageToWrite.AppendLine(error);
            File.WriteAllText(FilePath, AllText);
        }


    }
}
