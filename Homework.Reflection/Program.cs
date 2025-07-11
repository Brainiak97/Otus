using Homework.Reflection;
using Newtonsoft.Json;
using System.Diagnostics;

int iterations = 100_000;
var instance = F.Get();

// Прогрев
for (int i = 0; i < 100; i++)
{
    string s = Serializer.Serialize(instance);
    Serializer.Deserialize<F>(s);
}

// Рефлексия
long reflectionSerializeTime = 0;
long reflectionDeserializeTime = 0;

for (int i = 0; i < iterations; i++)
{
    var watch = Stopwatch.StartNew();
    string serialized = Serializer.Serialize(instance);
    watch.Stop();
    reflectionSerializeTime += watch.ElapsedMilliseconds;

    watch.Restart();
    Serializer.Deserialize<F>(serialized);
    watch.Stop();
    reflectionDeserializeTime += watch.ElapsedMilliseconds;
}

// Newtonsoft.Json
long jsonSerializeTime = 0;
long jsonDeserializeTime = 0;

for (int i = 0; i < iterations; i++)
{
    var watch = Stopwatch.StartNew();
    string serialized = JsonConvert.SerializeObject(instance);
    watch.Stop();
    jsonSerializeTime += watch.ElapsedMilliseconds;

    watch.Restart();
    var deserialized = JsonConvert.DeserializeObject<F>(serialized);
    watch.Stop();
    jsonDeserializeTime += watch.ElapsedMilliseconds;
}

// Время вывода в консоль
var consoleWatch = Stopwatch.StartNew();
Console.WriteLine($"\nСериализуемый класс: class F {{ int i1, i2, i3, i4, i5; }}");
Console.WriteLine($"Количество замеров: {iterations} итераций");
Console.WriteLine($"Мой рефлекшен:");
Console.WriteLine($"Время на сериализацию = {reflectionSerializeTime} мс");
Console.WriteLine($"Время на десериализацию = {reflectionDeserializeTime} мс");
Console.WriteLine($"Стандартный механизм (NewtonsoftJson):");
Console.WriteLine($"Время на сериализацию = {jsonSerializeTime} мс");
Console.WriteLine($"Время на десериализацию = {jsonDeserializeTime} мс");
Console.Write("Введите путь к файлу (.ini или .csv): ");

consoleWatch.Stop();

string filePath = Console.ReadLine() ?? string.Empty;

consoleWatch.Start();

if (!File.Exists(filePath))
{
    Console.WriteLine("Файл не найден.");
    return;
}

string fileExtension = Path.GetExtension(filePath).ToLower();
string fileContent = File.ReadAllText(filePath);

static void Print(F f)
{
    Console.WriteLine($"i1={f.i1}, i2={f.i2}, i3={f.i3}, i4={f.i4}, i5={f.i5}");
}

static long MeasureDeserializationTime<T>(
    Func<string, T> deserializeFunc,
    string data,
    int iterations = 1000) where T : class
{
    // Прогревочный прогон
    for (int i = 0; i < 10; i++)
        deserializeFunc(data);

    var watch = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++)
        deserializeFunc(data);
    watch.Stop();

    return watch.ElapsedMilliseconds;
}

switch (fileExtension)
{
    case ".ini":
        long iniTime = MeasureDeserializationTime(Serializer.DeserializeFromIni<F>, fileContent, iterations);
        F fIni = Serializer.DeserializeFromIni<F>(fileContent);
        Console.WriteLine($"\n[INI] Десериализация выполнена за {iniTime} мс ({iterations} итераций)");
        Print(fIni);
        break;

    case ".csv":
        long csvTime = MeasureDeserializationTime(Serializer.DeserializeFromCsv<F>, fileContent, iterations);
        F fCsv = Serializer.DeserializeFromCsv<F>(fileContent);
        Console.WriteLine($"\n[CSV] Десериализация выполнена за {csvTime} мс ({iterations} итераций)");
        Print(fCsv);
        break;

    default:
        Console.WriteLine("Неподдерживаемый формат файла.");
        break;
}

consoleWatch.Stop();
Console.WriteLine($"\nВремя вывода текста в консоль: {consoleWatch.ElapsedMilliseconds} мс");