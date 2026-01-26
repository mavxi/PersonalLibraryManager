using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Services;
using Xunit;

namespace PersonalLibraryManager.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void Can_Add_Book_To_Database()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestLibraryDb")
                .Options;

            using (var context = new LibraryDbContext(options))
            {
                var author = new Author { Name = "Test Author" };
                var genre = new Genre { Name = "Test Genre" };

                context.Authors.Add(author);
                context.Genres.Add(genre);
                context.SaveChanges();

                var book = new Book
                {
                    Title = "Test Book",
                    Year = 2023,
                    AuthorId = author.Id,
                    GenreId = genre.Id
                };

                context.Books.Add(book);
                context.SaveChanges();
            }

            using (var context = new LibraryDbContext(options))
            {
                var books = context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

                Assert.Single(books);
                Assert.Equal("Test Book", books[0].Title);
            }
        }
    }
}