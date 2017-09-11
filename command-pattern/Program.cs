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

            INode<decimal> SubOp = decimalFactory.GetSubtractOperation(V1, V2);
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");

            INode<decimal> MulOp = decimalFactory.GetMultiplyOperation(AddOp, SubOp);
            Console.WriteLine($"compute {MulOp} = {MulOp.Compute()}");

            PrintMessage("Calculator example with double values:");
            IFactory<double> doubleFactory = new DoubleFactory();
            User<double> user = new User<double>(doubleFactory);
            // user.SetValue(3.14);
            user.Apply(Operation.ADD, 0.14);
            user.Apply(Operation.ADD, 1.06);
            user.Apply(Operation.MULTIPLY, 3.14);

            PrintMessage("Check trigonometric evaluation:");
            INode<double> V = new Value<double>(Math.PI/3.0);
            INode<double> SinOp = (doubleFactory as ITrigonometryFactory<double>).GetSinOperation(V);
            Console.WriteLine($"compute {SinOp} = {SinOp.Compute()}");
            INode<double> Pow2SinOp = (doubleFactory as IFunctionFactory<double>).GetPow2Operation(SinOp);
            Console.WriteLine($"compute {Pow2SinOp} = {Pow2SinOp.Compute()}");
            INode<double> CosOp = (doubleFactory as ITrigonometryFactory<double>).GetCosOperation(V);
            Console.WriteLine($"compute {CosOp} = {CosOp.Compute()}");
            INode<double> Pow2CosOp = (doubleFactory as IFunctionFactory<double>).GetPow2Operation(CosOp);
            Console.WriteLine($"compute {Pow2CosOp} = {Pow2CosOp.Compute()}");
            INode<double> TrigAddOp = (doubleFactory as INumericFactory<double>).GetAddOperation(Pow2CosOp, Pow2SinOp);
            Console.WriteLine($"compute {TrigAddOp} = {TrigAddOp.Compute()}");
        }
        public static void PrintMessage(string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine(new StringBuilder().Insert(0, "=", msg.Length));
        }
    }
}
