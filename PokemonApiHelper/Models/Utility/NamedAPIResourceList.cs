using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Utility
{
    public class NamedApiResourceList
    {
        [JsonPropertyName("count")]
        public int Count
        {
            get; set;
        }

        [JsonPropertyName("next")]
        public string Next
        {
            get; set;
        }

        [JsonPropertyName("previous")]
        public bool? Previous
        {
            get; set;
        }

        [JsonPropertyName("results")]
        public NamedApiResource[] Results
        {
            get; set;
        }
    }
}
