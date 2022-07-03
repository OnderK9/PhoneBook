using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Business;
using PhoneBook.Report.Data;
using PhoneBook.Report.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Test
{
    public class ReportRepositoryFake : IReportRepository
    {
        public List<dbReport> DataList = new List<dbReport>();
        public ReportRepositoryFake()
        {
            DataList.Add(new dbReport()
            {
                UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                FileUrl = "",
                RequestDate = DateTime.Now,
                Status = EnumReportStatus.Waiting
            });
        }
        public bool SaveChanges()
        {
            return true;
        }

        public void Add(dbReport person)
        {
            DataList.Add(person);
        }

        public dbReport Get(Guid id)
        {
            return DataList.FirstOrDefault(x => x.UUID == id);
        }

        public void Delete(Guid id)
        {
            DataList.Remove(DataList.FirstOrDefault(x => x.UUID == id));
        }

        public IEnumerable<dbReport> GetAll()
        {
            return DataList;
        }

    }
}
