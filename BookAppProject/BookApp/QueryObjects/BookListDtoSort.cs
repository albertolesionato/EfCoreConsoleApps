
namespace BookApp.QueryObjects
{
    public enum OrderByOption
    {
        SimpleOrder,
        ByVotes,
        ByPublicationDate,
        ByPriceLowestFirst,
        ByPriceHighestFirst
    }
    static public class BookListDtoSort
    {
        public static IQueryable<BookListDto> OrderBooksBy
    (this IQueryable<BookListDto> books,
    OrderByOption orderByOption)
        {
            switch (orderByOption)
            {
                case OrderByOption.SimpleOrder:
                    return books.OrderByDescending(x => x.BookId);
                case OrderByOption.ByVotes:
                    return books.OrderByDescending(x => x.ReviewsAverageVotes);
                case OrderByOption.ByPublicationDate:
                    return books.OrderByDescending(x => x.PublishedOn);
                case OrderByOption.ByPriceLowestFirst:
                    return books.OrderBy(x => x.ActualPrice);
                case OrderByOption.ByPriceHighestFirst:
                    return books.OrderByDescending(x => x.ActualPrice);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOption), orderByOption, null);
            }
        }
    }
}