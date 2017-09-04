namespace CommandPattern
{
    public abstract class INode<T>
    {
        public abstract T Compute();
        public override abstract string ToString();
    }
}
