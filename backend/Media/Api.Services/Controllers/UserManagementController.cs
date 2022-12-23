using Api.Data.Employee;
using Api.Data.Shared.Operations.GetUserAndEmployeeListItems;
using Api.Data.User;
using Api.Data.User.Operations.BlockUser;
using Api.Data.User.Operations.UserAuthentication;
using Api.Data.User.Operations.UserRegister;
using Api.Services.Employee;
using Api.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Controllers;

public class UserManagementController : MediaControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IUserService _userService;

    [HttpGet]
    [Route("ping")]
    public Task<string> Ping()
    {
        return Task.FromResult("pong");
    }

    public UserManagementController(IEmployeeService employeeService, IUserService userService)
    {
        _employeeService = employeeService;
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public Task<UserRegisterResponse> Register(UserRegisterRequest request) => _userService.Register(request);

    [HttpPost]
    [Route("auth")]
    public Task<UserAuthenticationResponse> Authentication(UserAuthenticationRequest request) =>
        _userService.Authentication(request);

    [HttpPost]
    [Route("block-user")]
    public Task<BlockUserResponse> BlockUser(BlockUserRequest request) =>
        _userService.BlockUser(request);

    [HttpGet]
    [Route("usersAndEmployees")]
    public async Task<GetUserAndEmployeeListItemsResponse> GetUserAndEmployeeListItems()
    {
        List<UserOrm> users = await _userService.GetModels();
        List<EmployeeOrm> employees = await _employeeService.GetModels();
        
        var result = new GetUserAndEmployeeListItemsResponse { IsSucceeded = true };
        
        result.Items.AddRange(users.ConvertAll(UserConvertToUserAndEmployeeListItem));
        result.Items.AddRange(employees.ConvertAll(EmployeeConvertToUserAndEmployeeListItem));

        return result;
    }

    private static UserAndEmployeeListItem UserConvertToUserAndEmployeeListItem(UserOrm user)
    {
        return new UserAndEmployeeListItem
        {
            Login = user.Login,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Surname = user.Surname
        };
    }
    
    private static UserAndEmployeeListItem EmployeeConvertToUserAndEmployeeListItem(EmployeeOrm employee)
    {
        return new UserAndEmployeeListItem
        {
            Login = employee.Login,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Surname = employee.Surname,
            EmployeePosition = employee.Position.PermissionLevel
        };
    }
}