using Hardware.Info;

namespace HomeWork.Multithread
{
    public class SystemInfo
    {
        public static void GetInfo()
        {
            var hardwareInfo = new HardwareInfo();
            hardwareInfo.RefreshAll();

            Console.WriteLine("=== Информация о системе ===");
            Console.WriteLine("Процессоры:");
            foreach (var cpu in hardwareInfo.CpuList)
            {
                Console.WriteLine($" - {cpu.Name}");
            }

            Console.WriteLine("Материнские платы:");
            foreach (var motherboard in hardwareInfo.MotherboardList)
            {
                Console.WriteLine($" - {motherboard.Manufacturer}, {motherboard.SerialNumber}");
            }

            Console.WriteLine("Оперативная память:");
            foreach (var ram in hardwareInfo.MemoryList)
            {
                Console.WriteLine($" - {ram.Capacity / (1024 * 1024 * 1024)} GB");
            }

            Console.WriteLine("Диски:");
            foreach (var disk in hardwareInfo.DriveList)
            {
                Console.WriteLine($" - {disk.Manufacturer}, {disk.Size / (1024 * 1024 * 1024)} GB");
            }
        }
    }
}
