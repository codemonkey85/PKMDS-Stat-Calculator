using PokemonApiHelper.Models.Pokemon;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private IList<Pokemon> pokemon = new List<Pokemon>();

        protected override async Task OnInitializedAsync()
        {
            //var p = await PokemonApiHelper.PokeApiHelper.GetSinglePokemon("dragonite");
            //pokemon.Add(p);
            //await foreach (var item in PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(5).GetAsyncEnumerator())
            //{
            //    //Console.WriteLine(item);
            //}
            //pokemon = (await PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(5)).ToList();
            await foreach (var item in PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(5).GetAsyncEnumerator())
            {
                pokemon.Add(item);
            }
        }
    }

    internal static class Extensions
    {
        public static IAsyncEnumerator<T> GetAsyncEnumerator<T>(this IAsyncEnumerator<T> enumerator) => enumerator;
    }
}
