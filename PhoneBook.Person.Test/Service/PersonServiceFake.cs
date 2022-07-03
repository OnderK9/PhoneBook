using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Test.Service
{
    public class PersonServiceFake : IPersonService
    {
        private readonly List<PersonView> dataList;

        public PersonServiceFake()
        {
            dataList = new List<PersonView>()
            {
                new PersonView() {
                    UUID =new Guid( "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Company ="Test Company",
                    Name ="Test",
                    Surname ="12314"
                },
                new PersonView() {
                    UUID =new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"),
                    Company ="Test Company 1",
                    Name ="Test 1",
                    Surname ="56789"
                }
            };
        }

        public ServiceResultView Add(PersonView view)
        {
            ServiceResultView result = new ServiceResultView();

            dataList.Add(view);
            result.IsSucceed = true;

            return result;
        }

        public ServiceResultView Get(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            result.Data = dataList.FirstOrDefault(x => x.UUID == id);

            return result;
        }

        public ServiceResultView Delete(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;
            dataList.Remove(dataList.FirstOrDefault(x => x.UUID == id));

            return result;
        }

        public IEnumerable<PersonView> GetAll()
        {
            return dataList;
        }

        public IList<LocationReportView> GetLocationReport()
        {
            IList<LocationReportView> list = new List<LocationReportView>();

            return list;
        }
    }
}
