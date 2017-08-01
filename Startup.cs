using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogList
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
      .SetBasePath(env.ContentRootPath)
      .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }


    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();
      app.UseDeveloperExceptionPage();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
        });
      }
    }

    public static class DBConfiguration
    {
      public static string ConnectionString = "Server=localhost;Database=doglist;User Id=sa;Password=Epic0dus";
    }
  }
