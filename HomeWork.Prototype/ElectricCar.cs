namespace HomeWork.Prototype
{
    public class ElectricCar(string brand, string model, int batteryCapacity) : Car(brand, model), IMyCloneable<ElectricCar>, ICloneable
    {
        public int BatteryCapacity { get; set; } = batteryCapacity; // kWh

        public override ElectricCar Clone()
        {
            return new ElectricCar(Brand, Model, BatteryCapacity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
