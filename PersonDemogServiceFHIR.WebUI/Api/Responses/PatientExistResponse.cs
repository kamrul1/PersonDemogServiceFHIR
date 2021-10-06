using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonDemogServiceFHIR.WebUI.Api.Responses
{
    public record PatientExistResponse
    {
        [JsonPropertyName("name")]
        public List<NameResponse> Name { get; init; }

        [JsonPropertyName("gender")]
        public string Gender { get; init; }

        [JsonPropertyName("address")]
        public List<AddressResponse> Address { get; set; }


    }

    public record AddressResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("use")]
        public string Use { get; set; }

        [JsonPropertyName("line")]
        public List<string> Line { get; init; } 

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public record NameResponse
    {
        [JsonPropertyName("given")]
        public List<string> Given { get; init; }

        [JsonPropertyName("family")]
        public string Family { get; init; }

        [JsonPropertyName("prefix")]
        public List<string> Prefix { get; init; }
    }
}
