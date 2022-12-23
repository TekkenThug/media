namespace Api.Data;

public abstract class OperationResultBase
{
    public bool IsSucceeded { get; set; }
}

public abstract class OperationResultBase<TError> where TError : OperationErrorBase
{
    public bool IsSucceeded { get; set; }
    
    public TError Error { get; set; }
}