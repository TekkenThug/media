namespace Api.Data.User.Operations.UserRegister;

public class UserRegisterError : OperationErrorBase
{
    public bool UserWithSameEmailAlreadyExist { get; set; }
    
    public bool UserWithSameLoginAlreadyExist { get; set; }
}