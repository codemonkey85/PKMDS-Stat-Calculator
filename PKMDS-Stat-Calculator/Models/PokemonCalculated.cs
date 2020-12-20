using PokeApiNet;
using System;

namespace PKMDS_Stat_Calculator.Models
{
    public class PokemonCalculated
    {
        private enum Stats : int
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

        private double GetNatureModifier(Stats stat)
        {
            if (string.Equals(Nature.IncreasedStat.Name, Nature.DecreasedStat.Name, StringComparison.OrdinalIgnoreCase))
            {
                return 1D;
            }

            switch (stat)
            {
                case Stats.Attack when string.Equals(Nature.IncreasedStat.Name, "attack", StringComparison.OrdinalIgnoreCase):
                case Stats.Defense when string.Equals(Nature.IncreasedStat.Name, "defense", StringComparison.OrdinalIgnoreCase):
                case Stats.SpecialAttack when string.Equals(Nature.IncreasedStat.Name, "special-attack", StringComparison.OrdinalIgnoreCase):
                case Stats.SpecialDefense when string.Equals(Nature.IncreasedStat.Name, "special-defense", StringComparison.OrdinalIgnoreCase):
                case Stats.Speed when string.Equals(Nature.IncreasedStat.Name, "speed", StringComparison.OrdinalIgnoreCase):
                    return 1.1D;

                case Stats.Attack when string.Equals(Nature.DecreasedStat.Name, "attack", StringComparison.OrdinalIgnoreCase):
                case Stats.Defense when string.Equals(Nature.DecreasedStat.Name, "defense", StringComparison.OrdinalIgnoreCase):
                case Stats.SpecialAttack when string.Equals(Nature.DecreasedStat.Name, "special-attack", StringComparison.OrdinalIgnoreCase):
                case Stats.SpecialDefense when string.Equals(Nature.DecreasedStat.Name, "special-defense", StringComparison.OrdinalIgnoreCase):
                case Stats.Speed when string.Equals(Nature.DecreasedStat.Name, "speed", StringComparison.OrdinalIgnoreCase):
                    return 0.9D;

                default:
                    return 1D;
            }
        }

        public Pokemon Pokemon
        {
            get; set;
        }

        public Nature Nature
        {
            get; set;
        }

        #region Stats

        public int HpIv
        {
            get; set;
        }

        public int AttackIv
        {
            get; set;
        }

        public int DefenseIv
        {
            get; set;
        }

        public int SpecialAttackIv
        {
            get; set;
        }

        public int SpecialDefenseIv
        {
            get; set;
        }

        public int SpeedIv
        {
            get; set;
        }

        public int HpEv
        {
            get; set;
        }

        public int AttackEv
        {
            get; set;
        }

        public int DefenseEv
        {
            get; set;
        }

        public int SpecialAttackEv
        {
            get; set;
        }

        public int SpecialDefenseEv
        {
            get; set;
        }

        public int SpeedEv
        {
            get; set;
        }

        public int Level
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
}
