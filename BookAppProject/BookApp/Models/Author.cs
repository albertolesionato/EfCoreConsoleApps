
namespace BookApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BookAuthor> BooksLink { get; set; } = null!;
    }
}