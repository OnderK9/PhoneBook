using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Data.Repository
{
    public class ReportRepository : Repository<dbReport>, IReportRepository
    {

        public ReportRepository(PhoneBookContext context) : base(context)
        {

        }

        public void Add(dbReport report)
        {
            Insert(report);
        }
        public dbReport Get(Guid id)
        {
            return base.GetFirst(x => x.UUID == id);
        }
        public IEnumerable<dbReport> GetAll()
        {
            return base.GetAll();
        }
    }
}
