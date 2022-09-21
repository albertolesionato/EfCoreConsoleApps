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
    Book firstBook;

    firstBook = context.Books.First();
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
    Console.WriteLine(firstBook.Tags.First().TagId);
}

using (var context = new BookAppDbContext())
{
    //eagerLoading(context);
    explicitLoading(context);

}