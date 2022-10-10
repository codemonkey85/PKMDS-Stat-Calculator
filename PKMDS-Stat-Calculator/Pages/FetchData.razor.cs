namespace PKMDS_Stat_Calculator.Pages;

[Route("/")]
public partial class FetchData
{
    private readonly IList<PokemonCalculated> _pokemonList = new List<PokemonCalculated>();

    private IList<string> _pokemonNames = new List<string>();

    private string _selectedPokemon = string.Empty;

    private string? _errorMessage;

    protected override async Task OnInitializedAsync() =>
        _pokemonNames = (await PokeApiClient.GetNamedResourcePageAsync<Pokemon>(-1, 0)).Results
            .Select(pokemon => pokemon.Name)
            .OrderBy(name => name)
            .ToList();

    private async Task ButtonClicked()
    {
        try
        {
            if (!string.IsNullOrEmpty(_selectedPokemon))
            {
                PokemonCalculated pokemonCalculated = new()
                {
                    Pokemon = await PokeApiClient.GetResourceAsync<Pokemon>(_selectedPokemon)
                };
                _pokemonList.Add(pokemonCalculated);
            }
        }
        catch (Exception ex)
        {
            OnError(ex);
        }
    }

    private void OnError(Exception ex)
    {
        var errorMessageBuilder = new StringBuilder();
        BuildErrorMessage(errorMessageBuilder, ex);
        _errorMessage = errorMessageBuilder.ToString();
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
