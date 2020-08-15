using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Organiser.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Organiser
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:DefaultConnection"]
                ));
            services.AddMvc();
            services.AddSingleton<IEventsRepository, EFEventsRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            SeedData.Seed(app);
        }
    }
}
