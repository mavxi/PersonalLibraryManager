using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        public int PublicationYear { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public int Rating { get; set; }
    }
}