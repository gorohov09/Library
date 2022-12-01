using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("History")]
    public class RecordEntity : BaseEntity
    {
        [Required]
        public int BookId { get; set; }
        
        [Required]
        public string ReaderID { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        [ForeignKey("BookId")]
        public BookInsatnceEntity BookInsatnce { get; set; }

        [Required]
        [ForeignKey("ReaderID")]
        public ReaderEntity Reader { get; set; }
    }
}
