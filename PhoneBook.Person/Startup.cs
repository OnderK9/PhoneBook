using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneBook.Person.Business;
using PhoneBook.Person.Data;
using PhoneBook.Person.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PhoneBook.Person
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
            
            Assembly[] autoMapperList = new Assembly[] { typeof(MappingProfile).Assembly };
            services.AddAutoMapper(autoMapperList);

            services.AddDbContext<PhoneBookContext>(opts =>
                    opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        options => options.MigrationsAssembly("PhoneBook.Person.Data")));

            services.AddPersonServices();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Person", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Person v1"));
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
