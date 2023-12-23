namespace Book.Infrastructure;

public class Book
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public int PageCount { get; set; }
    public Author? Author { get; set; }
    public List<Genre> Genres { get; set; }
}
