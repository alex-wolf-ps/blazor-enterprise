using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.UI.Data;

namespace BethanysPieShopHRM.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            
            services.AddScoped<HttpClient>(s =>
            {
                var client = new HttpClient { BaseAddress = new System.Uri("https://localhost:44340/") }; 
                return client;
            });

            services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            services.AddTransient<ICountryDataService, CountryDataService>();
            services.AddTransient<IJobCategoryDataService, JobCategoryDataService>();
            services.AddTransient<IExpenseDataService, ExpenseDataService>();
            services.AddTransient<ITaskDataService, TaskDataService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISurveyDataService, SurveyDataService>();
            services.AddTransient<ICurrencyDataService, CurrencyDataService>();
            services.AddTransient<IExpenseApprovalService, ManagerApprovalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
