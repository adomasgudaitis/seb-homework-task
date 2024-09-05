namespace SebHomeworkTask.API.ViewModels;

public class GroupedPollutionSourcesResponse
{
    public string ObjectType { get; set; }
    public int Count { get; set; }
    public IEnumerable<PollutionSourceResponse> PollutionSources { get; set; } = [];
}