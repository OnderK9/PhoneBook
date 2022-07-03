using AutoMapper;
using PhoneBook.Core.View;
using PhoneBook.Report.Business;
using PhoneBook.Report.Controllers;
using PhoneBook.Report.Data.Repository;
using PhoneBook.Report.Test.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Report.Test
{
    public class ReportServiceTest
    {
        private readonly IReportService _service;
        private readonly IReportRepository _repo;

        public ReportServiceTest()
        {
            //auto mapper configuration
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _repo = new ReportRepositoryFake();
            _service = new ReportService(_repo,  mapper);
        }

        [Fact]
        public void GetAll()
        {
            // Act
            var okResult = _service.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<ReportView>>(okResult);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void GetReport(Guid id)
        {
            // Act
            var okResult = _service.Get(id);

            // Assert
            Assert.NotNull(okResult.Data);

        }

        [Fact]
        public void AddReport()
        {
            //Arrange

            // Act
            var okResult = _service.Create();

            // Assert
            Assert.True(okResult.IsSucceed);

        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
        public void ProcessReport(Guid id)
        {
            // Act
            var okResult = _service.ProcessReport(id);

            // Assert
            Assert.True(okResult.IsSucceed);

        }

    }
}
