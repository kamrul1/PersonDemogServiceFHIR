using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PersonDemogServiceFHIR.WebUI.Api
{


    public record Coding
    {
        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("display")]
        public string Display { get; set; }
    }

    public record ValueCodeableConcept
    {
        [JsonPropertyName("coding")]
        public List<Coding> Coding { get; } = new List<Coding>();
    }

    public record Extension
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("valueCodeableConcept")]
        public ValueCodeableConcept ValueCodeableConcept { get; set; }

        [JsonPropertyName("valueDateTime")]
        public DateTime? ValueDateTime { get; set; }

    }


    public record Security
    {
        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("display")]
        public string Display { get; set; }
    }

    public record Meta
    {
        [JsonPropertyName("versionId")]
        public int VersionId { get; set; }

        [JsonPropertyName("security")]
        public List<Security> Security { get; } = new List<Security>();
    }

    public record PatientDodNotifyRequest
    {
        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }


        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("extension")]
        public List<Extension> Extension { get; } = new List<Extension>();

        [JsonPropertyName("deceasedDateTime")]
        public string DeceasedDateTime { get; set; }
    }

}