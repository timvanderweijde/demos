using System;

namespace Exercise5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new Mapper<Person, PersonDto>();
            mapper.AddMapping(x => x.Name, y => y.FullName);
            mapper.AddMapping(x => x.Age, y => y.AgeInYears);

            var person = new Person
                {
                    Name = "Chuck Norris",
                    Age = 34,
                    Title = "Professional Wrecketeer"
                };

            PersonDto personDto = mapper.Map(person);

            Console.WriteLine("Name: {0}", personDto.FullName);
            Console.WriteLine("Age: {0}", personDto.AgeInYears);

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