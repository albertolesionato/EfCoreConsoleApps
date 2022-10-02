
using BookApp.QueryObjects;

namespace BookApp.BookServices;

public class SortFilterPageOptions
{
    public int PageNum = 1;

    public int PageSize = 10;

    public OrderByOption OrderByOption { get; set; }

    public BooksFilterBy FilterBy { get; set; }

    public string FilterValue { get; set; } = null!;
}

