using SebHomeworkTask.Core.DTOs;
using SebHomeworkTask.Infrastructure.Data.Models;

namespace SebHomeworkTask.Application.Mappers;

public static class PollutionSourceMapper
{
    public static PollutionSource Map(PollutionSourceDto dto)
    {
        return new PollutionSource
        {
            Id = dto.Id,
            Address = dto.Address,
            Coord = dto.Coord,
            FormDate = dto.FormDate,
            FormNumber = dto.FormNumber,
            ObjectConditon = dto.ObjectConditon,
            ObjectNumber = dto.ObjectNumber,
            ObjectType = dto.ObjectType,
            Revision = dto.Revision,
            ThreatToEnvironment = dto.ThreatToEnvironment,
            Type = dto.Type,
        };
    }
}