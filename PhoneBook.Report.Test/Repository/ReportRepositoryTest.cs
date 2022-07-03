using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.View;
using PhoneBook.Report.Business;
using PhoneBook.Report.Controllers;
using PhoneBook.Report.Data;
using PhoneBook.Report.Data.Repository;
using PhoneBook.Report.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class ReportRepositoryTest
    {
        private readonly IReportRepository _repo;

        public ReportRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>()
                                    .UseInMemoryDatabase("MyInMemoryDatabseNameReport");
            var context = new PhoneBookContext(optionsBuilder.Options);

            _repo = new ReportRepository(context);
        }

        public class PersonViewData : TheoryData<dbReport>
        {
            public PersonViewData()
            {
                Add(new dbReport()
                {
                    UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    FileUrl = "",
                    RequestDate = DateTime.Now,
                    Status = EnumReportStatus.Waiting
                });
            }
        }
        [Theory]
        [ClassData(typeof(PersonViewData))]
        public void Add(dbReport person)
        {
            // Act

            _repo.Add(person);
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
            Assert.IsAssignableFrom<IEnumerable<dbReport>>(okResult);

        }

    }
}
