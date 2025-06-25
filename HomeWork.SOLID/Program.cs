using HomeWork.SOLID.Interfaces;
using HomeWork.SOLID.Models;
using HomeWork.SOLID.Services;

static void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("=== Меню ===");
    Console.WriteLine("1. Начать игру");
    Console.WriteLine("2. Изменить настройки");
    Console.WriteLine("3. Выход");
    Console.Write("Выберите пункт меню: ");
}

static void RunGame(GameSettings settings, IInputService input, IOutputService output)
{
    output.WriteLine("=== Текущие настройки ===");
    output.WriteLine($"Минимальное значение: {settings.MinValue}");
    output.WriteLine($"Максимальное значение: {settings.MaxValue}");
    output.WriteLine($"Количество попыток: {settings.Attempts}\n");

    var game = new Game(input, output, settings);
    game.Start();

    output.WriteLine("Нажмите любую клавишу для продолжения...");
    Console.ReadKey();
}

static void EditSettings(ISettingsService settingsService, IInputService input, IOutputService output)
{
    output.WriteLine("=== Редактирование настроек ===");

    var settings = new GameSettings();

    output.Write($"Введите минимальное значение (текущее: {settings.MinValue}): ");
    settings.MinValue = input.ReadInt();

    output.Write($"Введите максимальное значение (текущее: {settings.MaxValue}): ");
    settings.MaxValue = input.ReadInt();

    output.Write($"Введите количество попыток (текущее: {settings.Attempts}): ");
    settings.Attempts = input.ReadInt();

    settingsService.SaveSettings(settings);
    output.WriteLine("Настройки сохранены! Нажмите любую клавишу для продолжения...");
    Console.ReadKey();
}

string configPath = "appsettings.json";
var input = new ConsoleInputService();
var output = new ConsoleOutputService();
var settingsService = new JsonSettingsService(configPath);

bool exit = false;

while (!exit)
{
    ShowMenu();
    string choice = input.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();

            RunGame(settingsService.LoadSettings(), input, output);
            break;

        case "2":
            Console.Clear();

            EditSettings(settingsService, input, output);
            break;

        case "3":
            exit = true;
            output.WriteLine("Выход из программы...");
            break;

        default:
            output.WriteLine("Неверный выбор. Попробуйте снова.");
            Console.ReadKey();
            break;
    }
}