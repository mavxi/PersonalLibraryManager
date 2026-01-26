using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}