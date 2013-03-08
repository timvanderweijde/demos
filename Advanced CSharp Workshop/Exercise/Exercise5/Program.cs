using System;

namespace Exercise5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person {Name = "bill"};

            LogPropertyNameAndValue(() => person.Name);

            Console.ReadKey();
        }

        private static void LogPropertyNameAndValue<T>(Func<T> accessProperty)
        {
            Console.WriteLine("Property name: {0}, value:{1}", "unknown", accessProperty());
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}