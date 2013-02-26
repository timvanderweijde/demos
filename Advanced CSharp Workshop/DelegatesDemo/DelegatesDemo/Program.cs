using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    class Program
    {
        public delegate void Say(string subject);

        public static void Hello(string subject)
        {
            Console.WriteLine("Hello " + subject);
        }

        public static void Goodbye(string subject)
        {
            Console.WriteLine("Goodbye " + subject);
        }

        private static void Main(string[] args)
        {
            Say hello = Hello;
            Say goodbye = Goodbye;

            Say both = (Say)Delegate.Combine(hello, goodbye);

            Say bothInDifferentWay = hello + goodbye;

            Console.WriteLine("Invoking hello");
            hello("test");

            Console.WriteLine("Invoking goodbye");
            goodbye("test");

            Console.WriteLine("Invoking both");
            both("test");

            Console.WriteLine("Invoking bothInDifferentWay");
            bothInDifferentWay("test");

            Console.ReadKey();
        }
    }
}
