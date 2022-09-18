using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models
{
    public class Book
    {
        public Book(int BookId, string Title, DateTime PublishedOn,
        string Publisher, decimal Price, string ImageUrl)
        {
            this.BookId = BookId;
            this.Title = Title;
            this.PublishedOn = PublishedOn;
            this.Publisher = Publisher;
            this.Price = Price;
            this.ImageUrl = ImageUrl;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Review> Reviews { get; set; } = null!;

        // public PriceOffer Promotion { get; set; }

        // public ICollection<Tag> Tags { get; set; }

        // public ICollection<BookAuthor> AuthorsLink { get; set; }
    }
}