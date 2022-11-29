namespace Library.Application.Requests
{
    public class RequestOrder
    {
        public string LibraryCard { get; set; }

        public string BookISBN { get; set; }

        public string TypeOrder { get; set; }

        public int BookInstanceId { get; set; }
    }
}
