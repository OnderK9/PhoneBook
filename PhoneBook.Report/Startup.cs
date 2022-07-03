using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneBook.Core;
using PhoneBook.Report.Business;
using PhoneBook.Report.Data;
using PhoneBook.Report.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PhoneBook.Report
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppParameters.PersonApiService = Configuration.GetValue<string>("Services:PersonApiService");
            Assembly[] autoMapperList = new Assembly[] { typeof(MappingProfile).Assembly };
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(autoMapperList);

            services.AddDbContext<PhoneBookContext>(opts =>
                    opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        options => options.MigrationsAssembly("PhoneBook.Report.Data")));

            services.AddReportServices();
            services.AddControllers();
            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Report", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Report v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.CustomExceptionMiddleware();// serviste oluþacak hatalarýn loglanmasý için

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
