using PhoneBook.Report.Business;
using PhoneBook.Report.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using PhoneBook.Report.Test.Service;

namespace PhoneBook.Report.Test
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
        public void GetAll()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<ReportView>>(okResult);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetReport(Guid id)
        {
            // Act
            var okResult = _controller.GetReport(id);

            // Assert
            Assert.NotNull(okResult.Data);

        }

        [Fact]
        public void AddReport( )
        {
            //Arrange

            // Act
            var okResult = _controller.AddReport();

            // Assert
            Assert.True(okResult.IsSucceed);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void ProcessReport(Guid id)
        {
            // Act
            var okResult = _controller.ProcessReport(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }
    }
}
