using HomeWork.Prototype;

var original = new ElectricCar("Tesla", "Model S", 100);
var clone1 = original.Clone(); // Через IMyCloneable
var clone2 = (ElectricCar)((ICloneable)original).Clone(); // Через ICloneable

Console.WriteLine($"Original: {original.Brand} {original.Model}, {original.BatteryCapacity} kWh");
Console.WriteLine($"Clone1: {clone1.Brand} {clone1.Model}, {clone1.BatteryCapacity} kWh");
Console.WriteLine($"Clone2: {clone2.Brand} {clone2.Model}, {clone2.BatteryCapacity} kWh");

// Проверка, что это разные объекты
Console.WriteLine($"\nReferenceEquals(original, clone1): {ReferenceEquals(original, clone1)}");
Console.WriteLine($"ReferenceEquals(clone1, clone2): {ReferenceEquals(clone1, clone2)}");