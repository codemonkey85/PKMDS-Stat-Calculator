namespace PkmdsStatCalculator.Components;

public partial class PokemonViewComponent
{
    [Parameter, EditorRequired] public PokemonStats PokemonStats { get; set; } = new();

    private PKM? Pokemon { get; set; }

    private GameStrings GameStrings { get; set; } = GameInfo.GetStrings("en");

    private static string[] NatureStatShortNames => new[] { "Atk", "Def", "Spe", "SpA", "SpD" };

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Pokemon = EntityBlank.GetBlank(PokemonStats.Generation, PokemonStats.GameVersion);

        Pokemon.Species = (ushort)PokemonStats.Species;
        Pokemon.Form = PokemonStats.FormId;

        Pokemon.CurrentLevel = PokemonStats.Level;
        Pokemon.Nature = (int)PokemonStats.Nature;

        Span<ushort> stats = stackalloc ushort[6];
        Pokemon.LoadStats(Pokemon.PersonalInfo, stats);
        Pokemon.SetStats(stats);
    }

    private string GetStatModifierString()
    {
        if (Pokemon is null)
        {
            return string.Empty;
        }
        var (up, down) = NatureAmp.GetNatureModification(Pokemon.Nature);
        return up == down ? "(Neutral)" : $"({NatureStatShortNames[up]} ↑, {NatureStatShortNames[down]} ↓)";
    }

    private string GetPokemonSpeciesName() => Pokemon is null
        ? string.Empty
        : GameStrings.Species[Pokemon.Species];

    private string GetPokemonNatureName() => Pokemon is null
        ? string.Empty
        : GameStrings.Natures[Pokemon.Nature];

    private string GetPokemonFormName() => Pokemon is null
        ? string.Empty
        : FormConverter.GetFormList(Pokemon.Species, GameInfo.Strings.types, GameInfo.Strings.forms, GameInfo.GenderSymbolUnicode, Pokemon.Context)[Pokemon.Form];
}
