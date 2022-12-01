namespace Library.Application.Requests
{
    public class RequestApproveOrder
    {
        public int OrderId { get; set; }

        public bool IsApproved { get; set; }

        //Новое поле, которое должен отправлять фронт
        public int LibrarianId { get; set; }
    }
}
