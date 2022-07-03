using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Business
{
    public class ReportView
    {
        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public int Status { get; set; }
        public string FileUrl { get; set; }
    }
}
