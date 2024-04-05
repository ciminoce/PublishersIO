using Microsoft.EntityFrameworkCore;
using PublisherIO.Entidades;

namespace PublisherIO.Data
{
    public class PublisherDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; 
                Initial Catalog=PublishersIO; 
                Trusted_Connection=true;
                TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName="Isaac",
                    LastName="Asimov"
                }
                );

            var authorList = new List<Author>()
            {
                new Author
                {
                    AuthorId=4,
                    FirstName="Arthur",
                    LastName="Clarke"
                },
                new Author
                {
                    AuthorId=5,
                    FirstName="Ursula",
                    LastName="LeGuin"
                },
                new Author
                {
                    AuthorId=6,
                    FirstName="John",
                    LastName="Tolkien"
                }
            };
            modelBuilder.Entity<Author>().HasData(authorList);

            var bookList = new List<Book>()
            {
                new Book
                {
                    BookId = 1,
                    Title = "I, Robot",
                    PublishDate = new DateOnly(1972, 5, 27),
                    Price = 15,
                    AuthorId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "The Tombs Of Atuan",
                    PublishDate = new DateOnly(1960, 10, 1),
                    Price = 10,
                    AuthorId = 5

                },
                new Book
                {
                    BookId = 3,
                    Title = "A Whizard Of Earthsea",
                    PublishDate = new DateOnly(1980, 12, 25),
                    Price = 10,
                    AuthorId = 5

                }


            };
            modelBuilder.Entity<Book>().HasData(bookList);

        }
        public DbSet<Author> Authors { get; set; }
    }
}
