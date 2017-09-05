
namespace CommandPattern
{
    public interface INumeric<T> : INumericAdd<T>
    {
        T Subtract(T b);
        T Divide(T b);
        T Multiply(T b);
    }

    public interface INumericAdd<T>
    {
        T Add(T b);
    }
}
