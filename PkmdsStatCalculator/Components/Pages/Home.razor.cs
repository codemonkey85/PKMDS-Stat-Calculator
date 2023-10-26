namespace PkmdsStatCalculator.Components.Pages;

public partial class Home
{
    private readonly List<PokemonStats> PokemonStatsList =
        [
            new()
            {
                Generation = 9,
                GameVersion = GameVersion.SV,
                Species = Species.Pikachu,
                Nature = Nature.Hardy,
                FormId = 0,
                Level = 100,
            },
        ];

    private void AddPokemonStats(PokemonStats stats)
    {
        PokemonStatsList.Add(stats);
        StateHasChanged();
    }
}
