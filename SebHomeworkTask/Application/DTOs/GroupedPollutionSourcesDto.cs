using SebHomeworkTask.Infrastructure.Data.Models;

namespace SebHomeworkTask.Application.DTOs;

public class GroupedPollutionSourcesDto
{
    public string ObjectType { get; set; }
    public int Count { get; set; }
    public IEnumerable<PollutionSource> PollutionSources { get; set; }
}