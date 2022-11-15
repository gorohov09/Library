using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Domain.Entities
{
    [Table("Reader")]
    public class ReaderEntity
    {
        [Key]
        [Required]
        [Column(TypeName = "char(6)")]
        public string LibraryCard { get; set; }

        [Required]
        public string FullName { get; set; }

        [Column(TypeName = "char(4)")]
        public string? BirthYear { get; set; }

        [Column(TypeName = "char(6)")]
        public string StudentCard { get; set; }

        [Required]
        public bool IsHasDebt { get; set; }

        [Required]
        [Column(TypeName = "char(11)")]
        public string MobilePhone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
