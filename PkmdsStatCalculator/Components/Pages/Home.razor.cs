namespace PkmdsStatCalculator.Components.Pages;

public partial class Home
{
    private const string DefaultLanguage = "en";
    private const LanguageID DefaultLanguageId = LanguageID.English;
    private const int Hp = 0, Atk = 1, Def = 2, SpA = 3, SpD = 4, Spe = 5;

    private List<PKM> PokemonList { get; set; } = [];

    private string Language { get; set; } = DefaultLanguage;

    private LanguageID LanguageId { get; set; } = DefaultLanguageId;

    public int Generation { get; set; } = 9;

    public GameVersion GameVersion { get; set; } = GameVersion.SV;

    private GameStrings GameStrings { get; set; } = GameInfo.GetStrings(DefaultLanguage);

    private static string[] NatureStatShortNames => ["Atk", "Def", "Spe", "SpA", "SpD"];

    private PokemonStats NewPokemonStats { get; set; } = new PokemonStats();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        InitializeStrings();
    }

    private void OnValidSubmit()
    {
        PokemonList.Add(GeneratePokemonStats(NewPokemonStats));
        NewPokemonStats = new PokemonStats();
    }

    private void InitializeStrings()
    {
        var sav = SaveUtil.GetBlankSAV(GameVersion, "TRAINER", LanguageId);
        LocalizeUtil.InitializeStrings(Language, sav);
    }

    private PKM GeneratePokemonStats(PokemonStats pokemonStats)
    {
        var pokemon = EntityBlank.GetBlank(Generation, GameVersion);

        pokemon.Species = (ushort)pokemonStats.Species;
        pokemon.Form = pokemonStats.FormId;

        pokemon.CurrentLevel = pokemonStats.Level;
        pokemon.Nature = (int)pokemonStats.Nature;

        Span<ushort> stats = stackalloc ushort[6];
        pokemon.LoadStats(pokemon.PersonalInfo, stats);
        pokemon.SetStats(stats);

        return pokemon;
    }

    private static string GetStatModifierString(PKM pokemon)
    {
        if (pokemon is null)
        {
            return string.Empty;
        }
        var (up, down) = NatureAmp.GetNatureModification(pokemon.Nature);
        return up == down
            ? "(Neutral)"
            : $"({NatureStatShortNames[up]} ↑, {NatureStatShortNames[down]} ↓)";
    }

    private string GetPokemonSpeciesName(PKM pokemon) => pokemon is null
        ? string.Empty
        : GameStrings.Species[pokemon.Species];

    private string GetPokemonNatureName(PKM pokemon) => pokemon is null
        ? string.Empty
        : GameStrings.Natures[pokemon.Nature];

    private static string GetPokemonFormName(PKM pokemon) => pokemon is null
        ? string.Empty
        : FormConverter.GetFormList(
            pokemon.Species,
            GameInfo.Strings.types,
            GameInfo.Strings.forms,
            GameInfo.GenderSymbolUnicode,
    pokemon.Context)[pokemon.Form];

    public IEnumerable<ComboItem> SearchPokemonNames(string searchString) => searchString is not { Length: > 0 }
        ? Enumerable.Empty<ComboItem>()
        : GameInfo.FilteredSources.Species
            .Where(species => species.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .OrderBy(species => species.Text);
}
