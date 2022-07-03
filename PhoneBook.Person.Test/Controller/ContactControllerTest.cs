using PhoneBook.Person.Business;
using PhoneBook.Person.Controllers;
using PhoneBook.Person.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class ContactControllerTest
    {
        private readonly ContactController _controller;
        private readonly IContactService _service;

        public ContactControllerTest()
        {
            _service = new ContactServiceFake();
            _controller = new ContactController(_service, null);
        }

        [Fact]
        public void GetContactTypes()
        {
            // Act
            var okResult = _controller.GetContactTypes();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<ContactTypeView>>(okResult);

        }

        public class ContactViewData : TheoryData<ContactView>
        {
            public ContactViewData()
            {
                Add(new ContactView()
                {
                    UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c800"),
                    ContactTypeUUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                    Content = "test",
                    PersonUUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")
                });
            }
        }
        [Theory]
        [ClassData(typeof(ContactViewData))]
        public void AddContact(ContactView person)
        {
            //Arrange

            // Act
            var okResult = _controller.AddContact(person);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c800")]
        public void DeletePerson(Guid id)
        {
            // Act
            var okResult = _controller.DeletePerson(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

    }
}
