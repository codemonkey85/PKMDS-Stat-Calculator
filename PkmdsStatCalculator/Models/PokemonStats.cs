namespace PkmdsStatCalculator.Models;

public class PokemonStats
{
    public Species Species { get; set; } = Species.Pikachu;

    public Nature Nature { get; set; } = Nature.Hardy;

    public byte FormId { get; set; }

    public int Level { get; set; } = 100;
}
