using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger(2);
            logger.Log();
        }
    }

    //* Loglama için factory oluşturuyoruz.

    public interface ILoggerFactory
    {
        ILogger CreateLogger(int x);
    }

    public class LoggerFactory : ILoggerFactory
    {
        int y;
        public ILogger CreateLogger(int x)
        {
            y = x;
            //Business decide to Factory
            if (y == 1)
            {
                return new UkLogger();

            }
            else
            {
                return new Log4NetLogger();
            }
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        int z;
        public ILogger CreateLogger(int x)
        {
            z = x;
            //Business decide to Factory
            if (z == 1)
            {
                return new UkLogger();
                
            }
            else
            {
                return new Log4NetLogger();
            }            
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public class UkLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Uk Logged!");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log4Net Logged!");
        }
    }

}
