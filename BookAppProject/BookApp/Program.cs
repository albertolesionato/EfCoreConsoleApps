#pragma warning disable CS8321

static void eagerLoading(BookAppDbContext context)
{
    Book firstBook;

    // Eager loading of first book with the corresponding Reviews relationship
    firstBook = context.Books.Include(book => book.Reviews)
        .AsNoTracking()
        .First();
    //Console.WriteLine(firstBook.Reviews.First().Comment);
    //Console.WriteLine(firstBook.Tags == null);

    // Eager loading of the Book class and all the related data
    firstBook = context.Books
        .Include(book => book.AuthorsLink)
            .ThenInclude(bookAuthor => bookAuthor.Author)
        .Include(book => book.Reviews)
        .Include(book => book.Tags)
        .Include(book => book.Promotion)
        .AsNoTracking()
        .First();
    //Console.WriteLine(firstBook.AuthorsLink.First().Order);
    //Console.WriteLine(firstBook.Tags.First().TagId);

    // Sorting and filtering when using Include or ThenInclude
    firstBook = context.Books
        .Include(book => book.AuthorsLink
            .OrderBy(bookAuthor => bookAuthor.Order))
            .ThenInclude(bookAuthor => bookAuthor.Author)
        .Include(book => book.Reviews
            .Where(review => review.NumStars == 5))
        .Include(book => book.Promotion)
        .AsNoTracking()
        .First();
    //Console.WriteLine(firstBook.Reviews.First().Comment);



}

static void explicitLoading(BookAppDbContext context) {
    Book firstBook = context.Books.First();

    // Explicit loading of the Book class and related data
    context.Entry(firstBook)
        .Collection(book => book.AuthorsLink).Load();
    foreach (var authorLink in firstBook.AuthorsLink) {
        context.Entry(authorLink)
            .Reference(bookAuthor =>
                bookAuthor.Author).Load();
    }
    context.Entry(firstBook)
        .Collection(book => book.Tags).Load();
    context.Entry(firstBook)
        .Reference(book => book.Promotion).Load();
    // Console.WriteLine(firstBook.Tags.First().TagId);

    // Explicit loading of the Book class with a refined set of related data
    var numReviews = context.Entry(firstBook)
        .Collection(book => book.Reviews)
        .Query().Count();
    Console.WriteLine(numReviews);

    var starsRating = context.Entry(firstBook)
        .Collection(book => book.Reviews)
        .Query().Select(review => review.NumStars)
        .ToList();
    Console.WriteLine(starsRating.First());
    Console.WriteLine(firstBook.Reviews.Count == 0);
}

static void selectLoading(BookAppDbContext context) {
    var books = context.Books
        .Select(book => new {
            book.Title,
            book.Price,
            NumReviews
                = book.Reviews.Count
        }).ToList();
    Console.WriteLine(books.First().NumReviews);
}

static void clientVsServerSideEvaluation(BookAppDbContext context) {
    var firstBook = context.Books
        .Select(book => new {
            book.BookId,
            book.Title,
            AuthorsString = string.Join(", ", 
                book.AuthorsLink
                .OrderBy(ba => ba.Order)
                .Select(ba => ba.Author.Name))
        }).First();
    Console.WriteLine(firstBook.AuthorsString);
}

// The code to produce a list of the years when books are published
static void yearsWhenBooksArePublished(BookAppDbContext context) {
    var result = context.Books
        .Where(x => x.PublishedOn <= DateTime.UtcNow.Date)
        .Select(x => x.PublishedOn.Year.ToString())
        .Distinct()
        .OrderByDescending(x => x)
        .ToList();

    var commingSoon = context.Books
        .Any(x => x.PublishedOn > DateTime.UtcNow.Date);
    if (commingSoon) {
        result.Insert(0, BookListDtoFilter.AllBooksNotPublishedString);
    }
}

using (var context = new BookAppDbContext())
{
    // eagerLoading(context);
    // explicitLoading(context);
    // selectLoading(context);
    // clientVsServerSideEvaluation(context);

}