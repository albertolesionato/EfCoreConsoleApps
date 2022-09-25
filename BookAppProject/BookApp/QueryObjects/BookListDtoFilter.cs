
namespace BookApp.QueryObjects {
    enum BooksFilterBy {
        NoFilter,
        ByVotes,
        ByTags,
        ByPublicationYear
    }

    static public class BookListDtoFilter {
        public static IQueryable<BookListDto> FilterBooksBy
            (this IQueryable<BookListDto> books,
            BooksFilterBy filterBy, string filterValue) {
                if (string.IsNullOrEmpty(filterValue)) {
                    return books;
                }
                
            }
    }
}