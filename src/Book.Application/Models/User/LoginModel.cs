namespace Book.Application;

public class LoginModel
{
    public string Username { get; set; }

    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
}
