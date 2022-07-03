using PhoneBook.Person.Business;
using PhoneBook.Person.Controllers;
using PhoneBook.Person.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class PersonControllerTest
    {
        private readonly PersonController _controller;
        private readonly IPersonService _service;

        public PersonControllerTest()
        {
            _service = new PersonServiceFake();
            _controller = new PersonController(_service, null);
        }

        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<PersonView>>(okResult);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetPerson(Guid id)
        {
            // Act
            var okResult = _controller.GetPerson(id);

            // Assert
            Assert.NotNull(okResult.Data);

        }

        public class PersonViewData : TheoryData<PersonView>
        {
            public PersonViewData()
            {
                Add(new PersonView()
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
        public void AddPerson(PersonView person)
        {
            //Arrange

            // Act
            var okResult = _controller.AddPerson(person);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void DeletePerson(Guid id)
        {
            // Act
            var okResult = _controller.DeletePerson(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }
    }
}
