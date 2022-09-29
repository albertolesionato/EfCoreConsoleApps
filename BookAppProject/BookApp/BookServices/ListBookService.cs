
namespace BookApp.BookServices;

public class ListBookService
{
    public ListBookService(BookAppDbContext Context)
    {
        this.Context = Context;
    }

    private readonly BookAppDbContext Context;

    public IQueryable<BookListDto> SortFilterPage
        (SortFilterPageOptions options) { 
    
    }

}

