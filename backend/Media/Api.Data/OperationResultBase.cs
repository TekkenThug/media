namespace Api.Data;

public abstract class OperationResultBase
{
    public bool IsSucceeded { get; set; }

    public OperationErrorBase Error { get; set; }

    protected OperationResultBase()
    {
        Error = new OperationErrorBase();
    }

    protected OperationResultBase(OperationResultBase other)
    {
        this.IsSucceeded = other.IsSucceeded;
        this.Error = other.Error;
    }
}

public abstract class OperationResultBase<TError> where TError : OperationErrorBase
{
    public bool IsSucceeded { get; set; }
    
    public TError Error { get; set; }
}