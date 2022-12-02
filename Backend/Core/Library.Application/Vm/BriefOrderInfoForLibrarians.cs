namespace Library.Application.Vm;

public class BriefOrderInfoForLibrarians
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public DateTime CreationDate { get; set; }
    public string BookPublisher { get; set; }
    public string BookYear { get; set; }
    public int RowNumber { get; set; }
    public string ReaderFullName { get; set; }
    public string BookAuthors { get; set; }
    public string ReaderId { get; set; }
}