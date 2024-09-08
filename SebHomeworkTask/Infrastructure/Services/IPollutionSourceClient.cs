using SebHomeworkTask.Core.DTOs;

namespace SebHomeworkTask.Infrastructure.Services;

public interface IPollutionSourceClient
{
    Task<PollutionSourceResponseDto> FetchData();
}