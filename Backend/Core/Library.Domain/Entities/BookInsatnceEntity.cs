using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table ("BookInstance")]
    public class BookInsatnceEntity : BaseEntity
    {
        [Required]
        [Column(TypeName = "char(13)")]
        public string ISBN { get; set; }

        [Required]
        public int RowNumber { get; set; }
        
        [Required]
        public bool IsAvailable { get; set; } 

        [Required]
        [ForeignKey("ISBN")]
        public BookEntity BookInfo { get; set; }
    }
}
