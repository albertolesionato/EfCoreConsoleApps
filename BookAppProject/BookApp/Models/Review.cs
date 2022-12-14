
namespace BookApp.Models;

public class Review
{
    public int ReviewId { get; set; }
    public string VoterName { get; set; } = null!;
    public int NumStars { get; set; }
    public string? Comment { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
