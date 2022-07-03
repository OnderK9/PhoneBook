using AutoMapper;
using PhoneBook.Core.View;
using PhoneBook.Person.Data;
using PhoneBook.Person.Data.Repository;
using System;
using System.Collections.Generic;

namespace PhoneBook.Person.Business
{
    public class PersonService : IPersonService
    {
        IMapper _mapper;
        IPersonRepository _repository;
        IContactRepository _contactRepository;
        public PersonService(IPersonRepository repository, IContactRepository contactRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _contactRepository = contactRepository;
        }

        public ServiceResultView Add(PersonView view)
        {
            ServiceResultView result = new ServiceResultView();

            dbPerson person = _mapper.Map<dbPerson>(view);
            _repository.Add(person);
            result.IsSucceed = _repository.SaveChanges();

            return result;
        }

        public ServiceResultView Get(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            dbPerson person = _repository.Get(id);
            IEnumerable<dbContact> contacts = _contactRepository.GetPersonContacts(id);

            PersonDetailView view = _mapper.Map<PersonDetailView>(person);
            view.Contacts = _mapper.Map<ICollection<ContactView>>(contacts);

            result.Data = view;

            return result;
        }

        public ServiceResultView Delete(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            _repository.Delete(id);
            result.IsSucceed = _repository.SaveChanges();

            return result;
        }

        public IEnumerable<PersonView> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonView>>(_repository.GetAll());
        }

        public IList<LocationReportView> GetLocationReport()
        {
            IList<LocationReportView> list = new List<LocationReportView>();

            return list;
        }
    }
}
