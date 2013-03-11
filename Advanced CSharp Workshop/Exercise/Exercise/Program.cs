using System;
using System.Collections.Generic;

namespace Exercise_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myClass = new Class();

            //foreach (Student student in myClass)
            //{
            //    Console.WriteLine(student.Name);
            //}

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; set; }
    }

    public class Class
    {
        private readonly List<Student> students = new List<Student>
            {
                new Student {Name = "Jan"},
                new Student {Name = "Klaas"},
                new Student {Name = "Nico"},
                new Student {Name = "Daan"},
            };
    }
}