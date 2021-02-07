using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.creditCalculaterBase = new OldCustomer();
            customerManager.SaveCredit();

            customerManager.creditCalculaterBase = new NewCustomer();
            customerManager.SaveCredit();
        }
    }

    public abstract class CreditCalculaterBase
    {
        public abstract decimal Calculate(decimal kredi);
    }

    class OldCustomer : CreditCalculaterBase
    {
        public override decimal Calculate(decimal kredi)
        {
            return kredi + kredi * 1.25m;
        }
    }
    class NewCustomer : CreditCalculaterBase
    {
        public override decimal Calculate(decimal kredi)
        {
            return kredi + kredi * 1.80m;
        }
    }

    public class CustomerManager
    {
        public CreditCalculaterBase creditCalculaterBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager Business");            
            Console.WriteLine(creditCalculaterBase.Calculate(10000));
        }
    }

}
