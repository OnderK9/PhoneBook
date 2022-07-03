using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Person.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersonServices(this IServiceCollection services)
        {
            //repos
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            //services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
