
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models;

public class ChangePubDateDto
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime PublishedOn { get; set; }
}
