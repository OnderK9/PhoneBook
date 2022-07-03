using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Person.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _service;

        public ReportController(IReportService service, ILogger<ReportController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("location")]
        public IList<LocationReportView> GetLocationReport()
        {
            return _service.GetLocationReport();
        }

    }
}
