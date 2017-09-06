namespace CommandPattern
{
    internal interface ICalculator<T>
    {
        T Compute();
        void Operation(INode<T> node);
    }
}
