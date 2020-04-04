using System;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class WriteFileCommand : ICommand
    {
        private readonly IFileWriter _fileWriter;

        public WriteFileCommand(IFileWriter fileWriter)
        {
            this._fileWriter = fileWriter;
        }
        
        public bool ShouldProcess(string input)
        {
            return input.StartsWith("write", StringComparison.InvariantCultureIgnoreCase);
        }

        public void Process(string input)
        {
            var arguments = input.Split(" ", 3);

            if (arguments.Length != 3)
            {
                throw new InvalidOperationException("You must supply a command like: write filename.txt some content goes here");
            }

            var fileName = arguments[1];
            var fileContents = arguments[2];

            this._fileWriter.WriteFile(fileName, fileContents);
            
            Console.WriteLine($"Wrote file named {fileName} with contents {fileContents}");
        }
    }
}