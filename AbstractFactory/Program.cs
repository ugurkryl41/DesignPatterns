using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogging();
            _caching = _crossCuttingConcernsFactory.CreateCaching();

        }

        public void GetAll()
        {
            Console.WriteLine("Products Listed!");
            //_crossCuttingConcernsFactory.CreateLogging().Log();
            _logging.Log();
            _caching.Cache();
        }
    }

    public abstract class Logging
    {
        public abstract void Log();
    }

    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with nLogger");
        }
    }
    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache();
    }

    public class MemCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Caching with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Caching with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogging();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new NLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new Log4NetLogger();
        }
    }
}
