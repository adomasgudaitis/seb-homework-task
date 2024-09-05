using SebHomeworkTask.API.ViewModels;
using SebHomeworkTask.Application.DTOs;

namespace SebHomeworkTask.API.Mappers;

public static class PollutionSourcesResponseMapper
{
    public static IEnumerable<GroupedPollutionSourcesResponse> Map(IEnumerable<GroupedPollutionSourcesDto> dtos)
    {
        return dtos.Select(dto => new GroupedPollutionSourcesResponse
        {
            ObjectType = dto.ObjectType,
            Count = dto.Count,
            PollutionSources = dto.PollutionSources.Select(s => new PollutionSourceResponse
            {
                Id = s.Id,
                Address = s.Address,
                Coord = s.Coord,
                FormDate = s.FormDate,
                FormNumber = s.FormNumber,
                ObjectConditon = s.ObjectConditon,
                ObjectNumber = s.ObjectNumber,
                ObjectType = s.ObjectType,
                Revision = s.Revision,
                ThreatToEnvironment = s.ThreatToEnvironment,
            })
        });
    }
}