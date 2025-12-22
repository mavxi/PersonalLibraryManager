using Microsoft.EntityFrameworkCore;

namespace PersonalLibraryManager.Models
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PersonalLibraryDB;Trusted_Connection=True;");
        }
    }
}