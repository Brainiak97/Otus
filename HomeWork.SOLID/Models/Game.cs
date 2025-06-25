using HomeWork.SOLID.Interfaces;

namespace HomeWork.SOLID.Models
{
    public class Game(IInputService input, IOutputService output, GameSettings settings)
    {
        private readonly IInputService _input = input;
        private readonly IOutputService _output = output;
        private readonly GameSettings _settings = settings;

        public void Start()
        {
            var random = new Random();
            int secretNumber = random.Next(_settings.MinValue, _settings.MaxValue + 1);

            _output.WriteLine("Игра началась! Попробуйте угадать число.");

            for (int i = 0; i < _settings.Attempts; i++)
            {
                _output.Write($"Попытка {i + 1}. Введите число: ");
                int userNumber = _input.ReadInt();

                if (userNumber == secretNumber)
                {
                    _output.WriteLine("Вы угадали!");
                    return;
                }
                else if (userNumber < secretNumber)
                {
                    _output.WriteLine("Загаданное число больше.");
                }
                else
                {
                    _output.WriteLine("Загаданное число меньше.");
                }
            }

            _output.WriteLine($"Вы проиграли. Загаданное число было: {secretNumber}");
        }
    }
}
