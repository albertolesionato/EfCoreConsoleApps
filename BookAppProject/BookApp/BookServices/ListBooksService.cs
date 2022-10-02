
namespace BookApp.BookServices;

public class ListBooksService
{
    public ListBooksService(BookAppDbContext Context)
    {
        this.Context = Context;
    }

    private readonly BookAppDbContext Context;

    public IQueryable<BookListDto> SortFilterPage
        (SortFilterPageOptions options) {
        return Context.Books
            .AsNoTracking()
            .MapBookToDto()
            .OrderBooksBy(options.OrderByOption)
            .FilterBooksBy(options.FilterBy, options.FilterValue)
            .Page(options.PageNum - 1, options.PageSize);
    }

}

