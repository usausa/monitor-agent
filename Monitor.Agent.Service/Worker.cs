namespace Monitor.Agent.Service;

public sealed class Worker : BackgroundService
{
    private readonly ILogger<Worker> log;

    public Worker(ILogger<Worker> log)
    {
        this.log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (log.IsEnabled(LogLevel.Information))
            {
                log.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
