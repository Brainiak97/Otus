using System.Diagnostics;
using TaskHomeWork;

Console.WriteLine("Чтение 3 файлов в папке приложения...");

Console.WriteLine("\"Прогрев\" системы...");
await FileReader.GetSpaceFromThreeFilesInAppDirectory(); // просто чтобы всё скомпилировалось и загрузилось
Console.WriteLine("\"Прогрев\" завершён.");

Stopwatch stopwatch = new();
stopwatch.Start();
var spaceCount = await FileReader.GetSpaceFromThreeFilesInAppDirectory();
stopwatch.Stop();

Console.WriteLine($"Общее количество пробелов в 3 файлах = {spaceCount}");
Console.WriteLine($"Затрачено времени (мс): {stopwatch.Elapsed.TotalMilliseconds}");

stopwatch.Reset();

Console.WriteLine("_______________________________________");
Console.WriteLine("Введите путь к папке для чтения файлов: ");
var directoryPath = Console.ReadLine();
Console.WriteLine($"Чтение файлов в папке {directoryPath}...");

if (Directory.Exists(directoryPath))
{
    stopwatch.Start();
    spaceCount = await FileReader.GetSpaceFromAllFilesInSomeDirectory(directoryPath);
    stopwatch.Stop();

    Console.WriteLine($"Общее количество пробелов в файлах указанной папки = {spaceCount}");
    Console.WriteLine($"Затрачено времени (мс): {stopwatch.Elapsed.TotalMilliseconds}");

    stopwatch.Reset();
}
else
{
    Console.WriteLine($"Введенный путь не найден\n{directoryPath}");
}