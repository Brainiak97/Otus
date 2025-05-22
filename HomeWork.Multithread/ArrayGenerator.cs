namespace HomeWork.Multithread
{
    public static class ArrayGenerator
    {
        public static int[] Generate(int size)
        {
            Random rand = new();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 100);
            }
            return array;
        }
    }
}
