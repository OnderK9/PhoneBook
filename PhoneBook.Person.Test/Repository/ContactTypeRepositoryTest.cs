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
    public class ContactTypeRepositoryTest
    {
        private readonly IContactTypeRepository _repo;

        public ContactTypeRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>()
                                    .UseInMemoryDatabase("MyInMemoryDatabseName");
            var context = new PhoneBookContext(optionsBuilder.Options);

            _repo = new ContactTypeRepository(context);
        }

        [Theory]
        [InlineData("Telefon")]
        public void GetContactType(string name)
        {
            // Act
            var reult = _repo.GetContactType(name);

            // Assert
            Assert.True(true);

        }

        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _repo.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<dbContactType>>(okResult);

        }

    }
}
