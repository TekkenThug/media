using System.ComponentModel.DataAnnotations;
using Api.Data.Shared;
using Api.Data.Employee;

namespace Api.Data.User;

public class UserOrm : IEntityOrm
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор пользователя.
    /// </summary>
    [Key]
    public int Id { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает модератора, который заблокировал пользователя.
    /// </summary>
    public EmployeeOrm Moderator { get; set; }
        
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
    public byte[] Password { get; set; }
        
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