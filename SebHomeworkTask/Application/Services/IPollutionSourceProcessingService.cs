using SebHomeworkTask.Application.DTOs;

namespace SebHomeworkTask.Application.Services;

public interface IPollutionSourceProcessingService
{
    Task<IEnumerable<GroupedPollutionSourcesDto>> RetrieveGroupedData();
}