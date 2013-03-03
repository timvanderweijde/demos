using System;

namespace DelegatesDemo
{
    internal class Program
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

        public static event Say SayEvent;

        private static void Main(string[] args)
        {
            Say hello = Hello;
            Say goodbye = Goodbye;

            var both = (Say) Delegate.Combine(hello, goodbye);

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

    public class DifferentClass
    {
        public void SomeMethod()
        {
            Program.SayEvent += delegate(string subject) {  };
        }
    }
}