using Api.Contracts.Employee.Model;
using Api.Contracts.Shared;

namespace Api.Contracts.User.Model;

public class UserModelDto
{    
    /// <summary>
    /// Возвращает или устанавливает идентификатор пользователя.
    /// </summary>
    public int Id { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает модератора, который заблокировал пользователя.
    /// </summary>
    public virtual EmployeeModelDto Moderator { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает статус пользователя.
    /// </summary>
    public UserStatus Status { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает логин пользователя.
    /// </summary>
    public string Login { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает пароль пользователя.
    /// </summary>
    public string Password { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает фамилию пользователя.
    /// </summary>
    public string LastName { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает имя пользователя.
    /// </summary>
    public string FirstName { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает отчество пользователя.
    /// </summary>
    public string Surname { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает электронную почту пользователя.
    /// </summary>
    public string Email { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает дату и время регестрации пользователя.
    /// </summary>
    public DateTimeOffset RegistrationDateTime { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает изображение профиля пользователя.
    /// </summary>
    public string ProfileImageUrl { get; set; }
}