using System;


namespace FactoryMethod
{
    // Product
    public abstract class ISavingAccount
    {
        public decimal Balance { get; set; }
    }

    // Concrete Product
    public class CitiSavingsAccount : ISavingAccount
    {
        public CitiSavingsAccount()
        {
            Balance = 5000;
        }

        public override string ToString()
        {
            return $"Citi account ballance: {Balance}€";
        }
    }

    // Concrete Product
    public class NationalSavingsAccount : ISavingAccount
    {
        public NationalSavingsAccount()
        {
            Balance = 2700;
        }

        public override string ToString()
        {
            return $"National account ballance: {Balance}€";
        }
    }

    // Creator
    interface ICreditUnionFactory
    {
        ISavingAccount GetSavingsAccount(string accountNumber);
    }

    // Concrete Creator
    public class SavingsAccountFactory : ICreditUnionFactory
    {
        public ISavingAccount GetSavingsAccount(string accountNumber)
        {
            if (accountNumber.Contains("CITI"))
            {
                return new CitiSavingsAccount();
            }
            else if (accountNumber.Contains("NATIONAL"))
            {
                return new NationalSavingsAccount();
            }
            else
            {
                throw new ArgumentException("Invalid Account Number");
            }
        }
    }
}
