using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log("User Data");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class UkLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged {0}",message);
        }
    }   

    class Log4Net //suppose other service
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net {0}",message);
        }
    }
    // Adapter, Allows other services to be integrated
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
