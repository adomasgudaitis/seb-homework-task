using SebHomeworkTask.Core.DTOs;

namespace SebHomeworkTask.Infrastructure.Services;

public interface IPollutionSourceService
{
    Task<PollutionSourceResponseDto> FetchData();
}