using AutoMapper;
using Book.Infrastructure;

namespace Book.Application.Mapper;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<AuthorModel, Author>();

        CreateMap<Author, AuthorResponseModel>();
    }
}
