using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private IList<Pokemon> pokemonList = new List<Pokemon>();

        private IList<string> pokemonNames = new List<string>();

        private string selectedPokemon = string.Empty;

        private string errorMessage = null;

        protected override async Task OnInitializedAsync() =>
            pokemonNames = (await PokeApiClient.GetNamedResourcePageAsync<Pokemon>(-1, 0)).Results
                .Select(pokemon => pokemon.Name)
                .OrderBy(name => name)
                .ToList();

        private async Task ButtonClicked()
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedPokemon))
                {
                    pokemonList.Add(await PokeApiClient.GetResourceAsync<Pokemon>(selectedPokemon));
                }
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        private void OnError(Exception ex)
        {
            StringBuilder errorMessageBuilder = new StringBuilder();
            BuildErrorMessage(errorMessageBuilder, ex);
            errorMessage = errorMessageBuilder.ToString();
        }

        private void BuildErrorMessage(StringBuilder errorMessageBuilder, Exception ex)
        {
            errorMessageBuilder.AppendLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                BuildErrorMessage(errorMessageBuilder, ex.InnerException);
            }
        }

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
    }
}
