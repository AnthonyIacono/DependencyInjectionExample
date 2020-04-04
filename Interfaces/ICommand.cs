namespace DependencyInjectionExample.Interfaces
{
    public interface ICommand
    {
        bool ShouldProcess(string input);

        void Process(string input);
    }
}