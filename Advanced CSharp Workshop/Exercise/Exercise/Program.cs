using System;
using System.Collections;
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
            foreach (Student student in classOfStudents)
            {
                Console.WriteLine(student.Name);
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; set; }
    }

    public class ClassOfStudents : IEnumerable<Student>, IEnumerator<Student>
    {
        private readonly List<Student> students = new List<Student>
            {
                new Student {Name = "Jan"},
                new Student {Name = "Klaas"},
                new Student {Name = "Nico"},
                new Student {Name = "Daan"},
            };

        private int index = -1;

        public IEnumerator<Student> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;

            return (index < students.Count);
        }

        public void Reset()
        {
            index = -1;
        }

        public Student Current {
            get { return students[index]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}