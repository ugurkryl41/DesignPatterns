using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerM = new CustomerManager();
            customerM.Save();
        }
    }

    class CustomerManager
    {
        private CCCFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CCCFacade();
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            _concerns.logging.Log();
            _concerns.validation.Validate();
            _concerns.caching.Cache();
        }

    }
    class CCCFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IValidation validation;

        public CCCFacade()
        {
            logging = new Logging();
            caching = new Caching();
            validation = new Validation();
        }
    }

    interface ILogging
    {
        void Log();
    }
    interface ICaching
    {
        void Cache();
    }
    interface IValidation
    {
        void Validate();
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }

    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }
}
