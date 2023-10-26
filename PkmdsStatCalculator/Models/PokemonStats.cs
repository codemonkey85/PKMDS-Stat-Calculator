namespace PkmdsStatCalculator.Models;

public class PokemonStats
{
    public int Generation { get; set; }

    public GameVersion GameVersion { get; set; }

    public Species Species { get; set; }

    public Nature Nature { get; set; }

    public byte FormId { get; set; }

    public int Level { get; set; }

    public GameStrings GameStrings { get; set; } = default!;
}
