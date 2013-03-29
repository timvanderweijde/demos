using System;
using System.Reflection;

namespace Exercise_5
{
    public class Test
    {
        public string SomeProperty { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Test test = new Test();


            Type type = typeof(Test);
            PropertyInfo info = type.GetProperty("SomeProperty");
            info.SetValue(test, "Een waarde");


            Console.WriteLine(test.SomeProperty);
            Console.ReadKey();








            //var mapper = new Mapper<Person, PersonDto>();
            //mapper.AddMapping(x => x.Name, y => y.FullName);
            //mapper.AddMapping(x => x.Age, y => y.AgeInYears);

            //var person = new Person
            //    {
            //        Name = "Chuck Norris",
            //        Age = 34,
            //        Title = "Professional Wrecketeer"
            //    };

            //PersonDto personDto = mapper.Map(person);

            //Console.WriteLine("Name: {0}", personDto.FullName);
            //Console.WriteLine("Age: {0}", personDto.AgeInYears);

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
    }

    public class PersonDto
    {
        public string FullName { get; set; }
        public int AgeInYears { get; set; }
    }
}