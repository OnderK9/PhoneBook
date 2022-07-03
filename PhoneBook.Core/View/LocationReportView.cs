using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.View
{
    public class LocationReportView
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public override string ToString()
        {
            return Location + "," + PersonCount + "," + PhoneCount;
        }
    }
}
