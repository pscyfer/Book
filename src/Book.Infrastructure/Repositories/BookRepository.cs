namespace Book.Infrastructure;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(DataContext context) : base(context) { }
}
