using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Abilities
{
    public class Ability
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
