﻿namespace Api.Data.User.Operations.UserRegister;

public class UserRegisterRequest
{
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Surname { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
}