namespace Library.Application.Vm
{
    public class OrderDetailsForLibrarianVm
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }
        public int RowNumber { get; set; }
        public ReaderVm Reader { get; set; }
    }
}
