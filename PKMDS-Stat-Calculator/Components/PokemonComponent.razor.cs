namespace PKMDS_Stat_Calculator.Components;

public partial class PokemonComponent
{
    [Parameter, EditorRequired]
    public IList<PokemonCalculated>? PokemonList
    {
        get;
        set;
    } = new List<PokemonCalculated>();

    private bool showSprite;

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

    private void RemoveRow(PokemonCalculated pokemon)
    {
        PokemonList?.Remove(pokemon);
        StateHasChanged();
    }

    private bool? sortIdDesc;
    private bool? sortNameDesc;
    private bool? sortTypeDesc;
    private bool? sortHpDesc;
    private bool? sortAttackDesc;
    private bool? sortDefenseDesc;
    private bool? sortSpecialAttackDesc;
    private bool? sortSpecialDefenseDesc;
    private bool? sortSpeedDesc;

    private void SortId()
    {
        PokemonList = sortIdDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Id).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Id).ToList();
        sortIdDesc = !(sortIdDesc ?? false);
    }

    private void SortName()
    {
        PokemonList = sortNameDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Name).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Name).ToList();
        sortNameDesc = !(sortNameDesc ?? false);
    }

    private void SortType()
    {
        PokemonList = sortTypeDesc ?? false
            ? PokemonList?.OrderByDescending(p => GetPokemonTypes(p.Pokemon))
                .ThenByDescending(p => GetPokemonTypes(p.Pokemon)).ToList()
            : PokemonList?.OrderBy(p => GetPokemonTypes(p.Pokemon)).ThenBy(p => GetPokemonTypes(p.Pokemon)).ToList();
        sortTypeDesc = !(sortTypeDesc ?? false);
    }

    private void SortHp()
    {
        PokemonList = sortHpDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[0].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[0].BaseStat).ToList();
        sortHpDesc = !(sortHpDesc ?? false);
    }

    private void SortAttack()
    {
        PokemonList = sortAttackDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[1].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[1].BaseStat).ToList();
        sortAttackDesc = !(sortAttackDesc ?? false);
    }

    private void SortDefense()
    {
        PokemonList = sortDefenseDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[2].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[2].BaseStat).ToList();
        sortDefenseDesc = !(sortDefenseDesc ?? false);
    }

    private void SortSpecialAttack()
    {
        PokemonList = sortSpecialAttackDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[3].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[3].BaseStat).ToList();
        sortSpecialAttackDesc = !(sortSpecialAttackDesc ?? false);
    }

    private void SortSpecialDefense()
    {
        PokemonList = sortSpecialDefenseDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[4].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[4].BaseStat).ToList();
        sortSpecialDefenseDesc = !(sortSpecialDefenseDesc ?? false);
    }

    private void Speed()
    {
        PokemonList = sortSpeedDesc ?? false
            ? PokemonList?.OrderByDescending(p => p.Pokemon.Stats[5].BaseStat).ToList()
            : PokemonList?.OrderBy(p => p.Pokemon.Stats[5].BaseStat).ToList();
        sortSpeedDesc = !(sortSpeedDesc ?? false);
    }

    private static string GetArrowString(bool? sortDesc) =>
        sortDesc == null ? string.Empty : (bool)sortDesc ? "asc" : "desc";
}
