
namespace BookApp.Models
{
    public class Review
    {

        // Review(int ReviewId, string VoterName, int NumStars, int BookId, 
        // Book Book)
        // {
        //     this.ReviewId = ReviewId;
        //     this.VoterName = VoterName;
        //     this.NumStars = NumStars;
        //     this.BookId = BookId;
        //     this.Book = Book;
        // }

        public int ReviewId { get; set; }
        public string VoterName { get; set; } = null!;
        public int NumStars { get; set; }
        public string? Comment { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}