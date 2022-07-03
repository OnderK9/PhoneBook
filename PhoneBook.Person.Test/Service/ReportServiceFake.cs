using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Test.Service
{
    public class ReportServiceFake : IReportService
    {
        private readonly List<LocationReportView> dataList;

        public ReportServiceFake()
        {
            dataList = new List<LocationReportView>()
            {
                new LocationReportView() {
                    Location="konum1",
                    PersonCount=1,
                    PhoneCount=1
                },
                new LocationReportView() {
                    Location="konum2",
                    PersonCount=2,
                    PhoneCount=2
                },
                new LocationReportView() {
                    Location="konum3",
                    PersonCount=3,
                    PhoneCount=3
                }
            };
        }

        public IList<LocationReportView> GetLocationReport()
        {
            return dataList;
        }

    }
}
