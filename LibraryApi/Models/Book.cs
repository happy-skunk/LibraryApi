using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(1, uint.MaxValue)]
        public uint Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
