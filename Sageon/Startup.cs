using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sageon.Models;
using Microsoft.EntityFrameworkCore;


namespace Sageon
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
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient < ISopRepository, EFSopRepository>();
            services.AddControllersWithViews();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
             app.UseEndpoints(endpoints =>
             {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Sops}/{action=SinginPage}/{id?}");
             }); // execute that route
            //SopSeedClass.EnsurePopulated(app);
        }
            //UseRouting: Matches request to an endpoint.    UseEndpoints: Execute the matched endpoint.
    }
}
