using System.Text.Json.Serialization;

public class Farmaco
{
    [JsonPropertyName("numero")]
    public string? Numero { get; set; }

    [JsonPropertyName("farmaco")]
    public string? FarmacoNombre { get; set; }

    [JsonPropertyName("formaFarmaceutica")]
    public string? FormaFarmaceutica { get; set; }

    [JsonPropertyName("concentracion")]
    public string? Concentracion { get; set; }

    [JsonPropertyName("registroSanitario")]
    public string? RegistroSanitario { get; set; }

    [JsonPropertyName("titular")]
    public string? Titular { get; set; }

    [JsonPropertyName("indicacionTerapeuticas")]
    public string? IndicacionTerapeuticas { get; set; }
}
