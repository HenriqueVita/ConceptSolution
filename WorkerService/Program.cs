namespace WorkerService;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WorkerService.Infrastructure;
using WorkerService.Domain;
using Hangfire;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHangfire(config => { config.UseSqlServerStorage("Server=localhost\\mssqlserver_1;Database=testeAPI;Integrated Security=True;TrustServerCertificate=True;"); });
                services.AddHangfireServer();
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=localhost\\mssqlserver_1;Database=testeAPI;Integrated Security=True;TrustServerCertificate=True;"));  
                //Infrastructure recurring service.
                services.AddScoped<IPedidoRepository, PedidoRepository>();
                services.AddTransient<IPedidoService, PedidoService>();
                services.AddHostedService<Worker>();                
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapHangfireDashboard();
                    });
                });
            });      
}
