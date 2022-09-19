using Microsoft.EntityFrameworkCore;

namespace BookApp.Models
{
    public class BookAppDbContext : DbContext
    {

        private const string ConnectionString =
            // @"Server=(localdb)\MSSQLLocalDB;
            // Database=BookAppDb;
            // Trusted_Connection=True;";
            @"Server=127.0.0.1;
            Database=BookAppDb;
            User Id=postgres;";

        public DbSet<Book> Books => Set<Book>();
        public DbSet<PriceOffer> PriceOffers => Set<PriceOffer>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Review> Reviews => Set<Review>();


        protected override void OnConfiguring(
                DbContextOptionsBuilder optionsBuilder
            )
        {
            // optionsBuilder
            //     .UseSqlServer(ConnectionString);
            optionsBuilder
                .UseNpgsql(ConnectionString);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) {

        // }

    }
}