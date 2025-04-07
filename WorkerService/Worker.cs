namespace WorkerService;

using Hangfire;
using WorkerService.Infrastructure;

public class Worker : BackgroundService
{
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly IServiceProvider _serviceProvider;

    public Worker(IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
    {
        _recurringJobManager = recurringJobManager;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _recurringJobManager.AddOrUpdate(
            "upsert-job",
            () => GerarPedidosTeste(),
            "*/1 * * * *");

        await Task.CompletedTask;

        _recurringJobManager.AddOrUpdate(
            "upsert-job",
            () => ProcessaPedidos(),
            Cron.Hourly);

        await Task.CompletedTask;
    }

    public void ProcessaPedidos()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var pedidoService = scope.ServiceProvider.GetRequiredService<IPedidoService>();
            pedidoService.ProcessaPedidosAsync().Wait();
        }
    }

    public void GerarPedidosTeste()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var pedidoService = scope.ServiceProvider.GetRequiredService<IPedidoService>();
            pedidoService.ProcessaPedidosAsync().Wait();
        }
    }
}