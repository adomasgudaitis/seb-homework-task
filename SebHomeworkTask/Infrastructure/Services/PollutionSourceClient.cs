using SebHomeworkTask.Core.DTOs;
using SebHomeworkTask.Core.Exceptions;

namespace SebHomeworkTask.Infrastructure.Services;

public class PollutionSourceClient : IPollutionSourceClient
{
    private readonly HttpClient _client;
    private readonly ILogger<PollutionSourceClient> _logger;

    private readonly string _apiEndpointUrl;

    public PollutionSourceClient(HttpClient client, ILogger<PollutionSourceClient> logger,
        IConfiguration configuration)
    {
        _client = client;
        _logger = logger;
        _apiEndpointUrl = configuration["PollutionSourceApiUrl"] ??
                       throw new KeyNotFoundException("PollutionSourceApiUrl is missing in configuration");
    }

    public async Task<PollutionSourceResponseDto> FetchData()
    {
        try
        {
            _logger.LogInformation("Fetching Sources of Pollution Data");

            var response = await _client.GetAsync(_apiEndpointUrl);
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