
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
    public interface IFactoryAdd<T>
    {
        T Add(T one,T Two);
    }
    public interface IFactorySubstract<T>
    {
        T Substract(T one,T Two);
    }
    public interface IFactoryDivide<T>
    {
        T Divide(T one,T Two);
    }
    public interface IFactoryMultiply<T>
    {
        T Multiply(T one,T Two);
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
