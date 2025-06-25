using HomeWork.SOLID.Interfaces;

namespace HomeWork.SOLID.Services
{
    public class ConsoleInputService : IInputService
    {
        public string ReadLine() => Console.ReadLine() ?? "";
        public int ReadInt() => int.TryParse(Console.ReadLine(), out var result) ? result : 0;
    }
}
