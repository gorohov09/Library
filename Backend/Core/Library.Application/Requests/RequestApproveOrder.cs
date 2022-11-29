namespace Library.Application.Requests
{
    public class RequestApproveOrder
    {
        public int OrderId { get; set; }

        public bool IsApproved { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
