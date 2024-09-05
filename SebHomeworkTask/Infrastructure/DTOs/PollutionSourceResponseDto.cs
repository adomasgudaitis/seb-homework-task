using System.Text.Json.Serialization;

namespace SebHomeworkTask.Core.DTOs;

public class PollutionSourceResponseDto
{
    [JsonPropertyName("_data")] public IEnumerable<PollutionSourceDto> Data { get; set; } = [];
}