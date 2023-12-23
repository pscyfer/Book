namespace Book.Application;

public class BookModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public int PageCount { get; set; }
    public string AuthorId { get; set; }
}
