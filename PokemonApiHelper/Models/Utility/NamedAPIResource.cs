using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Utility
{
    public class NamedAPIResource
    {
        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }

        [JsonPropertyName("url")]
        public string Url
        {
            get; set;
        }
    }
}
