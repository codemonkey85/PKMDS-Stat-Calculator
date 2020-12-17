using PokemonApiHelper.Models.Types;
using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class PokemonType
    {
        [JsonPropertyName("slot")]
        public int Slot
        {
            get; set;
        }

        [JsonPropertyName("type")]
        public Type Type
        {
            get; set;
        }
    }
}
