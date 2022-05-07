using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Interfaces
{
    public interface IFile
    {
        int Size { get; }
        void Write(string message);
    }
}
