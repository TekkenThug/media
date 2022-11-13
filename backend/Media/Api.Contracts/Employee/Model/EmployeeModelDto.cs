using Api.Contracts.EmployeePosition.Model;
using Api.Contracts.Shared;

namespace Api.Contracts.Employee.Model;

public class EmployeeModelDto
{    
    /// <summary>
    /// Возвращает или устанавливает идентификатор сотрудника.
    /// </summary>
    public int Id { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает должность сотрудника.
    /// </summary>
    public EmployeePositionModelDto Position { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает логин сотрудника.
    /// </summary>
    public string Login { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает пароль сотрудника.
    /// </summary>
    public string Password { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает фамилию сотрудника.
    /// </summary>
    public string LastName { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает имя сотрудника.
    /// </summary>
    public string FirstName { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает отчество сотрудника.
    /// </summary>
    public string Surname { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает электронную почту сотрудника.
    /// </summary>
    public string Email { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает номер телефона сотрудника.
    /// </summary>
    public string Phone { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает статус сотрудника.
    /// </summary>
    public EmployeeStatus Status { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает изображение профиля сотрудника.
    /// </summary>
    public string ProfileImageUrl { get; set; }
}