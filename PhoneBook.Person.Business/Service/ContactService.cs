using AutoMapper;
using PhoneBook.Core.View;
using PhoneBook.Person.Data;
using PhoneBook.Person.Data.Repository;
using System;
using System.Collections.Generic;

namespace PhoneBook.Person.Business
{
    public class ContactService : IContactService
    {
        IMapper _mapper;
        IContactRepository _repoContact;
        IContactTypeRepository _repoContactType;
        public ContactService(IContactRepository repoContact, IContactTypeRepository repoContactType, IMapper mapper)
        {
            _mapper = mapper;
            _repoContact = repoContact;
            _repoContactType = repoContactType;
        }

        public ServiceResultView Add(ContactView view)
        {
            ServiceResultView result = new ServiceResultView();

            dbContact contact = _mapper.Map<dbContact>(view);
            _repoContact.Add(contact);
            result.IsSucceed = _repoContact.SaveChanges();

            return result;
        }

        public ServiceResultView Delete(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            _repoContact.Delete(id);
            result.IsSucceed = _repoContact.SaveChanges();

            return result;
        }

        public IEnumerable<ContactTypeView> GetContactTypes()
        {
            return _mapper.Map<IEnumerable<ContactTypeView>>(_repoContactType.GetAll());
        }
    }
}
