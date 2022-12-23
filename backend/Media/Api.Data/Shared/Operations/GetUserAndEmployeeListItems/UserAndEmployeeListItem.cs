namespace Api.Data.Shared.Operations.GetUserAndEmployeeListItems;

public class UserAndEmployeeListItem
{
    public string Login { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Surname { get; set; }

    public EmployeePositionPermissionLevel? EmployeePosition { get; set; } = null!;
}