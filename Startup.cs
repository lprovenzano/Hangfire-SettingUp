using Hangfire;
using Jobs.Tier;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hangfire_SettingUp
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
            services.AddHangfire(x => x.UseSqlServerStorage(@"Server=localhost\SQLEXPRESS02;Database=hangfiretest;Trusted_Connection=True;"));
            services.AddHangfireServer();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ITestJob, TestJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IRecurringJobManager recurringJobManager, ITestJob job)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireDashboard();
            app.UseMvc();

            recurringJobManager.AddOrUpdate("created-by-hand", () => Console.WriteLine("created by hand!"), Cron.Minutely); //One job
            job.EnqueueJobs(); //Bulk
        }


    }
}
