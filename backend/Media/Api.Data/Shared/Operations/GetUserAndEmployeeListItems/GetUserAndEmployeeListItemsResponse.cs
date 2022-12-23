namespace Api.Data.Shared.Operations.GetUserAndEmployeeListItems;

public class GetUserAndEmployeeListItemsResponse : OperationResultBase
{
    public List<UserAndEmployeeListItem> Items { get; set; } = new();

    public GetUserAndEmployeeListItemsResponse(OperationResultBase other) : base(other)
    {
    }
    
    public GetUserAndEmployeeListItemsResponse()
    {
        
    }
}