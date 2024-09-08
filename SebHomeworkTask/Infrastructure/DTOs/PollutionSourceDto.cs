using System.Text.Json.Serialization;

namespace SebHomeworkTask.Core.DTOs;

// Source of pollution = Taršos židinys
public class PollutionSourceDto
{
    [JsonPropertyName("_id")] public Guid Id { get; set; }

    [JsonPropertyName("_type")] public string Type { get; set; }

    [JsonPropertyName("_revision")] public string Revision { get; set; }

    [JsonPropertyName("objecto_nr")] public int ObjectNumber { get; set; }

    [JsonPropertyName("ptz_adresas")] public string Address { get; set; }

    [JsonPropertyName("ptz_anketos_nr")] public string FormNumber { get; set; }

    [JsonPropertyName("ptz_anketos_data")] public DateTime FormDate { get; set; }

    [JsonPropertyName("ptz_objekto_bukle")]
    public string ObjectConditon { get; set; }

    [JsonPropertyName("ptz_objekto_tipas")]
    public string ObjectType { get; set; }

    [JsonPropertyName("ptz_pavojingumas_aplinkai")]
    public string ThreatToEnvironment { get; set; }

    [JsonPropertyName("koord")] public string Coord { get; set; }
}