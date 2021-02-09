using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*CustomerManager customerManager = new CustomerManager(new NLogLogger());
            customerManager.Save();*/

            CustomerManagerTests customerManagerTests = new CustomerManagerTests();
            customerManagerTests.SaveTest();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLogLogger");
        }
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class StubLogger : ILogger //Null Object + Singleton
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();
        private StubLogger()
        {

        }
        public void Log()
        {
            
        }
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                return _stubLogger == null ? _stubLogger = new StubLogger() : _stubLogger;
            }
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }

    }
}
