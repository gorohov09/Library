using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Domain.Entities
{
    [Table("Author")]
    public class AuthorEntity : BaseEntity
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Country { get; set; }
    }
}
