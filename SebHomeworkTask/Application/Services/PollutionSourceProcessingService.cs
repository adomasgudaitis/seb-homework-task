using SebHomeworkTask.Application.DTOs;
using SebHomeworkTask.Application.Mappers;
using SebHomeworkTask.Infrastructure.Data;

namespace SebHomeworkTask.Application.Services;

public class PollutionSourceProcessingService : IPollutionSourceProcessingService
{
    private readonly IPollutionSourceRepository _pollutionSourceRepository;

    public PollutionSourceProcessingService(IPollutionSourceRepository pollutionSourceRepository)
    {
        _pollutionSourceRepository = pollutionSourceRepository;
    }

    public async Task<IEnumerable<GroupedPollutionSourcesDto>> RetrieveGroupedData()
    {
        var data = await _pollutionSourceRepository.GetAll();
        var groupedData = data.GroupBy(x => x.ObjectType).Select(group => new GroupedPollutionSourcesDto
        {
            ObjectType = group.Key,
            Count = group.Count(),
            PollutionSources = group
        });

        return groupedData;
    }
}