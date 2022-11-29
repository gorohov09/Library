using Library.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public enum StatusOrder
    {
        WAIT,
        DONE,
        DENIED
    }

    public enum TypeOrder
    {
        ISSUE,
        RETURN
    }

    public class OrderEntity : BaseEntity
    {
        [Required]
        public int BookInsatnceId { get; set; }

        [Required]
        [ForeignKey("BookInsatnceId")]
        public BookInsatnceEntity BookInsatnce { get; set; }

        [Required]
        public string ReaderId { get; set; }

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

        public StatusOrder Status { get; set; }

        public TypeOrder Type { get; set; }

        public string GetStatusOrder() 
        {
            if (Status == StatusOrder.DONE)
                return "Выполнено";
            else if (Status == StatusOrder.DENIED)
                return "Отказано";
            else if (Status == StatusOrder.WAIT)
                return "В ожидании";

            return Status.ToString(); 
        }

        public string GetTypeOrder()
        {
            if (Type == TypeOrder.ISSUE)
                return "Выдача";
            else if (Type == TypeOrder.RETURN)
                return "Возврат";

            return Status.ToString();
        }
    }
}
