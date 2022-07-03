using PhoneBook.Core.View;
using PhoneBook.Report.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Test.Service
{
    public class ReportServiceFake : IReportService
    {
        private readonly List<ReportView> dataList;

        public ReportServiceFake()
        {
            dataList = new List<ReportView>()
            {
                new ReportView() {
                    UUID =new Guid( "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    FileUrl ="",
                    RequestDate= DateTime.Now,
                    Status=1
                },
                new ReportView() {
                    UUID =new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"),
                    FileUrl ="",
                    RequestDate= DateTime.Now,
                    Status=3
                }
            };
        }

        public ServiceResultView Create()
        {
            ReportView view = new ReportView()
            {
                UUID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                FileUrl = "",
                RequestDate = DateTime.Now,
                Status = 1
            };
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

        public ServiceResultView ProcessReport(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            return result;
        }

        public IEnumerable<ReportView> GetAll()
        {
            return dataList;
        }

    }
}
