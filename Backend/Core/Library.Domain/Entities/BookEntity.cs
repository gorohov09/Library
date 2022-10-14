using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CountExamplesAmount { get; set; }
    }
}
