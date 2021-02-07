using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager = new CreditManagerProxy();

            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {        
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 10; i++)
            {
                result += i;
                Thread.Sleep(500);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cacheValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cacheValue = _creditManager.Calculate();
            }

            return _cacheValue;
        }
    }
}
