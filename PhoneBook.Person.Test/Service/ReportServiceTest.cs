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
    public class ReportServiceTest
    {
        private readonly IReportService _service;
        private readonly IContactRepository _repo;
        private readonly IContactTypeRepository _repoType;

        public ReportServiceTest()
        {
            _repo = new ContactRepositoryFake();
            _repoType = new ContactTypeRepositoryFake();
            _service = new ReportService(_repo, _repoType, null);
        }

        [Fact]
        public void GetLocationReport()
        {
            // Act
            var okResult = _service.GetLocationReport();

            // Assert
            Assert.IsAssignableFrom<IList<LocationReportView>>(okResult);
        }

    }
}
