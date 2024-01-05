namespace PkmdsStatCalculator.Models;

public class PokemonStats
{
    [Required]
    public Species Species { get; set; } = Species.Pikachu;

    [Required]
    public Nature Nature { get; set; } = Nature.Hardy;

    [Required]
    public byte FormId { get; set; }

    [Required, Range(1, 100)]
    public int Level { get; set; } = 100;

    [Required, Range(0, 31)]
    public int HpIv { get; set; }

    [Required, Range(0, 31)]
    public int AtkIv { get; set; }

    [Required, Range(0, 31)]
    public int DefIv { get; set; }

    [Required, Range(0, 31)]
    public int SpeIv { get; set; }

    [Required, Range(0, 31)]
    public int SpAIv { get; set; }

    [Required, Range(0, 31)]
    public int SpDIv { get; set; }

    public Span<int> IvsSpan() => new([HpIv, AtkIv, DefIv, SpeIv, SpAIv, SpDIv]);

    [Required, Range(0, 255)]
    public int HpEv { get; set; }

    [Required, Range(0, 255)]
    public int AtkEv { get; set; }

    [Required, Range(0, 255)]
    public int DefEv { get; set; }

    [Required, Range(0, 255)]
    public int SpeEv { get; set; }

    [Required, Range(0, 255)]
    public int SpAEv { get; set; }

    [Required, Range(0, 255)]
    public int SpDEv { get; set; }

    public Span<int> EvsSpan() => new([HpEv, AtkEv, DefEv, SpeEv, SpAEv, SpDEv]);
}
