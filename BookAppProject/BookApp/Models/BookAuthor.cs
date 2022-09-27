
namespace BookApp.Models;

public class BookAuthor
{
    public int BookAuthorId { get; set; }
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public byte Order { get; set; }
    public Book Book { get; set; } = null!;
    public Author Author { get; set; } = null!;
}
