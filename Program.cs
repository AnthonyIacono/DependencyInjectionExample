using System;
using DependencyInjectionExample.Classes;
using DependencyInjectionExample.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ICalculator, Calculator>();
            serviceCollection.AddScoped<ICommand, AddCommand>();
            serviceCollection.AddScoped<ICommand, MultiplyCommand>();
            serviceCollection.AddScoped<ICommand, WriteFileCommand>();
            serviceCollection.AddScoped<ICommandProcessor, CommandProcessor>();
            serviceCollection.AddScoped<IFileWriter, FileWriter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var processor = serviceProvider.GetRequiredService<ICommandProcessor>();

            var input = string.Empty;
            
            while (input != "exit")
            {
                Console.WriteLine("Please input a command.");
                
                input = Console.ReadLine();

                try
                {
                    processor.Process(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}