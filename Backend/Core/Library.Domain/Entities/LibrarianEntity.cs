using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Domain.Entities
{
    [Table("Librarian")]
    public  class LibrarianEntity : BaseEntity
    {
        [Required]
        public string  FullName { get; set; }

        [Required]
        [Column(TypeName = "char(11)")]
        public string MobilePhone { get; set; }
        
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
