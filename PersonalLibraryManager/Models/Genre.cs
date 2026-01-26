using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}