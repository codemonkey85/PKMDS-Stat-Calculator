using PokemonApiHelper.Models.Utility;
using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class Pokemon
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

        [JsonPropertyName("stats")]
        public PokemonStat[] Stats
        {
            get; set;
        }

        [JsonPropertyName("types")]
        public PokemonType[] Types
        {
            get; set;
        }

        [JsonPropertyName("abilities")]
        public PokemonAbility[] Abilities
        {
            get; set;
        }

        [JsonPropertyName("forms")]
        public NamedApiResource<PokemonForm>[] Forms
        {
            get; set;
        }

        [JsonPropertyName("sprites")]
        public PokemonSprite Sprites
        {
            get; set;
        }
    }
}
