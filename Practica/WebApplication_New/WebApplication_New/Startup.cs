﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Lib.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication_New
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; //add
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); //add
            services.AddDbContext<AcademyDbContext>(); //add
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
            }
            else //add
            {
                app.UseExceptionHandler("/Home/Error"); //add
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); //add
            }

            app.UseHttpsRedirection(); //add            
            //app.UseDirectoryBrowser(); //let you see the content of the main directory
            app.UseDefaultFiles(); //add
            app.UseStaticFiles(); //add

            app.UseRouting();

            app.UseAuthorization(); //add        

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
