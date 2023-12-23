namespace Book.Application;

public interface IAuthorService
{
    Task<IEnumerable<AuthorResponseModel>> GetAllAsync();

    Task<AuthorResponseModel> GetAsync(string id);

    Task<AuthorResponseModel> CreateAsync(AuthorModel authorModel);

    Task<AuthorResponseModel> UpdateAsync(string id, AuthorModel authorModel);

    Task<AuthorResponseModel> DeleteAsync(string id);
}
