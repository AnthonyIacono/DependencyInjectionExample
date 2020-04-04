using System;
using System.Collections.Generic;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IEnumerable<ICommand> _commands;

        public CommandProcessor(IEnumerable<ICommand> commands)
        {
            this._commands = commands;
        }

        public void Process(string input)
        {
            foreach (var command in this._commands)
            {
                if (!command.ShouldProcess(input))
                {
                    continue;
                }
                
                command.Process(input);
                return;
            }
            
            Console.WriteLine($"Invalid command specified: {input}");
        }
    }
}