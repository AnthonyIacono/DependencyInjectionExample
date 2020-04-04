using System;
using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class MultiplyCommand : ICommand
    {
        private readonly ICalculator _calculator;

        public MultiplyCommand(ICalculator calculator)
        {
            this._calculator = calculator;
        }
        
        public bool ShouldProcess(string input)
        {
            return input.StartsWith("multiply", StringComparison.InvariantCultureIgnoreCase);
        }

        public void Process(string input)
        {
            var arguments = input.Split(" ", 3);

            if (arguments.Length != 3)
            {
                throw new InvalidOperationException("You must supply a command like: multiply 5 2.5");
            }

            var canParseFirstNumber = double.TryParse(arguments[1], out var firstNumber);
            var canParseSecondNumber = double.TryParse(arguments[2], out var secondNumber);

            if (!canParseFirstNumber || !canParseSecondNumber)
            {
                throw new InvalidCastException("Unable to cast arguments to doubles.");
            }
            
            Console.WriteLine($"Multiplied numbers and result is: {this._calculator.Multiply(firstNumber, secondNumber)}");
        }
    }
}