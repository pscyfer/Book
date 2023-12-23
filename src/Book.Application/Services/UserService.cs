using AutoMapper;
using Book.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;

namespace Book.Application;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<RegisterResponseModel> RegisterAsync(RegisterModel registerModel)
    {
        var user = _mapper.Map<User>(registerModel);

        var result = await _userManager.CreateAsync(user, registerModel.Password);

        if (!result.Succeeded) throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

        return new RegisterResponseModel
        {
            Id = (await _userManager.FindByNameAsync(user.UserName)).Id
        };
    }

    public async Task<LoginResponseModel> LoginAsync(LoginModel loginModel)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginModel.Username);

        if (user == null) throw new NotFoundException("Username or password is incorrect");

        var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

        if (!result.Succeeded) throw new BadRequestException("Username or password is incorrect");

        var token = JwtHandler.GenerateToken(user, _configuration);

        return new LoginResponseModel
        {
            Username = user.UserName,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<ChangePasswordResponseModel> ChangePasswordAsync(string userId, ChangePasswordModel changePasswordModel)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) throw new NotFoundException("User does not exist anymore");

        var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword, changePasswordModel.NewPassword);

        if (!result.Succeeded) throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

        return new ChangePasswordResponseModel { Id = user.Id };
    }
}
