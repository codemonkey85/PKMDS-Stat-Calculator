namespace PkmdsStatCalculator.Components.Pages;

public partial class Home
{
    private readonly List<PKM> PokemonList = [];
    private const string DefaultLanguage = "en";

    private string Language { get; set; } = DefaultLanguage;

    private GameStrings GameStrings { get; set; } = GameInfo.GetStrings(DefaultLanguage);

    private static string[] NatureStatShortNames => new[] { "Atk", "Def", "Spe", "SpA", "SpD" };

    private PokemonStats NewPokemonStats { get; set; } = new PokemonStats();

    private void OnValidSubmit()
    {
        PokemonList.Add(GeneratePokemonStats(NewPokemonStats));
        NewPokemonStats = new PokemonStats();
    }

    private PKM GeneratePokemonStats(PokemonStats pokemonStats)
    {
        var pokemon = EntityBlank.GetBlank(pokemonStats.Generation, pokemonStats.GameVersion);

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
        return up == down ? "(Neutral)" : $"({NatureStatShortNames[up]} ↑, {NatureStatShortNames[down]} ↓)";
    }

    private string GetPokemonSpeciesName(PKM pokemon) => pokemon is null
        ? string.Empty
        : GameStrings.Species[pokemon.Species];

    private string GetPokemonNatureName(PKM pokemon) => pokemon is null
        ? string.Empty
        : GameStrings.Natures[pokemon.Nature];

    private static string GetPokemonFormName(PKM pokemon) => pokemon is null
        ? string.Empty
        : FormConverter.GetFormList(pokemon.Species, GameInfo.Strings.types, GameInfo.Strings.forms, GameInfo.GenderSymbolUnicode, pokemon.Context)[pokemon.Form];
}
