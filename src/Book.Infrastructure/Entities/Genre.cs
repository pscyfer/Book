namespace Book.Infrastructure;

public class Genre
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}
