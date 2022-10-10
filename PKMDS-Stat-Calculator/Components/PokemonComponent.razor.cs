namespace PKMDS_Stat_Calculator.Components;

public partial class PokemonComponent
{
    [Parameter, EditorRequired]
    public IList<PokemonCalculated>? PokemonList
    {
        get;
        set;
    } = new List<PokemonCalculated>();

    protected bool ShowSprite = false;

    private static string GetPokemonTypes(Pokemon pokemon)
    {
        var type1 = string.Empty;
        var type2 = string.Empty;
        if (pokemon.Types.Count > 0)
        {
            type1 = pokemon.Types[0].Type.Name;
        }
        if (pokemon.Types.Count > 1)
        {
            type2 = pokemon.Types[1].Type.Name;
        }

        return !string.IsNullOrEmpty(type2) && !string.Equals(type1, type2, StringComparison.OrdinalIgnoreCase)
            ? $@"{type1}/{type2}"
            : $@"{type1}";
    }

    protected void RemoveRow(PokemonCalculated pokemon)
    {
        PokemonList?.Remove(pokemon);
        StateHasChanged();
    }

    private bool? _sortIdDesc = null;
    private bool? _sortNameDesc = null;
    private bool? _sortTypeDesc = null;
    private bool? _sortHpDesc = null;
    private bool? _sortAttackDesc = null;
    private bool? _sortDefenseDesc = null;
    private bool? _sortSpecialAttackDesc = null;
    private bool? _sortSpecialDefenseDesc = null;
    private bool? _sortSpeedDesc = null;

    protected void SortId()
    {
        PokemonList = _sortIdDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Id).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Id).ToList();
        _sortIdDesc = !(_sortIdDesc ?? false);
    }

    protected void SortName()
    {
        PokemonList = _sortNameDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Name).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Name).ToList();
        _sortNameDesc = !(_sortNameDesc ?? false);
    }

    protected void SortType()
    {
        PokemonList = _sortTypeDesc ?? false
            ? PokemonList?.OrderByDescending(p => GetPokemonTypes(p.Pokemon))
                .ThenByDescending(p => GetPokemonTypes(p.Pokemon)).ToList()
            : PokemonList?.OrderBy(p => GetPokemonTypes(p.Pokemon)).ThenBy(p => GetPokemonTypes(p.Pokemon)).ToList();
        _sortTypeDesc = !(_sortTypeDesc ?? false);
    }

    protected void SortHp()
    {
        PokemonList = _sortHpDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[0].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[0].BaseStat).ToList();
        _sortHpDesc = !(_sortHpDesc ?? false);
    }

    protected void SortAttack()
    {
        PokemonList = _sortAttackDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[1].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[1].BaseStat).ToList();
        _sortAttackDesc = !(_sortAttackDesc ?? false);
    }

    protected void SortDefense()
    {
        PokemonList = _sortDefenseDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[2].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[2].BaseStat).ToList();
        _sortDefenseDesc = !(_sortDefenseDesc ?? false);
    }

    protected void SortSpecialAttack()
    {
        PokemonList = _sortSpecialAttackDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[3].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[3].BaseStat).ToList();
        _sortSpecialAttackDesc = !(_sortSpecialAttackDesc ?? false);
    }

    protected void SortSpecialDefense()
    {
        PokemonList = _sortSpecialDefenseDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[4].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[4].BaseStat).ToList();
        _sortSpecialDefenseDesc = !(_sortSpecialDefenseDesc ?? false);
    }

    protected void Speed()
    {
        PokemonList = _sortSpeedDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[5].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[5].BaseStat).ToList();
        _sortSpeedDesc = !(_sortSpeedDesc ?? false);
    }

    protected static string GetArrowString(bool? sortDesc) =>
        sortDesc == null ? string.Empty : (bool)sortDesc ? "asc" : "desc";
}
