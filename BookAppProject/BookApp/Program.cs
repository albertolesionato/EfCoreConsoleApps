

static void eagerLoading(BookAppDbContext context)
{
    Book book;

    // Eager loading of first book with the corresponding Reviews relationship
    book = context.Books.Include(book => book.Reviews)
        .First();
    //Console.WriteLine(book.Reviews.First().Comment);
    //Console.WriteLine(book.Tags == null);

    // Eager loading of the Book class and all the related data
    book = context.Books
        .Include(book => book.AuthorsLink)
            .ThenInclude(bookAuthor => bookAuthor.Author)
        .Include(book => book.Reviews)
        .Include(book => book.Tags)
        .Include(book => book.Promotion)
        .First();

   
}

using (var context = new BookAppDbContext()) {
    eagerLoading(context);

}