using AutoMapper;
using Book.Infrastructure;


namespace Book.Application;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorResponseModel>> GetAllAsync()
    {
        var authorLists = await _authorRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<AuthorResponseModel>>(authorLists);
    }

    public async Task<AuthorResponseModel> GetAsync(string id)
    {
        return _mapper.Map<AuthorResponseModel>(await _authorRepository.GetFirstAsync(a => a.Id == id));
    }

    public async Task<AuthorResponseModel> CreateAsync(AuthorModel authorModel)
    {
        var author = _mapper.Map<Author>(authorModel);
        author.Id = Guid.NewGuid().ToString("N");
        var result = await _authorRepository.AddAsync(author);

        return _mapper.Map<AuthorResponseModel>(result);
    }

    public async Task<AuthorResponseModel> UpdateAsync(string id, AuthorModel authorModel)
    {
        var author = await _authorRepository.GetFirstAsync(a => a.Id == id);

        author.Name = authorModel.Name;
        author.Age = authorModel.Age;

        return _mapper.Map<AuthorResponseModel>(await _authorRepository.UpdateAsync(author));
    }

    public async Task<AuthorResponseModel> DeleteAsync(string id)
    {
        var author = await _authorRepository.GetFirstAsync(a => a.Id == id);

        return _mapper.Map<AuthorResponseModel>(await _authorRepository.DeleteAsync(author));
    }

}
