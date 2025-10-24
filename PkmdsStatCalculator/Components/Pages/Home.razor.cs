namespace PkmdsStatCalculator.Components.Pages;

public partial class Home
{
    private const string DefaultLanguage = "en";
    private const LanguageID DefaultLanguageId = LanguageID.English;
    private const int Hp = 0, Atk = 1, Def = 2, SpA = 3, SpD = 4, Spe = 5;

    private List<PKM> PokemonList { get; } = [];

    private string Language { get; } = DefaultLanguage;

    private LanguageID LanguageId { get; set; } = DefaultLanguageId;

    private byte Generation { get; } = 9;

    private GameVersion GameVersion { get; } = GameVersion.SV;

    private GameStrings GameStrings { get; } = GameInfo.GetStrings(DefaultLanguage);

    private static string[] NatureStatShortNames => ["Atk", "Def", "Spe", "SpA", "SpD"];

    private PokemonStats NewPokemonStats { get; set; } = new();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        InitializeStrings();
    }

    private void OnValidSubmit(EditContext context)
    {
        var validation = context.Validate();
        Console.WriteLine($"Valid: {validation}");
        var validationMessages = context.GetValidationMessages().ToList();
        if (validationMessages is { Count: > 0 })
        {
            foreach (var validationMessage in validationMessages)
            {
                Console.WriteLine(validationMessage);
            }
        }

        PokemonList.Add(GeneratePokemonStats(NewPokemonStats));
        NewPokemonStats = new PokemonStats();
    }

    private void InitializeStrings() => LocalizeUtil.InitializeStrings(Language);

    private PKM GeneratePokemonStats(PokemonStats pokemonStats)
    {
        var pokemon = EntityBlank.GetBlank(Generation, GameVersion);

        pokemon.Species = (ushort)pokemonStats.Species;
        pokemon.Form = pokemonStats.FormId;

        pokemon.CurrentLevel = (byte)pokemonStats.Level;
        pokemon.Nature = pokemonStats.Nature;

        pokemon.SetIVs(pokemonStats.IvsSpan());
        pokemon.SetEVs(pokemonStats.EvsSpan());

        Span<ushort> stats = stackalloc ushort[6];
        pokemon.LoadStats(pokemon.PersonalInfo, stats);
        pokemon.SetStats(stats);

        return pokemon;
    }

    private static string GetStatModifierString(PKM pokemon)
    {
        var (up, down) = NatureAmp.GetNatureModification(pokemon.Nature);
        return up == down
            ? "(Neutral)"
            : $"({NatureStatShortNames[up]} ↑, {NatureStatShortNames[down]} ↓)";
    }

    private string GetPokemonSpeciesName(PKM pokemon) => GameStrings.Species[pokemon.Species];

    private string GetPokemonNatureName(PKM pokemon) => GameStrings.Natures[(int)pokemon.Nature];

    private static string GetPokemonFormName(PKM pokemon) => FormConverter.GetFormList(
        pokemon.Species,
        GameInfo.Strings.types,
        GameInfo.Strings.forms,
        GameInfo.GenderSymbolUnicode,
        pokemon.Context)[pokemon.Form];

    private IEnumerable<ComboItem> SearchPokemonNames(string searchString) =>
        searchString is not { Length: > 0 }
            ? Enumerable.Empty<ComboItem>()
            : GameInfo.Sources.SpeciesDataSource
                .Where(species => species.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .OrderBy(species => species.Text);

    private ComboItem GetSpeciesComboItem(ushort speciesId) => GameInfo.FilteredSources.Species
        .FirstOrDefault(species => species.Value == speciesId) ?? null!;

    private Task<IEnumerable<ComboItem>> SearchFunction(string? searchString, CancellationToken cancellationToken) =>
        string.IsNullOrEmpty(searchString)
            ? Task.FromResult<IEnumerable<ComboItem>>([])
            : Task.FromResult(SearchPokemonNames(searchString));
}