using PhoneBook.Core.View;
using System;
using System.Collections.Generic;

namespace PhoneBook.Person.Business
{
    public interface IReportService
    {
        IList<LocationReportView> GetLocationReport();
    }
}
