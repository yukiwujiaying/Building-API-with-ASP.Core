using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Servieces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddMvcOptions(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            //IMailService is the interface, localMailService is the implementation
            //this told the container 
            //whenever we inject an IMailService in our code, we want it to provide us with the LocalMailService
#if DEBUG
            //if running debug build, use localmailservice
            services.AddTransient<IMailService, LocalMailService>();
#else
            //if running release build, use clouldmailservice
            services.AddTransient<IMailService, CloudMailService>();
#endif
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<CityInfoContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();
            app.UseMvc();

            
        }
    }
}
