using System.ComponentModel.DataAnnotations;

namespace SebHomeworkTask.Infrastructure.Data.Models;

public class PollutionSource
{
    [Key]
    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Revision { get; set; }

    public int ObjectNumber { get; set; }

    public string Address { get; set; }

    public string FormNumber { get; set; }
    
    public DateTime FormDate { get; set; }

    public string ObjectConditon { get; set; }

    public string ObjectType { get; set; }

    public string ThreatToEnvironment { get; set; }
    
    public string Coord { get; set; }
}