using System;
using System.IO;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class FileWriter : IFileWriter
    {
        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}