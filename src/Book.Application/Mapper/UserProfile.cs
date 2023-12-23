using AutoMapper;
using Book.Infrastructure;

namespace Book.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterModel, User>();
    }
}
