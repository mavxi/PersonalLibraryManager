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

        [Fact]
        public void Can_Add_Author_To_Database()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestAuthorDb")
                .Options;

            using (var context = new LibraryDbContext(options))
            {
                context.Authors.Add(new Author { Name = "Stephen King" });
                context.SaveChanges();
            }

            using (var context = new LibraryDbContext(options))
            {
                var authors = context.Authors.ToList();
                Assert.Single(authors);
                Assert.Equal("Stephen King", authors[0].Name);
            }
        }

        [Fact]
        public void Can_Add_Genre_To_Database()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestGenreDb")
                .Options;

            using (var context = new LibraryDbContext(options))
            {
                context.Genres.Add(new Genre { Name = "Horror" });
                context.SaveChanges();
            }

            using (var context = new LibraryDbContext(options))
            {
                var genres = context.Genres.ToList();
                Assert.Single(genres);
                Assert.Equal("Horror", genres[0].Name);
            }
        }

        [Fact]
        public void Can_Delete_Author_From_Database()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDeleteDb")
                .Options;

            int authorId;

            using (var context = new LibraryDbContext(options))
            {
                var author = new Author { Name = "To Be Deleted" };
                context.Authors.Add(author);
                context.SaveChanges();
                authorId = author.Id;
            }

            using (var context = new LibraryDbContext(options))
            {
                var authorToDelete = context.Authors.Find(authorId);
                context.Authors.Remove(authorToDelete);
                context.SaveChanges();
            }

            using (var context = new LibraryDbContext(options))
            {
                var count = context.Authors.Count();
                Assert.Equal(0, count);
            }
        }
    }
}