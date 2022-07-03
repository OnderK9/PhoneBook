using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using PhoneBook.Person.Controllers;
using PhoneBook.Person.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Person.Test
{
    public class ReportControllerTest
    {
        private readonly ReportController _controller;
        private readonly IReportService _service;

        public ReportControllerTest()
        {
            _service = new ReportServiceFake();
            _controller = new ReportController(_service, null);
        }

        [Fact]
        public void GetLocationReport()
        {
            // Act
            var okResult = _controller.GetLocationReport();

            // Assert
            Assert.IsAssignableFrom<IList<LocationReportView>>(okResult);

        }

    }
}
