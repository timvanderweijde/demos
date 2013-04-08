using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_5.Tests
{
    [TestClass]
    public class MappingSpec
    {
        [TestMethod]
        public void Maps()
        {
            var mapper = new Mapper<Person, PersonDto>();
            mapper.AddMapping(x => x.Name, y => y.FullName);
            mapper.AddMapping(x => x.Age, y => y.AgeInYears);

            var person = new Person
                {
                    Name = "Chuck Norris",
                    Age = 433,
                    Title = "Texas Ranger"
                };

            PersonDto personDto = mapper.Map(person);

            personDto.FullName.Should().Be("Chuck Norris");
            personDto.AgeInYears.Should().Be(433);
        }
    }
}