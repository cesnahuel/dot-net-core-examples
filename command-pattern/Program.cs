using System;
using System.Text;


namespace CommandPattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintMessage("Example with decimal values:");
            DecimalFactory decimalFactory = new DecimalFactory();

            Value<decimal> V1 = new Value<decimal>(1.3M);
            Value<decimal> V2 = new Value<decimal>(3.8M);

            INode<decimal> AddOp = decimalFactory.GetAddOperation(V1, V2);
            Console.WriteLine($"compute {AddOp} = {AddOp.Compute()}");

            INode<decimal> SubOp = decimalFactory.GetSubstractOperation(V1, V2);
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");

            INode<decimal> MulOp = decimalFactory.GetMultiplyOperation(AddOp, SubOp);
            Console.WriteLine($"compute {MulOp} = {MulOp.Compute()}");

            PrintMessage("Calculator example with double values:");
            /*
            User<DoubleVal> user = new User<DoubleVal>();
            //user.SetValue(3.14);
            user.Apply(Operation.ADD, 0.14);
            user.Apply(Operation.ADD, 1.06);
            user.Apply(Operation.MULTIPLY, 3.14);
            */
        }
        public static void PrintMessage(string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine(new StringBuilder().Insert(0, "=", msg.Length));
        }
    }
}
