using PhoneBook.Core.View;
using System;
using System.Collections.Generic;

namespace PhoneBook.Person.Business
{
    public interface IPersonService
    {
        ServiceResultView Add(PersonView person);
        ServiceResultView Delete(Guid id);
        ServiceResultView Get(Guid id);
        IEnumerable<PersonView> GetAll();
        IList<LocationReportView> GetLocationReport();
    }
}
