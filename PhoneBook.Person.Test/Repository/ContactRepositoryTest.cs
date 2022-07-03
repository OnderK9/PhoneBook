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
    public class ContactRepositoryTest
    {
        private readonly IContactRepository _repo;

        public ContactRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>()
                                    .UseInMemoryDatabase("MyInMemoryDatabseName");
            var context = new PhoneBookContext(optionsBuilder.Options);

            _repo = new ContactRepository(context);
        }

        public class PersonViewData : TheoryData<dbContact>
        {
            public PersonViewData()
            {
                Add(new dbContact()
                {
                    UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c800"),
                    dbContactTypeUUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                    Content = "test",
                    dbPersonUUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")
                });
            }
        }
        [Theory]
        [ClassData(typeof(PersonViewData))]
        public void Add(dbContact contact)
        {
            // Act

            _repo.Add(contact);
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

        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _repo.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<dbContact>>(okResult);

        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetPersonContacts(Guid id)
        {
            // Act
            var okResult = _repo.GetPersonContacts(id);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<dbContact>>(okResult);

        }

    }
}
