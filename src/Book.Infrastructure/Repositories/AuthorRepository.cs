namespace Book.Infrastructure;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DataContext context) : base(context) { }
}
