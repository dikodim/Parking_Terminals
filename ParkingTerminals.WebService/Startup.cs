using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingTerminals.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase;
using ParkingTerminals.ApplicationServices.Ports.Gateways.Database;
using ParkingTerminals.ApplicationServices.Repositories;
using ParkingTerminals.DomainObjects.Ports;

namespace ParkingTerminals.WebService
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
            services.AddDbContext<PurkingTerminalContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "ParkingTerminals.db")}")
            );

            services.AddScoped<IParkingTerminalDatabaseGateway, ParkingTerminalEFSqliteGateway>();

            services.AddScoped<DbParkingTerminalRepository>();
            services.AddScoped<IReadOnlyParkingTerminalRepository>(x => x.GetRequiredService<DbParkingTerminalRepository>());
            services.AddScoped<IParkingTerminalRepository>(x => x.GetRequiredService<DbParkingTerminalRepository>());

 
            services.AddScoped<IGetParkingTerminalListUseCase, GetParkingTerminalListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
