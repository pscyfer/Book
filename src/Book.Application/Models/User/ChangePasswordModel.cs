namespace Book.Application;

public class ChangePasswordModel
{
    public string OldPassword { get; set; }

    public string NewPassword { get; set; }
}
public class ChangePasswordResponseModel
{
    public string Id { get; set; }
}