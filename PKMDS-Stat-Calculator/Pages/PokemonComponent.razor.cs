using Microsoft.AspNetCore.Components;
using PokeApiNet;

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
