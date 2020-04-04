using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Classes
{
    public class Calculator : ICalculator
    {
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}