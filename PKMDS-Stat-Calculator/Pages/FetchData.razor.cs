using PokemonApiHelper;
using PokemonApiHelper.Models.Pokemon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private readonly IList<Pokemon> pokemonList = new List<Pokemon>();

        protected override async Task OnInitializedAsync()
        {
            await foreach (Pokemon pokemon in PokeApiHelper.GetMultiplePokemon(5).GetAsyncEnumerator())
            {
                pokemonList.Add(pokemon);
            }
        }
    }
}
