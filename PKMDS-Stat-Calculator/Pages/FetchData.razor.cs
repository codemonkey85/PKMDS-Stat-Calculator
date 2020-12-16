using PokemonApiHelper.Models.Pokemon;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private IEnumerable<Pokemon> pokemon = null;

        protected override async Task OnInitializedAsync()
        {
            pokemon = await PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(1);
        }
    }
}
