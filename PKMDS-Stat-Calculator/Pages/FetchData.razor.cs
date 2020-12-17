using PokemonApiHelper;
using PokemonApiHelper.Models.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private IList<Pokemon> pokemonList = new List<Pokemon>();

        private IList<string> pokemonNames = new List<string>();

        private string selectedPokemon = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await foreach (string pokemonName in PokeApiHelper.GetAllPokemonNames())
            {
                pokemonNames.Add(pokemonName);
            }

            pokemonNames = pokemonNames.OrderBy(p => p).ToList();
        }

        private async Task ButtonClicked()
        {
            if (!string.IsNullOrEmpty(selectedPokemon))
            {
                pokemonList.Add(await PokeApiHelper.GetSinglePokemon(selectedPokemon));
            }
        }
    }
}
