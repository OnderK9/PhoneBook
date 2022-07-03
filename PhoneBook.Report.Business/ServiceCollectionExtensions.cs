using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Report.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Business
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// DependencyInjection için registerlar yapılıyor
        /// </summary>
        /// <param name="services"></param>
        public static void AddReportServices(this IServiceCollection services)
        {
            //repos
            services.AddScoped<IReportRepository, ReportRepository>();
            //services
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
