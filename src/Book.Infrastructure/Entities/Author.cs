namespace Book.Infrastructure;

public class Author
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<Book> Books { get; set; }
}
