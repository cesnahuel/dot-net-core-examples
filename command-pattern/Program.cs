using System;
using System.Text;


namespace CommandPattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintMessage("Example with decimal values:");

            Value<DecimalVal> V1 = new Value<DecimalVal>(1.3M);
            Value<DecimalVal> V2 = new Value<DecimalVal>(3.8M);

            AddOperation<DecimalVal> AddOp = new AddOperation<DecimalVal>(V1, V2);
            Console.WriteLine($"compute {AddOp} = {AddOp.Compute()}");

            SubtractOperation<DecimalVal> SubOp = new SubtractOperation<DecimalVal>(V1, V2);
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");
            Console.WriteLine($"compute {SubOp} = {SubOp.Compute()}");

            //Bracket<DecimalVal> AddBra = new Bracket<DecimalVal>(AddOp);
            //Bracket<DecimalVal> SubBra = new Bracket<DecimalVal>(SubOp);
            //MultiplyOperation<DecimalVal> MulOp = new MultiplyOperation<DecimalVal>(AddBra, SubBra);
            MultiplyOperation<DecimalVal> MulOp = new MultiplyOperation<DecimalVal>(AddOp, SubOp);
            Console.WriteLine($"compute {MulOp} = {MulOp.Compute()}");

            PrintMessage("Calculator example with double values:");

            User<DoubleVal> user = new User<DoubleVal>();
            //user.SetValue(3.14);
            user.Apply(Operation.ADD, 0.14);
            user.Apply(Operation.ADD, 1.06);
            user.Apply(Operation.MULTIPLY, 3.14);
        }
        public static void PrintMessage(string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine(new StringBuilder().Insert(0, "=", msg.Length));
        }
    }
}
