using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class PokemonForm
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
