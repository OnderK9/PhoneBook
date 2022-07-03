using AutoMapper;
using PhoneBook.Person.Business;
using PhoneBook.Person.Controllers;
using PhoneBook.Person.Data.Repository;
using PhoneBook.Person.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class ContactServiceTest
    {
        private readonly IContactService _service;
        private readonly IContactRepository _repo;
        private readonly IContactTypeRepository _repoType;

        public ContactServiceTest()
        {
            //auto mapper configuration
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _repo = new ContactRepositoryFake();
            _repoType = new ContactTypeRepositoryFake();
            _service = new ContactService(_repo, _repoType, mapper);
        }

        [Fact]
        public void GetContactTypes()
        {
            // Act
            var okResult = _service.GetContactTypes();

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
        public void AddContact(ContactView contact)
        {
            //Arrange

            // Act
            var okResult = _service.Add(contact);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c800")]
        public void DeletePerson(Guid id)
        {
            // Act
            var okResult = _service.Delete(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

    }
}
