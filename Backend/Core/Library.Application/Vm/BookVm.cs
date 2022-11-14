namespace Library.Application.Vm
{
    public class BookVm
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public IEnumerable<AuthorVm> Authors { get; set; } = new List<AuthorVm>();
        public IEnumerable<BookInsatnceVm> BookInsatnces { get; set; } = new List<BookInsatnceVm>();
    }
}
