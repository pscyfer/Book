namespace Book.Application;

public class BookResponseModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public int PageCount { get; set; }
}
