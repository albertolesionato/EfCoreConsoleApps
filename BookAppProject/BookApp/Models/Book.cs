using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; } = null!;
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<BookAuthor> AuthorsLink { get; set; } = new HashSet<BookAuthor>();

    public PriceOffer? Promotion { get; set; }
}
