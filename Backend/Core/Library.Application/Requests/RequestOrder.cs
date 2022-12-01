namespace Library.Application.Requests
{
    //Если отправляет на получение книги, то LibraryCard BookISBN
    //Если на возврат, то LibraryCard и HistoryId
    public class RequestOrder
    {
        public string LibraryCard { get; set; }

        public string? BookISBN { get; set; }

        public int HistoryId { get; set; }

        //public string TypeOrder { get; set; }

        //public int BookInstanceId { get; set; }
    }
}
