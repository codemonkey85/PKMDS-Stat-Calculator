namespace PkmdsStatCalculator.Components.Pages;

public partial class Home
{
    private readonly PokemonStats PokemonStats = new()
    {
        Generation = 9,
        GameVersion = GameVersion.SV,
        Species = Species.Pikachu,
        Nature = Nature.Hardy,
        FormId = 0,
        Level = 100
    };
}
