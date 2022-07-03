using AutoMapper;
using PhoneBook.Core.View;
using PhoneBook.Person.Data;
using PhoneBook.Person.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Person.Business
{
    public class ReportService : IReportService
    {
        IMapper _mapper;
        IContactRepository _repository;
        IContactTypeRepository _contactTypeRepository;
        public ReportService(IContactRepository repository, IContactTypeRepository contactTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _contactTypeRepository = contactTypeRepository;
        }

        /// <summary>
        /// Rapor basitçe aşağıdaki bilgileri içerecektir:
        /// • Konum Bilgisi
        /// • O konumda yer alan rehbere kayıtlı kişi sayısı
        /// • O konumda yer alan rehbere kayıtlı telefon numarası sayısı
        /// </summary>
        /// <returns></returns>
        public IList<LocationReportView> GetLocationReport()
        {
            IList<LocationReportView> list = new List<LocationReportView>();
            dbContactType locationType = _contactTypeRepository.GetContactType("Location");
            dbContactType phoneType = _contactTypeRepository.GetContactType("Telefon");

            List<dbContact> contacts = _repository.GetAll();
            List<dbContact> locationContacts = contacts.Where(x => x.dbContactTypeUUID == locationType.UUID).ToList();
            List<dbContact> phoneContacts = contacts.Where(x => x.dbContactTypeUUID == phoneType.UUID).ToList();

            //cross join ile konum ve telefon bilgileri birleştiriliyor
            var phoneLocations = from t1 in locationContacts
                                 from t2 in phoneContacts
                                 where t1.dbPersonUUID == t2.dbPersonUUID
                                 select new { Table1Id = t1.dbPersonUUID, location = t1.Content, phone = t2.Content };


            var groups = locationContacts.GroupBy(x => x.Content);// Konuma göre gruplandı
            foreach (var group in groups)
            {
                LocationReportView item = new LocationReportView()
                {
                    Location = group.Key,
                    PersonCount = group.Count(),
                    PhoneCount = phoneLocations.Where(x => x.location == group.Key).Count()
                };
                list.Add(item);
            }


            return list;
        }
    }
}
