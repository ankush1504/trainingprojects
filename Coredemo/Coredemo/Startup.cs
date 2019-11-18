using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Coredemo.Models;

namespace Coredemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //FileServerOptions def = new FileServerOptions();
            //def.DefaultFilesOptions.DefaultFileNames.Clear();
            //def.DefaultFilesOptions.DefaultFileNames.Add("Samplepage.html");
            //DefaultFilesOptions def = new DefaultFilesOptions();
            //def.DefaultFileNames.Clear();
            //def.DefaultFileNames.Add("Samplepage.html");
            //app.UseDefaultFiles(def);
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{Controller=Home}/{action=Index}/{id?}");
            });

           
            //app.UseFileServer(def);


            //app.Use(async (samplecontext, next) =>
            //{
            //    await samplecontext.Response.WriteAsync("middleware1 \n");
            //    await next();
            //});
            //app.Use(async (samplecontext1,next) =>
            //{
            //    await samplecontext1.Response.WriteAsync("middleware2 \n");
            //    await next();
            //});

            app.Run(async (context) =>
            {
                //throw new Exception("some error");

                await context.Response.WriteAsync(_configuration["MyKey"].ToString());
            });
        }
    }
}
