using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Test.Service
{
    public class ContactServiceFake : IContactService
    {
        private readonly List<ContactView> dataList;

        public ContactServiceFake()
        {
            dataList = new List<ContactView>()
            {
                new ContactView() {
                    UUID =new Guid( "ab2bd817-98cd-4cf3-a80a-53ea0cd9c240"),
                    ContactTypeUUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c400" ),
                    Content="1",
                    PersonUUID=new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200" )
                }
            };
        }

        public ServiceResultView Add(ContactView view)
        {
            ServiceResultView result = new ServiceResultView();

            dataList.Add(view);
            result.IsSucceed = true;

            return result;
        }

        public ServiceResultView Delete(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;
            dataList.Remove(dataList.FirstOrDefault(x => x.UUID == id));

            return result;
        }

        public IEnumerable<ContactTypeView> GetContactTypes()
        {
            IList<ContactTypeView> list = new List<ContactTypeView>()
            {
                    new ContactTypeView()
                    {
                        UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                        Name="Email"
                    },
                    new ContactTypeView()
                    {
                        UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c401"),
                        Name="Location"
                    }
            };

            return list;
        }
    }
}
