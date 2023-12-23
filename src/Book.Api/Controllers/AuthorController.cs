using Book.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<AuthorResponseModel>>.Success(await _authorService.GetAllAsync()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        return Ok(ApiResult<AuthorResponseModel>.Success(await _authorService.GetAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AuthorModel authorModel)
    {
        return Ok(ApiResult<AuthorResponseModel>.Success(await _authorService.CreateAsync(authorModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, AuthorModel authorModel)
    {
        return Ok(ApiResult<AuthorResponseModel>.Success(await _authorService.UpdateAsync(id, authorModel)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        return Ok(ApiResult<AuthorResponseModel>.Success(await _authorService.DeleteAsync(id)));
    }
}
