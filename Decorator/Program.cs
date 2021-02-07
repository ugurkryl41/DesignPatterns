using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.2", HirePrice = 10000 };

            SpecialOffer special = new SpecialOffer(personalCar);
            special.Discount = 10;

            Console.WriteLine("Price: {0}", personalCar.HirePrice);
            Console.WriteLine("Special Price: {0}", special.HirePrice);
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int Discount;
        private CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - _carBase.HirePrice * Discount / 100;
            }
            set { }
        }
    }
}
