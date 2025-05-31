namespace HomeWork.Prototype
{
    public class Vehicle : IMyCloneable<Vehicle>, ICloneable
    {
        public string Brand { get; set; }

        protected Vehicle(string brand)
        {
            Brand = brand;
        }

        // Клонирование через пользовательский интерфейс
        public virtual Vehicle Clone()
        {
            return new Vehicle(Brand);
        }

        // Клонирование через стандартный ICloneable
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
