using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        [Required]
        public int BookInsatnceId { get; set; }

        [Required]
        [ForeignKey("BookId")]
        public BookInsatnceEntity BookInsatnce { get; set; }

        [Required]
        public int ReaderId { get; set; }

        [Required]
        [ForeignKey("ReaderId")]
        public ReaderEntity Reader { get; set; }

        [Required]
        public int LibrarianId { get; set; }

        [Required]
        [ForeignKey("LibrarianId")]
        public LibrarianEntity Librarian { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? ExecutionDate { get; set; }
    }
}
