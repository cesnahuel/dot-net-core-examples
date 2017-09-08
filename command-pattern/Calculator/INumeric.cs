
namespace CommandPattern
{
    public interface INumeric<T> : INumericAdd<T>// where T : struct
    {
        T Subtract(T b);
        T Divide(T b);
        T Multiply(T b);
    }

    public interface INumericAdd<T>
    {
        T Add(T b);
    }
    public interface ITrigonometry<T>
    {
        // include Sin and Cos functions
    }
    public interface IFunction<T>
    {
        T Sqrt(T t);
        T Pow(T value, T power);
    }
}
