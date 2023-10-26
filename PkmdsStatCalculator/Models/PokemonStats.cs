namespace PkmdsStatCalculator.Models;

public class PokemonStats
{
    public int Generation { get; set; } = 9;

    public GameVersion GameVersion { get; set; } = GameVersion.SV;

    public Species Species { get; set; } = Species.Pikachu;

    public Nature Nature { get; set; } = Nature.Hardy;

    public byte FormId { get; set; }

    public int Level { get; set; } = 100;
}
