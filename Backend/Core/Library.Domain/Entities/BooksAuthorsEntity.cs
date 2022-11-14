using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("AuthorBook")]
    public class BooksAuthorsEntity
    {
        [Required]
        [Column(TypeName = "char(13)")]
        public string ISBN { get; set; }

        [Required]
        public int AuthorID { get; set; }
        
        [ForeignKey("ISBN")]
        public BookEntity Book { get; set; }

        [ForeignKey("AuthorID")]
        public AuthorEntity Author { get; set; }


    }
}
