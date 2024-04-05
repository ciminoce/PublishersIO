using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PublisherIO.Entidades
{
    [Index(nameof(FirstName),nameof(LastName),IsUnique =true)]
    public class Author
    {
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; }=null!;
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
