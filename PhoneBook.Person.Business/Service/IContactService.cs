using PhoneBook.Core.View;
using System;
using System.Collections.Generic;

namespace PhoneBook.Person.Business
{
    public interface IContactService
    {
        ServiceResultView Add(ContactView contact);
        ServiceResultView Delete(Guid id);
        IEnumerable<ContactTypeView> GetContactTypes();
    }
}
