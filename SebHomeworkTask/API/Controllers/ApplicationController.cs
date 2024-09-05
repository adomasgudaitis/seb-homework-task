using Microsoft.AspNetCore.Mvc;
using SebHomeworkTask.API.Mappers;
using SebHomeworkTask.Application.DTOs;
using SebHomeworkTask.Application.Services;

namespace SebHomeworkTask.API.Controllers;

[ApiController]
[Route("/api/v1/source-of-pollution")]
public class ApplicationController : ControllerBase
{
    private readonly IPollutionSourceProcessingService _pollutionSourceProcessingService;

    public ApplicationController(IPollutionSourceProcessingService pollutionSourceProcessingService)
    {
        _pollutionSourceProcessingService = pollutionSourceProcessingService;
    }

    // Added a mandatory query parameter 'name'
    // to simulate the BadRequest scenario for showing the use of a custom middleware
    [HttpGet(Name = "GettingPollutionSources")]
    public async Task<ActionResult<IEnumerable<GroupedPollutionSourcesDto>>> GetPollutionSources(
        [FromQuery] string name)
    {
        Console.WriteLine($"Getting pollution sources for {name}");
        var data = await _pollutionSourceProcessingService.RetrieveGroupedData();
        var responseBody = PollutionSourcesResponseMapper.Map(data);
        return Ok(responseBody);
    }
}