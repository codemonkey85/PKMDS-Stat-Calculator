using PokemonApiHelper.Models.Stats;
using System.Text.Json.Serialization;

namespace PokemonApiHelper.Models.Pokemon
{
    public class PokemonStat
    {
        [JsonPropertyName("stat")]
        public Stat Stat
        {
            get; set;
        }

        [JsonPropertyName("effort")]
        public int Effort
        {
            get; set;
        }

        [JsonPropertyName("base_stat")]
        public int BaseStat
        {
            get; set;
        }
    }
}
