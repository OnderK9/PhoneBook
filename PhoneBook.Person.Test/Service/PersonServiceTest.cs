using AutoMapper;
using PhoneBook.Core.View;
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
    public class PersonServiceTest
    {
        private readonly IPersonService _service;
        private readonly IPersonRepository _repo;
        private readonly IContactRepository _repoType;

        public PersonServiceTest()
        {
            //auto mapper configuration
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _repo = new PersonRepositoryFake();
            _repoType = new ContactRepositoryFake();
            _service = new PersonService(_repo, _repoType, mapper);
        }

        [Fact]
        public void GetLocationReport()
        {
            // Act
            var okResult = _service.GetLocationReport();

            // Assert
            Assert.IsAssignableFrom<IList<LocationReportView>>(okResult);
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
        public void Add(PersonView person)
        {
            // Act
            var okResult = _service.Add(person);

            // Assert
            Assert.True(okResult.IsSucceed);
        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void Delete(Guid id)
        {
            // Act
            var okResult = _service.Delete(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }
        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void Get(Guid id)
        {
            // Act
            var okResult = _service.Get(id);

            // Assert
            Assert.NotNull(okResult.Data);

        }
        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _service.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<PersonView>>(okResult);

        }


    }
}
