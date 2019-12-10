using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IData, Data>();
            services.AddScoped<LogActionFilterAttribute>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "TravelerRoute",
                    pattern: "{controller}/{action}/{name}",
                    constraints: new { name = "[A-Za-z ]+" },
                    defaults: new { controller = "Traveler", action = "Index", name = "Christian Nagel" });

                routes.MapControllerRoute(
                    name: "defaultRoute",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });

        }
    }
}
