using AutoMapper;
using PhoneBook.Core;
using PhoneBook.Core.Helper;
using PhoneBook.Core.RabbitMQ;
using PhoneBook.Core.View;
using PhoneBook.Report.Data;
using PhoneBook.Report.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Report.Business
{
    public class ReportService : IReportService
    {
        IMapper _mapper;
        IReportRepository _repository;
        public ReportService(IReportRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResultView Create()
        {
            ServiceResultView result = new ServiceResultView();
            dbReport report = new dbReport()
            {
                UUID = Guid.NewGuid(),
                RequestDate = DateTime.Now,
                Status = EnumReportStatus.Waiting
            };

            _repository.Add(report);
            result.IsSucceed = _repository.SaveChanges();
            if (result.IsSucceed == true)
            {
                RabbitMq.SendMessage(report.UUID.ToString());
                result.Data = _mapper.Map<ReportView>(report);
            }

            return result;
        }

        public ServiceResultView Get(Guid id)
        {
            ServiceResultView result = new ServiceResultView();
            result.IsSucceed = true;

            dbReport report = _repository.Get(id);

            ReportView view = _mapper.Map<ReportView>(report);

            result.Data = view;

            return result;
        }


        public IEnumerable<ReportView> GetAll()
        {
            return _mapper.Map<IEnumerable<ReportView>>(_repository.GetAll());
        }

        /// <summary>
        /// Rapor kayıtları için rapor dosyasını oluşturur.
        /// Person servisine istekte bulunarak verileri alır
        /// Bu verileri csv formatında kaydeder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResultView ProcessReport(Guid id)
        {
            ServiceResultView result = new ServiceResultView();

            dbReport report = _repository.Get(id);
            //İşleme başlarken status değiştiriliyor
            report.Status = EnumReportStatus.InProgress;
            _repository.SaveChanges();

            string url = Path.Combine(AppParameters.PersonApiService, "report/location");
            HttpHelper http = new HttpHelper();
            IEnumerable<LocationReportView> list = http.Get<IEnumerable<LocationReportView>>(url).Result;
            if (list != null && list.Count() > 0)
            {
                result.IsSucceed = true;
                report.Status = EnumReportStatus.Done;
                string columns = "Location,PersonCount,PhoneCount";
                string path = "storage/report/csv/";
                string folder = Path.Combine(Directory.GetCurrentDirectory(), path);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string fileUrl = folder + report.UUID + ".csv";

                FileHelper.SaveCSV(list, columns, fileUrl);
                report.FileUrl = path + report.UUID + ".csv";
            }
            else
            {
                report.Status = EnumReportStatus.NoData;
            }
            _repository.SaveChanges();

            result.Data = _mapper.Map<ReportView>(report);

            return result;
        }

    }
}
