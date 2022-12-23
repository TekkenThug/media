namespace Api.Data.User.Operations.UserAuthentication;

public class UserAuthenticationError : OperationErrorBase
{
    public bool UserNotFound { get; set; }
    
    public bool InvalidPassword { get; set; }
}