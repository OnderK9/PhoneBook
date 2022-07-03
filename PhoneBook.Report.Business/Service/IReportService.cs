using PhoneBook.Core.View;
using System;
using System.Collections.Generic;

namespace PhoneBook.Report.Business
{
    public interface IReportService
    {
        ServiceResultView Create();
        ServiceResultView Get(Guid id);
        ServiceResultView ProcessReport(Guid id);
        IEnumerable<ReportView> GetAll();
    }
}
