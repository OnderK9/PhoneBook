using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Core.Filters;
using PhoneBook.Core.View;
using PhoneBook.Report.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Report.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ValidateModel] //Veriler controllera gelmeden ModelState kontrol ediliyor, hata var ise istek geri çevriliyor
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
        public IEnumerable<ReportView> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public ServiceResultView AddReport()
        {
            return _service.Create();
        }

        [HttpGet]
        [Route("{reportId}")]
        public ServiceResultView GetReport(Guid reportId)
        {
            return _service.Get(reportId);
        }


        [HttpGet]
        [Route("process")]
        public ServiceResultView ProcessReport(Guid reportId)
        {
            return _service.ProcessReport(reportId);
        }

    }
}
