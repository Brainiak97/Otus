using HomeWork.SOLID.Interfaces;

namespace HomeWork.SOLID.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
    }
}
