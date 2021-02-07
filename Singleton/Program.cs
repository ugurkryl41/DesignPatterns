using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.WriteLine("");
        }
    }

    class CustomerManager
    {
        private CustomerManager() { }
        private static CustomerManager _customerManager;

        static object _lockObject = new object();

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject) // Thread Safe Singleton..
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
