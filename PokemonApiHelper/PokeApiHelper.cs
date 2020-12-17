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

        public static async IAsyncEnumerator<Pokemon> GetMultiplePokemon(int limit = 0, int offset = 0)
        {
            UriBuilder urlBuilder = new UriBuilder(@$"{pokeApiUrl}pokemon");
            NameValueCollection queryString = HttpUtility.ParseQueryString(urlBuilder.Query);
            if (limit > 0)
            {
                queryString[nameof(limit)] = limit.ToString();
            }
            if (offset > 0)
            {
                queryString[nameof(offset)] = offset.ToString();
            }
            urlBuilder.Query = queryString.ToString();

            NamedApiResourceList resourceList = await HttpClient.GetFromJsonAsync<NamedApiResourceList>(urlBuilder.ToString());
            foreach (NamedApiResource resource in resourceList.Results)
            {
                yield return await HttpClient.GetFromJsonAsync<Pokemon>(resource.Url);
            }
        }
    }
}
