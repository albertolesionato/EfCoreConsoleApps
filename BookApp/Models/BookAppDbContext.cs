using Microsoft.EntityFrameworkCore;

namespace BookApp.Models
{
    public class BookAppDbContext : DbContext
    {

        private const string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;
            Database=BookAppDb;
            Trusted_Connection=True;";
        public DbSet<Book> Books => Set<Book>();

        // public DbSet<Author> Authors { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        // public DbSet<PriceOffer> PriceOffers { get; set; }

        protected override void OnConfiguring(
                DbContextOptionsBuilder optionsBuilder
            )
        {
            optionsBuilder
                .UseSqlServer(ConnectionString);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) {

        // }

    }
}