using System;
using System.Collections.Generic;

namespace Observe
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            var employeeObserver = new EmployeeObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(employeeObserver);
            productManager.Detach(employeeObserver);
            productManager.UpdatePrice();
        }
    }

    class ProductManager
    {
        List<Observer> _observer = new List<Observer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Updated!.");
            Notify();
        }

        public void Attach(Observer observe)
        {
            _observer.Add(observe);
        }
        public void Detach(Observer observe)
        {
            _observer.Remove(observe);
        }
        private void Notify()
        {
            foreach (var observer in _observer)
            {
                observer.Update(); // info sent to Observer (Customer or Employee)
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("info sent to customer!");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("info sent to customer!");
        }
    }
}
