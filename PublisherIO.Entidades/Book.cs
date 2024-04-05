using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublisherIO.Entidades
{
    [Table("Books")]
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(256)]
        public string Title { get; set; } = null!;
        public DateOnly PublishDate { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}
