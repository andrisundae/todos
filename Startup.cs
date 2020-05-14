using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Livecoding.API.Domain.Repositories;
using Livecoding.API.Domain.Services;
using Livecoding.API.Persistence.Contexts;
using Livecoding.API.Persistence.Repositories;
using Livecoding.API.Services;

namespace Livecoding.API
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
      services.AddMemoryCache();
      // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      services.AddControllers();
      services.AddDbContext<AppDbContext>(options =>
      {
        // options.UseInMemoryDatabase(Configuration.GetConnectionString("memory"));
        options.UseSqlServer(Configuration.GetConnectionString("TodosDatabase"));
      });

      services.AddScoped<IToDoRepository, ToDoRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddScoped<IToDoService, ToDoService>();

      services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
