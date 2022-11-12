using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("Book")]
    public class BookEntity
    {
        [Key]
        [Required]
        [Column(TypeName = "char(13)")]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Column(TypeName = "char(4)")]
        public int Year { get; set; }

        [Required]
        public string Section { get; set; }
    }
}
