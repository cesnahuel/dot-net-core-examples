namespace CommandPattern
{
    internal interface ICalculator<T>
    {
        INode<T> CurrentOperation { get; }
        T Compute();
        INode<T> SetOperation(INode<T> operation);
    }
}
