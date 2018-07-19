using Fab.IOProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace FabioWebProject
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      var connection = @"Server=(local);Database=FabIO;Trusted_Connection=True;";
      services.AddDbContext<FabioDbContext>(options => options.UseSqlServer(connection));

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Authenticated", policy => policy.RequireClaim("Id"));
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
           !Path.HasExtension(context.Request.Path.Value) &&
           !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });
      app.UseCookieAuthentication(new CookieAuthenticationOptions()
      {
        AccessDeniedPath = "/login",
        AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
        AutomaticAuthenticate = true,
        AutomaticChallenge = false,
        LoginPath = "/login"
      });
      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
