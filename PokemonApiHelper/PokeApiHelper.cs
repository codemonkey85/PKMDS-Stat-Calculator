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

        public static async IAsyncEnumerator<Pokemon> GetMultiplePokemon(int limit = -1, int offset = 0)
        {
            UriBuilder urlBuilder = new UriBuilder(@$"{pokeApiUrl}pokemon");
            NameValueCollection queryString = HttpUtility.ParseQueryString(urlBuilder.Query);
            queryString[nameof(limit)] = limit.ToString();
            if (offset > 0)
            {
                queryString[nameof(offset)] = offset.ToString();
            }
            urlBuilder.Query = queryString.ToString();

            NamedApiResourceList<Pokemon> resourceList = await HttpClient.GetFromJsonAsync<NamedApiResourceList<Pokemon>>(urlBuilder.ToString());
            foreach (NamedApiResource<Pokemon> resource in resourceList.Results)
            {
                yield return await HttpClient.GetFromJsonAsync<Pokemon>(resource.Url);
            }
        }

        public static async IAsyncEnumerator<string> GetAllPokemonNames()
        {
            NamedApiResourceList<Pokemon> resourceList = await HttpClient.GetFromJsonAsync<NamedApiResourceList<Pokemon>>(@$"{pokeApiUrl}pokemon?limit=-1");
            foreach (NamedApiResource<Pokemon> resource in resourceList.Results)
            {
                yield return resource.Name;
            }
        }

        public static async Task<T> GetApiResource<T>(NamedApiResource<T> namedApiResource) => await HttpClient.GetFromJsonAsync<T>(namedApiResource.Url);
    }
}
