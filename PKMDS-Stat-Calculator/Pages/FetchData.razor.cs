using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKMDS_Stat_Calculator.Models;
using PokeApiNet;

namespace PKMDS_Stat_Calculator.Pages
{
    public partial class FetchData
    {
        private IList<PokemonCalculated> pokemonList = new List<PokemonCalculated>();

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
                    PokemonCalculated pokemonCalculated = new PokemonCalculated();
                    pokemonCalculated.Pokemon = await PokeApiClient.GetResourceAsync<Pokemon>(selectedPokemon);
                    pokemonList.Add(pokemonCalculated);
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
    }
}
