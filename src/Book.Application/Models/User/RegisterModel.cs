namespace Book.Application;

public class RegisterModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

public class RegisterResponseModel
{
    public string Id { get; set; }
}