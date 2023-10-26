namespace PkmdsStatCalculator.Components;

public partial class NewPokemonStatsForm
{
    [Parameter, EditorRequired] public Action<PokemonStats>? AddStatsMethod { get; set; }

    private PokemonStats PokemonStats { get; set; } = new PokemonStats();

    private void OnValidSubmit()
    {
        AddStatsMethod?.Invoke(PokemonStats);
    }
}
