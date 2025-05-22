using System.Diagnostics;

namespace HomeWork.Multithread
{
    public static class SumCalculator
    {
        public static long MeasureSequential(int[] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long MeasureParallelWithThreads(int[] array)
        {
            int threadCount = Environment.ProcessorCount;
            int chunkSize = array.Length / threadCount;
            long sumTotal = 0;
            object lockObj = new();

            Stopwatch sw = Stopwatch.StartNew();

            Task[] tasks = new Task[threadCount];

            for (int t = 0; t < threadCount; t++)
            {
                int start = t * chunkSize;
                int end = (t == threadCount - 1) ? array.Length : start + chunkSize;

                tasks[t] = Task.Run(() =>
                {
                    long localSum = 0;
                    for (int i = start; i < end; i++)
                    {
                        localSum += array[i];
                    }
                    lock (lockObj)
                    {
                        sumTotal += localSum;
                    }
                });
            }

            Task.WaitAll(tasks);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long MeasurePLINQ(int[] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long sum = array.AsParallel().Sum();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
