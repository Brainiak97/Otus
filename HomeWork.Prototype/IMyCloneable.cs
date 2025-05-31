namespace HomeWork.Prototype
{
    public interface IMyCloneable<out T>
    {
        T Clone();
    }
}
