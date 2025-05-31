namespace HomeWork.Prototype
{
    public class Car(string brand, string model) : Vehicle(brand), IMyCloneable<Car>, ICloneable
    {
        public string Model { get; set; } = model;

        public override Car Clone()
        {
            return new Car(Brand, Model);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
