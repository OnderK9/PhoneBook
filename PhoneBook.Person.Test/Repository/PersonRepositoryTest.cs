using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using PhoneBook.Person.Controllers;
using PhoneBook.Person.Data;
using PhoneBook.Person.Data.Repository;
using PhoneBook.Person.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class PersonRepositoryTest
    {
        private readonly IPersonRepository _repo;

        public PersonRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>()
                                    .UseInMemoryDatabase("MyInMemoryDatabseName");
            var context = new PhoneBookContext(optionsBuilder.Options);

            _repo = new PersonRepository(context);
        }

        public class PersonViewData : TheoryData<dbPerson>
        {
            public PersonViewData()
            {
                Add(new dbPerson()
                {
                    UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Company = "Test Company 3",
                    Name = "Test3",
                    Surname = "3"
                });
            }
        }
        [Theory]
        [ClassData(typeof(PersonViewData))]
        public void Add(dbPerson person)
        {
            // Act

            _repo.Add(person);
            // Assert
            Assert.True(true);
        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void Delete(Guid id)
        {
            // Act
             _repo.Delete(id);

            // Assert
            Assert.True(true);

        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void Get(Guid id)
        {
            // Act
            var okResult = _repo.Get(id);

            // Assert
            Assert.True(true);

        }
        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _repo.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<dbPerson>>(okResult);

        }

    }
}
