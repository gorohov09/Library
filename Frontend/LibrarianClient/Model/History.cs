namespace LibrarianClient.Model
{
    public class History
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }
        public string Authors { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }
    }
}