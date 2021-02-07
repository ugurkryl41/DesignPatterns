using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ugur = new Employee { Name="Uğur" };
            Employee ali = new Employee { Name = "Ali" };
            Employee emin = new Employee { Name = "Emin" };

            ugur.SubAdd(ali);
            ugur.SubAdd(emin);

            Contractor salih = new Contractor { Name = "Salih" };

            emin.SubAdd(salih);
            Console.WriteLine(ugur.Name);
            foreach (Employee manager in ugur)
            {
                Console.WriteLine("|--> {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("     |--> {0}", employee.Name);
                }
            }

        }
    }

    interface IPerson
    {
        public string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        public string Name { get; set; }

        List<IPerson> _sub = new List<IPerson>();

        public void SubAdd(IPerson person)
        {
            _sub.Add(person);
        }

        public void SubRemove(IPerson person)
        {
            _sub.Remove(person);
        }

        public IPerson SubGet(int index)
        {
            return _sub[index];
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var sub in _sub)
            {
                yield return sub;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
