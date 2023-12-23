namespace Book.Application;

public interface IUserService
{
    Task<RegisterResponseModel> RegisterAsync(RegisterModel registerModel);
    Task<LoginResponseModel> LoginAsync(LoginModel loginModel);
    Task<ChangePasswordResponseModel> ChangePasswordAsync(string userId, ChangePasswordModel changePasswordModel);
}
