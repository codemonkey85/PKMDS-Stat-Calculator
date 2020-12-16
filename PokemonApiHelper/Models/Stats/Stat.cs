using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Stats
{
    public class Stat
    {
        [JsonPropertyName("id")]
        public int Id
        {
            get; set;
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }
    }
}
