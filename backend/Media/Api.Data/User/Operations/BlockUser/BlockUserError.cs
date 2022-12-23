namespace Api.Data.User.Operations.BlockUser;

public class BlockUserError : OperationErrorBase
{
    public bool UserNotFound { get; set; }
}