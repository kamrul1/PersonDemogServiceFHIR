using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PersonDemogServiceFHIR.WebUI.Api.Responses
{

    public record Patch
    {
        [JsonPropertyName("op")]
        public string Op { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("value")]
        public object Value { get; set; }
    }

    public record PatientDodNotifyResponse
    {
        [JsonPropertyName("patches")]
        public List<Patch> Patches { get; } = new List<Patch>();
    }
}