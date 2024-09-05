using SebHomeworkTask.Application.Mappers;
using SebHomeworkTask.Infrastructure.Data;
using SebHomeworkTask.Infrastructure.Services;

namespace SebHomeworkTask.Application.Services;

public class PollutionSourceBackgroundService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly ILogger<PollutionSourceBackgroundService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public PollutionSourceBackgroundService(ILogger<PollutionSourceBackgroundService> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.Now;
        var scheduledTimeString = _configuration["DataFetchScheduledTime"] ?? "01:00";
        var scheduledTime = DateTime.Parse(scheduledTimeString);
        var nextRun = new DateTime(now.Year, now.Month, now.Day, scheduledTime.Hour, scheduledTime.Minute, scheduledTime.Second, 0, DateTimeKind.Local);

        if (now > nextRun)
        {
            nextRun = nextRun.AddDays(1);
        }
        
        var delay = nextRun - now;

        _timer = new Timer(FetchAndStoreData, null, delay, TimeSpan.FromHours(24));
        
        return Task.CompletedTask;
    }

    private async void FetchAndStoreData(object? state)
    {
        using var scope = _serviceProvider.CreateScope();
        var pollutionSourceService = scope.ServiceProvider.GetRequiredService<IPollutionSourceClient>();
        var pollutionSourceRepository = scope.ServiceProvider.GetRequiredService<IPollutionSourceRepository>();

        _logger.LogInformation($"BackGround Service is starting at {_configuration["DataFetchScheduledTime"]}");
        var data = await pollutionSourceService.FetchData();
        await pollutionSourceRepository.AddRange(data.Data.Select(PollutionSourceMapper.Map));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
        
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}