using System;


namespace FactoryMethod
{
    class Program
    {
        static void Main()
        {
            var factory = new SavingsAccountFactory () as ICreditUnionFactory;
            var citiAccount = factory.GetSavingsAccount("CITI-1234");
            var nationalAccount = factory.GetSavingsAccount("NATIONAL-6789");

            Console.WriteLine($"Account - {citiAccount}");
            Console.WriteLine($"Account - {nationalAccount}");
        }
    }
}
