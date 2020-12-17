using PokemonApiHelper.Models.Abilities;
using PokemonApiHelper.Models.Utility;
using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class PokemonAbility
    {
        [JsonPropertyName("is_hidden")]
        public bool IsHidden
        {
            get; set;
        }

        [JsonPropertyName("slot")]
        public int Slot
        {
            get; set;
        }

        [JsonPropertyName("ability")]
        public NamedApiResource<Ability> Ability
        {
            get; set;
        }
    }
}
