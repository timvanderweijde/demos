using System;
using System.Collections.Generic;

namespace Exercise_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var classOfStudents = new ClassOfStudents();

            // The code below does not compile, because the ClassOfStudents type is not enumerable.
            // Uncomment the code and make sure it compiles by modifying the ClassOfStudents type so that it's enumerable.
            //foreach (Student student in classOfStudents)
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

    public class ClassOfStudents
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