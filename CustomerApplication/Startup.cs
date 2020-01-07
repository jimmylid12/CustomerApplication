using CustomerApplication.Models.OrderHistory;
using CustomerApplication.Models.Product;
using CustomerApplication.Models.Review;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterApplication.Services;

namespace CustomerApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _env = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment _env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            if (_env.IsDevelopment())
            {
                services.AddTransient<IRegisterService, FakeRegisterService>();
            }
            else
            {
                services.AddHttpClient<IRegisterService, RegisterService>();
            }

            //services.AddDbContext<RegistrationContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("registrationContext")));

            services.AddDbContext<ProductContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("productContext")));

            services.AddDbContext<ReviewContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("reviewContext")));


            services.AddDbContext<OrderHistoryContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("orderhistoryContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
