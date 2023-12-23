namespace Book.Infrastructure;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(DataContext context) : base(context) { }
}
