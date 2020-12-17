using System.Text.Json.Serialization;
using PokemonApiHelper.Models.Stats;
using PokemonApiHelper.Models.Utility;

namespace PokemonApiHelper.Models.Natures
{
    public class Nature
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

        [JsonPropertyName("decreased_stat")]
        public NamedApiResource<Stat> DecreasedStat
        {
            get; set;
        }

        [JsonPropertyName("increased_stat")]
        public NamedApiResource<Stat> IncreasedStat
        {
            get; set;
        }
    }
}
