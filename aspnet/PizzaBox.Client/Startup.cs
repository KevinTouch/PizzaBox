using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaBox.Storing;

namespace PizzaBox.Client
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
      services.AddControllersWithViews();
      services.AddDbContext<PizzaBoxContext>(
        options => options.UseSqlServer(Configuration.GetConnectionString("sqlserver"), opts =>
        {
          opts.EnableRetryOnFailure(2);
        })
      );
      services.AddScoped<PizzaBoxRepository>();
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
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      // app.UseHttpsRedirection();
      // app.UseStaticFiles();

      app.UseRouting();

      // app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // Attribute Routing for REST APIs
        // - Requires more input to specify a route. The conventional default handles
        // routes more succinctly. However, attribute routing allows and requires precise
        // control of which route templates apply to each action
        endpoints.MapControllers();

        // Conventional Routing
        // - Establishes a convention for URL paths
        // - Using conventional routing with the default route allows creating
        // the app without having to come up with a new URL pattern for each action.

        // endpoints.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}"
        // );

      });
    }
  }
}
