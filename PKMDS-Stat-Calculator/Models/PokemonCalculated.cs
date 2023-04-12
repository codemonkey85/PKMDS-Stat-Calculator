namespace PKMDS_Stat_Calculator.Models;

public class PokemonCalculated
{
    private enum Stats
    {
        Hp = 1,
        Attack,
        Defense,
        SpecialAttack,
        SpecialDefense,
        Speed
    }

    private static int CalculateHpStat(int baseStat, int iv, int ev, int level) =>
        Convert.ToInt32(Math.Floor(Math.Floor(iv + 2 * baseStat + Math.Floor(ev / 4D)) * level / 100D) + 10D + level);

    private static int CalculateNonHpStat(int baseStat, int iv, int ev, int level, double natureModifier) =>
        Convert.ToInt32(Math.Floor(Math.Floor(Math.Floor(iv + 2 * baseStat + Math.Floor(ev / 4D)) * level / 100D) + 5D) * natureModifier);

    private double GetNatureModifier(Stats stat) =>
        stat switch
        {
            _ when string.Equals(Nature.IncreasedStat.Name, Nature.DecreasedStat.Name,
                StringComparison.OrdinalIgnoreCase) => 1D,
            var s when string.Equals(Nature.IncreasedStat.Name, s.ToString(), StringComparison.OrdinalIgnoreCase) =>
                1.1D,
            var s when string.Equals(Nature.DecreasedStat.Name, s.ToString(), StringComparison.OrdinalIgnoreCase) =>
                0.9D,
            _ => 1D,
        };

    public Pokemon Pokemon
    {
        get;
        set;
    } = new();

    private Nature Nature
    {
        get;
        set;
    } = new();

    #region Stats

    private int HpIv
    {
        get; set;
    }

    private int AttackIv
    {
        get; set;
    }

    private int DefenseIv
    {
        get; set;
    }

    private int SpecialAttackIv
    {
        get; set;
    }

    private int SpecialDefenseIv
    {
        get; set;
    }

    private int SpeedIv
    {
        get; set;
    }

    private int HpEv
    {
        get; set;
    }

    private int AttackEv
    {
        get; set;
    }

    private int DefenseEv
    {
        get; set;
    }

    private int SpecialAttackEv
    {
        get; set;
    }

    private int SpecialDefenseEv
    {
        get; set;
    }

    private int SpeedEv
    {
        get; set;
    }

    private int Level
    {
        get; set;
    }

    #endregion

    public int Hp => CalculateHpStat(Pokemon.Stats[0].BaseStat, HpIv, HpEv, Level);

    public int Attack => CalculateNonHpStat(Pokemon.Stats[1].BaseStat, AttackIv, AttackEv, Level, GetNatureModifier(Stats.Attack));

    public int Defense => CalculateNonHpStat(Pokemon.Stats[2].BaseStat, DefenseIv, DefenseEv, Level, GetNatureModifier(Stats.Defense));

    public int SpecialAttack => CalculateNonHpStat(Pokemon.Stats[3].BaseStat, SpecialAttackIv, SpecialAttackEv, Level, GetNatureModifier(Stats.SpecialAttack));

    public int SpecialDefense => CalculateNonHpStat(Pokemon.Stats[4].BaseStat, SpecialDefenseIv, SpecialDefenseEv, Level, GetNatureModifier(Stats.SpecialDefense));

    public int Speed => CalculateNonHpStat(Pokemon.Stats[5].BaseStat, SpeedIv, SpeedEv, Level, GetNatureModifier(Stats.Speed));
}
