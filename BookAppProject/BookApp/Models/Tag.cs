
namespace BookApp.Models;

public class Tag
{
    public string TagId { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = null!;
}
