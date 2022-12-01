using Data;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web_Api;

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
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
        //IoCContainer.Register<IRepository<Customer>, CustomerRepository>();
        //IoCContainer.Register<IRepository<CurrentWeather>, WeatherRepository>();
 
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        });
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        //app.UseHttpsRedirection();
        app.UseEndpoints(endpoints =>{
            endpoints.MapControllers();
        });
    }
}