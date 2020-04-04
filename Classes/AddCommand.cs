using System;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class AddCommand : ICommand
    {
        private readonly ICalculator _calculator;

        public AddCommand(ICalculator calculator)
        {
            this._calculator = calculator;
        }
        
        public bool ShouldProcess(string input)
        {
            return input.StartsWith("add", StringComparison.InvariantCultureIgnoreCase);
        }

        public void Process(string input)
        {
            var arguments = input.Split(" ", 3);

            if (arguments.Length != 3)
            {
                throw new InvalidOperationException("You must supply a command like: add 5 2.5");
            }

            var canParseFirstNumber = double.TryParse(arguments[1], out var firstNumber);
            var canParseSecondNumber = double.TryParse(arguments[2], out var secondNumber);

            if (!canParseFirstNumber || !canParseSecondNumber)
            {
                throw new InvalidCastException("Unable to cast arguments to doubles.");
            }
            
            Console.WriteLine($"Added numbers and sum is: {this._calculator.Add(firstNumber, secondNumber)}");
        }
    }
}