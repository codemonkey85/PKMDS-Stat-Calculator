namespace PkmdsStatCalculator.Components;

public partial class PokemonViewComponent
{
    [Parameter, EditorRequired] public int Generation { get; set; }

    [Parameter, EditorRequired] public GameVersion GameVersion { get; set; }

    [Parameter, EditorRequired] public Species PokemonSpecies { get; set; }

    [Parameter, EditorRequired] public Nature PokemonNature { get; set; }

    [Parameter, EditorRequired] public byte PokemonFormId { get; set; }

    private PKM? Pokemon { get; set; }

    private const string EnglishLang = "en";

    private static string[] NatureStatShortNames => new[] { "Atk", "Def", "Spe", "SpA", "SpD" };

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Pokemon = EntityBlank.GetBlank(Generation, GameVersion);

        Pokemon.Species = (ushort)PokemonSpecies;
        Pokemon.Form = PokemonFormId;

        Pokemon.MaximizeLevel();
        Pokemon.Nature = (int)PokemonNature;

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
        : GameInfo.GetStrings(EnglishLang).Species[Pokemon.Species];

    private string GetPokemonNatureName() => Pokemon is null
        ? string.Empty
        : GameInfo.GetStrings(EnglishLang).Natures[Pokemon.Nature];

    private string GetPokemonFormName() => Pokemon is null
        ? string.Empty
        : FormConverter.GetFormList(Pokemon.Species, GameInfo.Strings.types, GameInfo.Strings.forms, GameInfo.GenderSymbolUnicode, Pokemon.Context)[Pokemon.Form];
}
