using SebHomeworkTask.Core.DTOs;
using SebHomeworkTask.Core.Exceptions;

namespace SebHomeworkTask.Infrastructure.Services;

public class PollutionSourceService : IPollutionSourceService
{
    private readonly HttpClient _client;
    private readonly ILogger<PollutionSourceService> _logger;

    private const string ApiEndpoint =
        "https://get.data.gov.lt/datasets/gov/lgt/potencialus_tarsos_zidiniai/TarsosZidinys/:format/json";

    public PollutionSourceService(HttpClient client, ILogger<PollutionSourceService> logger)
    {
        _client = client;
        _logger = logger;
    }
    
    public async Task<PollutionSourceResponseDto> FetchData()
    {
        try
        {
            _logger.LogInformation("Fetching Sources of Pollution Data");
        
            var response = await _client.GetAsync(ApiEndpoint);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<PollutionSourceResponseDto>();

            return data;
        }
        catch (HttpRequestException e)
        {
            _logger.Log(LogLevel.Error, e, "Fetching Sources of Pollution Data has failed");
            throw new ExternalApiException("Failed to fetch Pollution Sources from the external API");
        }
    }
}