namespace Api.Data.User.Operations.UserAuthentication;

public class UserAuthenticationRequest
{
    public string EmailOrLogin { get; set; }
    
    public string Password { get; set; }
}