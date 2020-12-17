using PokemonApiHelper.Models.Pokemon;
using PokemonApiHelper.Models.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace PokemonApiHelper
{
    public static class PokeApiHelper
    {
        public static HttpClient HttpClient
        {
            get; set;
        } = new HttpClient();

        private const string pokeApiUrl = @"https://pokeapi.co/api/v2/";

        public static async Task<Pokemon> GetSinglePokemon(string pokemonIdOrName) => await HttpClient.GetFromJsonAsync<Pokemon>(@$"{pokeApiUrl}pokemon/{pokemonIdOrName}");

        public static async Task<IEnumerable<Pokemon>> GetMultiplePokemon(int limit = 0, int offset = 0)
        {
            var pokemonList = new List<Pokemon>();
            UriBuilder builder = new UriBuilder(@$"{pokeApiUrl}pokemon");
            NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
            if (limit > 0)
            {
                query[nameof(limit)] = limit.ToString();
            }
            if (offset > 0)
            {
                query[nameof(offset)] = offset.ToString();
            }
            builder.Query = query.ToString();

            NamedAPIResourceList resourceList = await HttpClient.GetFromJsonAsync<NamedAPIResourceList>(builder.ToString());
            foreach (NamedAPIResource resource in resourceList.Results)
            {
                Pokemon pokemon = await HttpClient.GetFromJsonAsync<Pokemon>(resource.Url);
                //yield return pokemon;
                pokemonList.Add(pokemon);
            }
            return pokemonList;
        }
    }
}
