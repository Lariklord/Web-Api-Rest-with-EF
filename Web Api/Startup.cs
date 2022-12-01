using Data;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    private readonly IConfiguration Configuration;
    private readonly IWebHostEnvironment env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.Configuration = configuration;
        this.env = env;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration.GetConnectionString("TestDatabase")!;
        services.AddControllers();
        services.AddDbContext<WebApiContext>(s => s.UseSqlServer(connectionString));
        services.AddScoped<IRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<CurrentWeather>, WeatherRepository>();
 
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>{
            endpoints.MapControllers();
        });
    }
}