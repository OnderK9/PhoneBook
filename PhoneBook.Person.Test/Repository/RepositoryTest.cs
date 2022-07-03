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
    public class RepositoryTest
    {
        private readonly Repository<dbPerson> _repo;

        public RepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>()
                                    .UseInMemoryDatabase("MyInMemoryDatabseNameReport");
            var context = new PhoneBookContext(optionsBuilder.Options);

            _repo = new Repository<dbPerson>(context);
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
        public void Insert(dbPerson person)
        {
            // Act

            _repo.Insert(person);
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void SaveChanges()
        {
            // Act
            var okResult = _repo.SaveChanges();

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

        [Theory]
        [ClassData(typeof(PersonViewData))]
        public void Delete(dbPerson person)
        {
            // Act

            _repo.Delete(person);
            // Assert
            Assert.True(true);
        }
        [Fact]
        public void GetFirst()
        {
            // Act

            _repo.GetFirst(x => x.UUID != null);
            // Assert
            Assert.True(true);
        }

    }
}
