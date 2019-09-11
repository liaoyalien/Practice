using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var intlist = new MyGenericList<Employee>();

            intlist[0] = new Employee { Id = 0, Name="Milian"};
            intlist[1] = new Employee { Id = 2, Name = "Ace" };

            var emp1 = intlist[0];
            var emp2 = intlist[1];
        }
    }

    public class Employee {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
