namespace CommandPattern
{
    public interface INode<T>
    {
        T Compute();
        string ToString();
    }
}
