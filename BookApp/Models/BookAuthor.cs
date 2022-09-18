// using System.ComponentModel.DataAnnotations;

// namespace BookApp.Models
// {
//     public class BookAuthor
//     {
//         [Key]
//         [Required]
        
//         public int BookAuthorId { get; set; } //#H
//         public int BookId { get; set; } //#H
//         public int AuthorId { get; set; } //#H
//         public byte Order { get; set; } //#I

//         //-----------------------------
//         //Relationships

//         public ICollection<Book> Book { get; set; } //#J
//         public ICollection<Author> Author { get; set; } //#K
//     }
// }