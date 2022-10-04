
namespace BookApp.BookServices;

public class ChangePubDateService
{
    static public ChangePubDateDto getOriginal(BookAppDbContext context, int id) {
        return context.Books
            .Select(p => new ChangePubDateDto
            {
                BookId = p.BookId,
                Title = p.Title,
                PublishedOn = p.PublishedOn
            })
            .Single(k => k.BookId == id);
    }

    static public Book updateBook(BookAppDbContext context, ChangePubDateDto dto) {
        var book = context.Books.SingleOrDefault(
            x => x.BookId == dto.BookId);
        if (book == null) {
            throw new ArgumentException("Book not found");
        }
        book.PublishedOn = dto.PublishedOn;
        context.SaveChanges();
        return book;
    }
}

