using Microsoft.AspNetCore.Components;
using PKMDS_Stat_Calculator.Models;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PKMDS_Stat_Calculator.Components
{
    public partial class PokemonComponent
    {
        [Parameter]
        public IList<PokemonCalculated> PokemonList
        {
            get; set;
        } = new List<PokemonCalculated>();

        protected bool showSprite = false;

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

        protected void RemoveRow(PokemonCalculated pokemon)
        {
            PokemonList.Remove(pokemon);
            StateHasChanged();
        }

        private bool? sortIdDesc = null;
        private bool? sortNameDesc = null;
        private bool? sortTypeDesc = null;
        private bool? sortHpDesc = null;
        private bool? sortAttackDesc = null;
        private bool? sortDefenseDesc = null;
        private bool? sortSpecialAttackDesc = null;
        private bool? sortSpecialDefenseDesc = null;
        private bool? sortSpeedDesc = null;

        protected void SortId()
        {
            if (sortIdDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Id).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Id).ToList();
            }
            sortIdDesc = !(sortIdDesc ?? false);
        }

        protected void SortName()
        {
            if (sortNameDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Name).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Name).ToList();
            }
            sortNameDesc = !(sortNameDesc ?? false);
        }

        protected void SortType()
        {
            if (sortTypeDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => GetPokemonTypes(p.Pokemon)).ThenByDescending(p => GetPokemonTypes(p.Pokemon)).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => GetPokemonTypes(p.Pokemon)).ThenBy(p => GetPokemonTypes(p.Pokemon)).ToList();
            }
            sortTypeDesc = !(sortTypeDesc ?? false);
        }

        protected void SortHp()
        {
            if (sortHpDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[0].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[0].BaseStat).ToList();
            }
            sortHpDesc = !(sortHpDesc ?? false);
        }

        protected void SortAttack()
        {
            if (sortAttackDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[1].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[1].BaseStat).ToList();
            }
            sortAttackDesc = !(sortAttackDesc ?? false);
        }

        protected void SortDefense()
        {
            if (sortDefenseDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[2].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[2].BaseStat).ToList();
            }
            sortDefenseDesc = !(sortDefenseDesc ?? false);
        }

        protected void SortSpecialAttack()
        {
            if (sortSpecialAttackDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[3].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[3].BaseStat).ToList();
            }
            sortSpecialAttackDesc = !(sortSpecialAttackDesc ?? false);
        }

        protected void SortSpecialDefense()
        {
            if (sortSpecialDefenseDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[4].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[4].BaseStat).ToList();
            }
            sortSpecialDefenseDesc = !(sortSpecialDefenseDesc ?? false);
        }

        protected void Speed()
        {
            if (sortSpeedDesc ?? false)
            {
                PokemonList = PokemonList.OrderByDescending(p => p.Pokemon.Stats[5].BaseStat).ToList();
            }
            else
            {
                PokemonList = PokemonList.OrderBy(p => p.Pokemon.Stats[5].BaseStat).ToList();
            }
            sortSpeedDesc = !(sortSpeedDesc ?? false);
        }

        protected string GetArrowString(bool? sortDesc) =>
            sortDesc == null ? string.Empty : (sortDesc ?? false) ? "asc" : "desc";
    }
}
