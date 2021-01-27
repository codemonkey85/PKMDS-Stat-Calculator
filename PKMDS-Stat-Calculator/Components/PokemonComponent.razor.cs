using Microsoft.AspNetCore.Components;
using PKMDS_Stat_Calculator.Models;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator.Components
{
    public partial class PokemonComponent
    {
        [Parameter]
        public IList<PokemonCalculated> PokemonList
        {
            get; set;
        } = new List<PokemonCalculated>();

        private static string GetPokemonTypes(Pokemon pokemon)
        {
            string type1 = string.Empty;
            string type2 = string.Empty;
            if (pokemon.Types.Count > 0)
            {
                type1 = pokemon.Types[0].Type.Name;
            }
            if (pokemon.Types.Count > 1)
            {
                type2 = pokemon.Types[1].Type.Name;
            }

            if (!string.IsNullOrEmpty(type2) && !string.Equals(type1, type2, StringComparison.OrdinalIgnoreCase))
            {
                return $@"{type1}/{type2}";
            }
            else
            {
                return $@"{type1}";
            }
        }

        protected async Task RemoveRow(PokemonCalculated pokemon)
        {
            PokemonList.Remove(pokemon);
            StateHasChanged();
        }
    }
}
