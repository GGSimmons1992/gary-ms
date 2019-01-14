using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MVCWorld.Client
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//Sets up MiddleWare
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//Turns on MiddleWare
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc(routes =>
            //routes
            //.MapRoute("omni", "{controller=Home}/{action=Index}/{id?}")//all paths
            //.MapRoute("spec2", "banana/{controller=DespicableMe}")// Default banana controller
            //.MapRoute("specific", "banana/{controller=Minion}"));//never seen due to default banana controller

            app.UseMvc();
            app.UseWelcomePage();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            
            
        }
    }
}
