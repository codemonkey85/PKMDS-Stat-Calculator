using Microsoft.AspNetCore.Components;
using PokemonApiHelper.Models.Pokemon;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class PokemonComponent
    {
        [Parameter]
        public Pokemon Pokemon
        {
            get; set;
        }
    }
}
