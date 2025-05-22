using HomeWork.Multithread;

SystemInfo.GetInfo();

var sizes = new[] { 100000, 1000000, 10000000 };

Console.WriteLine("\n=== Запуск ===");
foreach (var size in sizes)
{
    int[] array = ArrayGenerator.Generate(size);

    long sequentialTime = SumCalculator.MeasureSequential(array);
    long parallelThreadsTime = SumCalculator.MeasureParallelWithThreads(array);
    long plinqTime = SumCalculator.MeasurePLINQ(array);

    Console.WriteLine($"\nРазмер: {size:N0} | Последовательно: {sequentialTime} мс | Потоки: {parallelThreadsTime} мс | PLINQ: {plinqTime} мс");
}
Console.WriteLine("\n=== Конец ===");
